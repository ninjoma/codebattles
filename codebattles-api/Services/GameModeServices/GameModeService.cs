using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.GameModeServices{
    public class GameModeService : MainService<GameMode, GameModeDTO, GameModeDetailDTO>, IGameModeService
    {
        #region Builder & Properties
        public GameModeService(IMapper mapper, IRepository<GameModeDTO, GameMode> repository) : base(mapper, repository)
        {
        }
        #endregion Builder & Properties
    }
}