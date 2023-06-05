using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Exceptions;
using codebattle_api.Services.GameServices;
using codebattle_api.Services.ParticipantServices;
using codebattle_api.utils.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : MainController<IGameService, GameDTO, GameDetailDTO, Game>
    {
        private readonly IParticipantService _participantService;
        public GameController(IGameService service, IParticipantService participantService) : base(service)
        {
            _participantService = participantService;
        }

        [HttpPost("")]
        [Authorize(Roles = "User, Admin")]
        public override async Task<IActionResult> Create([FromBody] GameDTO postDTO)
        {
            try
            {
                return Ok(await _service.AddWithParticipant(postDTO, User));
            }
            catch (CodeBattleException ex)
            {
                return ReturnError(ex);
            }
        }
    }
}