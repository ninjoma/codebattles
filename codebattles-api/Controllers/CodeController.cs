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
using Newtonsoft.Json;
using System.Text;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodeController : ControllerBase
    {
        private readonly IGameService _gameService;
        static readonly HttpClient client = new HttpClient();

        private readonly IConfiguration Configuration;

        public CodeController(IGameService gameService, IConfiguration configuration)
        {
            _gameService = gameService;
            Configuration = configuration;
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

                var judge0url = Configuration["Judge0"];
                var judge0token = Configuration["Judge0-Key"];


                JudgeDTO judge = new JudgeDTO {
                    source_code = code,
                    language_id = game.Language.Judge0Id.ToString(),
                    stdin = "\"megatest\""
                };
                var stringContent = new StringContent(JsonConvert.SerializeObject(judge), UnicodeEncoding.UTF8, "application/json");

                using HttpResponseMessage response = await client.PostAsync(judge0url + 
                "submissions?base64_encoded=false&wait=true&X-Judge0-Token=" + judge0token, stringContent);
                string responseBody = await response.Content.ReadAsStringAsync();

                return Ok();
            }
            catch (CodeBattleException ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }
    
    
    }
}