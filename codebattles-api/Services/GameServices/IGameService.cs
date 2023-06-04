using codebattle_api.DTO;
using codebattle_api.Entities;

namespace codebattle_api.Services.GameServices{
    public interface IGameService : IMainService<GameDTO, GameDetailDTO, Game>
    {

    }
}