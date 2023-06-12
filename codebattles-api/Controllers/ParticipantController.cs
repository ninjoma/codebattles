using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Services.GameServices;
using codebattle_api.Services.ParticipantServices;
using codebattle_api.utils;
using codebattle_api.utils.Extensions;
using codebattle_api.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using codebattle_api.Services.GameServices;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : MainController<IParticipantService, ParticipantDTO, ParticipantDetailDTO, Participant>
    {

        private readonly IGameService _gameService;

        public ParticipantController(IParticipantService service, IGameService gameService) : base(service)
        {
            _gameService = gameService;
        }

        [HttpPost("")]
        public override async Task<IActionResult> Create([FromBody] ParticipantDTO? postDTO)
        {
            try
            {
                GameDetailDTO game = await _gameService.GetById((int) postDTO.GameId);

                if(game.Participants.Count < game.GameMode.MaxPlayers) {
                    return BadRequest("The maximum number of players in battle was reached.");
                }

                if((this.User.GetUserRole() != "Admin") || (postDTO?.UserId == null && this.User.GetUserRole() == "Admin")
                    ) {
                    postDTO.UserId = this.User.GetUserId();
                }
                var result = await _service.Add(postDTO);
                return Ok(result);
            }
            catch (CodeBattleException ex)
            {
                return ReturnError(ex);
            }
        }
    }
}