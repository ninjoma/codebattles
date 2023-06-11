using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Exceptions;
using codebattle_api.Services.GameServices;
using codebattle_api.Services.ParticipantServices;
using codebattle_api.Services.StepServices;
using codebattle_api.utils.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatController : MainControllerBase
    {

        private readonly IGameService _gameService;
        private readonly IParticipantService _participantService;
        public StatController(IGameService gameService, IParticipantService participantService)
        {
            _gameService = gameService;
            _participantService = participantService;
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetUserStats()
        {
            try
            {
                var totalBattles = await GetTotalBattles();
                var wonBattles = await GetTotalWonBattles();

                statsDTO returnObject = new statsDTO()
                {
                    TotalBattles = totalBattles,
                    WonBattles = wonBattles,
                    WonbattlesRatio = GetWonbattlesRatio(totalBattles, wonBattles),
                    FastestWin = 0,
                    WonInRow = 0,
                };

                return Ok(returnObject);
            }
            catch (CodeBattleException ex)
            {
                return ReturnError(ex);
            }
        }

        private async Task<int> GetTotalBattles()
        {
            return (await _participantService.ListBySpec<ParticipantDTO>(x => x.UserId == User.GetUserId())).Count();
        }

        private async Task<int> GetTotalWonBattles()
        {
            return (await _gameService.ListBySpec<GameDTO>(x => x.WinnerId == User.GetUserId())).Count();
        }

        private double GetWonbattlesRatio(int totalBattles, int wonBattles)
        {
            return (100 / totalBattles) * wonBattles;
        }

        private async Task<int> GetWonInRow()
        {
            var userId = User.GetUserId();
            var totalGames = await _gameService.ListBySpec<GameDetailDTO>(x => x.Participants != null && x.Participants.Any(y => y.UserId == userId));
            totalGames = totalGames.OrderBy(x => x.CreationDate);

            int maxStreak = 0;
            int currentStreak = 0;

            foreach (var game in totalGames) {
                if (game.WinnerId == userId)
                {
                    currentStreak++;
                    if (currentStreak > maxStreak)
                    {
                        maxStreak = currentStreak;
                    }
                }
                else
                {
                    currentStreak = 0;
                }
            }

            return maxStreak;
        }

    }
}