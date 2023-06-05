using System.Linq.Expressions;
using System.Security.Claims;
using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Enums;
using codebattle_api.Repositories;
using codebattle_api.utils.Extensions;

namespace codebattle_api.Services.GameServices
{
    public class GameService : MainService<Game, GameDTO, GameDetailDTO>, IGameService
    {
        private readonly IRepository<ParticipantDTO, Participant> _participantRepo;
        #region Builder & Properties
        public GameService(IMapper mapper, IRepository<GameDTO, Game> repository, IRepository<ParticipantDTO, Participant> participantRepo) : base(mapper, repository)
        {
            _participantRepo = participantRepo;
        }
        #endregion Builder & Properties


        public virtual async Task<GameDTO> AddWithParticipant(GameDTO postDTO, ClaimsPrincipal User)
        {
            var gameResult = await Add(postDTO);

            var paticipantDTO = new ParticipantDTO()
            {
                Id = 0,
                IsActive = true,
                UserId = User.GetUserId(),
                GameId = gameResult.Id,
            };

            var participantResult = await _participantRepo.Add(paticipantDTO);

            return await GetById(gameResult.Id);
        }

        public override async Task<GameDetailDTO> GetById(int id, bool isActive = true)
        {
#pragma warning disable CS8603 //OmniSharp Reconoce la expresion como un tipo simple y siempre da warning de posible referencia nula
            var includes = new List<Expression<Func<Game, object>>>
            {
                u => u.GameMode,
                u => u.Winner,
                u => u.Participants,
            };
#pragma warning restore CS8603

            return await _repository.GetById<GameDetailDTO>(id, includes, isActive);
        }

        public async Task<IEnumerable<GameDetailDTO>> ListByFilter(int? languageId = null, int? gameModeId = null, GameStatusEnum? gameStatus = null)
        {
#pragma warning disable CS8603 //OmniSharp Reconoce la expresion como un tipo simple y siempre da warning de posible referencia nula
            var includes = new List<Expression<Func<Game, object>>>
                {
                    u => u.GameMode,
                    u => u.Winner,
                    u => u.Participants,
                };
#pragma warning restore CS8603

            var result = await ListBySpec<GameDetailDTO>(
                x => x.IsActive &&
                 (gameModeId != null ? x.GameModeId == gameModeId : x.GameModeId == x.GameModeId) &&
                 (languageId != null ? x.LanguageId == languageId : x.LanguageId == x.LanguageId) &&
                 (gameStatus != null ? x.GameStatus == gameStatus : x.GameStatus == x.GameStatus),
                 includes);
                 
            return result;
        }
    }
}