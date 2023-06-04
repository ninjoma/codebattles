using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.GameServices{
    public class GameService : MainService<Game, GameDTO, GameDetailDTO>, IGameService
    {
        #region Builder & Properties
        public GameService(IMapper mapper, IRepository<GameDTO, Game> repository) : base(mapper, repository)
        {
        }
        #endregion Builder & Properties

    }
}