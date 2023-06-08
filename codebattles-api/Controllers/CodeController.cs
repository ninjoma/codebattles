using System.Security.Claims;
using codebattle_api.DTO;
using codebattle_api.Exceptions;
using codebattle_api.Services.AuthServices;
using codebattle_api.Services.UserServices;
using codebattle_api.Services.GameServices;
using codebattle_api.utils;
using codebattle_api.utils.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeController : ControllerBase
    {
        private readonly IGameService _gameService;
        private Dictionary<string, string> Results = new Dictionary<string, string> {};
        static readonly HttpClient client = new HttpClient();

        public CodeController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Validate([FromBody] CodeDTO codeDTO)
        {
            try
            {
                if(codeDTO.Code == null) 
                {
                    return NoContent();
                }

                GameDetailDTO game = await _gameService.GetById(Int32.Parse(codeDTO?.BattleId));

                if(game == null) 
                {
                    return BadRequest();
                }

                var self = game.Participants?.First((participant) => participant.UserId == this.User.GetUserId());
                var currentStep = game.Steps?.ElementAt((int) self.CurrentStep);
                var code = codeDTO.Code + " " + game.Language?.Validator;

                var judge0url = SecretManager.GetSecret("Judge0");
                var judge0token = SecretManager.GetSecret("Judge0-Key");

                using HttpResponseMessage response = await client.PostAsJsonAsync(judge0url + 
                "submissions/?base64_encoded=false&wait=false&X-Judge0-Token=" + judge0token, new {
                    stdin = currentStep.Validations.ElementAt(0),
                    source_code = code,
                    callback_url = $"{this.Request.Scheme}://{this.Request.Host.Value.ToString()}/Code"
                });

                return Ok();
            }
            catch (CodeBattleException ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }
    
        [HttpPut("")]
        public async Task<IActionResult> GetResult(dynamic values)
        {
            try
            {
                return Ok();
                
            }
            catch (CodeBattleException ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }
    
    }
}