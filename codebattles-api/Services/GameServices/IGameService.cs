using System.Security.Claims;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Enums;

namespace codebattle_api.Services.GameServices{
    public interface IGameService : IMainService<GameDTO, GameDetailDTO, Game>
    {
        Task<GameDTO> AddWithParticipant(GameDTO postDTO, ClaimsPrincipal User);
        Task<IEnumerable<GameDetailDTO>> ListByFilter(int? language = null, int? gameModeId = null, GameStatusEnum? gameStatus = null);
    }
}