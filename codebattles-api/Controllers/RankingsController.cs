using codebattle_api.DTO;
using codebattle_api.Exceptions;
using codebattle_api.Services.GameServices;
using codebattle_api.Services.ParticipantServices;
using codebattle_api.Services.UserServices;
using codebattle_api.utils.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RankingsController : MainControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IParticipantService _participantService;
        private readonly IUserService _userService;
        public RankingsController(IGameService gameService, IParticipantService participantService, IUserService userService)
        {
            _gameService = gameService;
            _participantService = participantService;
            _userService = userService;
        }

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetRankings()
        {
            try
            {
                var userList = await _userService.GetList();
                IEnumerable<RankingDTO> Rankings = new List<RankingDTO>();
                foreach (var user in userList)
                {
                    RankingDTO result = new RankingDTO
                    {
                        Id = user.Id,
                        Username = user.Username,
                        AvatarBase64 = user.AvatarBase64,
                        BattlesWon = await GetTotalWonBattles(user.Id),
                    };
                    Rankings = Rankings.Append(result);
                }

                Rankings = Rankings.OrderByDescending(x => x.BattlesWon);

                return Ok(Rankings);
            }
            catch (CodeBattleException ex)
            {
                return ReturnError(ex);
            }
        }
        private async Task<int> GetTotalWonBattles(int userId)
        {
            return (await _gameService.ListBySpec<GameDTO>(x => x.WinnerId == userId)).Count();
        }
    }
}