using System.Linq.Expressions;
using System.Security.Claims;
using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Enums;
using codebattle_api.Repositories;
using codebattle_api.Repositories.GameRepository;
using codebattle_api.utils.Extensions;

namespace codebattle_api.Services.GameServices
{
    public class GameService : MainService<Game, GameDTO, GameDetailDTO>, IGameService
    {
        private readonly IRepository<ParticipantDTO, Participant> _participantRepo;
        private readonly IRepository<StepDTO, Step> _stepRepo;
        private readonly IGameRepository _gameRepo;

        #region Builder & Properties
        public GameService(IMapper mapper, IRepository<GameDTO, Game> repository, IRepository<ParticipantDTO, Participant> participantRepo, IRepository<StepDTO, Step> stepRepo, IGameRepository gameRepo) : base(mapper, repository)
        {
            _participantRepo = participantRepo;
            _stepRepo = stepRepo;
            _gameRepo = gameRepo;
        }
        #endregion Builder & Properties


        public async Task<List<StepDTO>> getRandomSteps(int languageId, int stepAmmount)
        {
            var stepList = (await _stepRepo.ListBySpec<StepDTO>(x => x.IsActive && x.LanguageId == languageId)).ToList();

            Random random = new Random();

            List<StepDTO> randomEntities = new List<StepDTO>();
            for (int i = 0; i < stepAmmount; i++)
            {
                int randomIndex = random.Next(stepList.Count); // Genera un índice aleatorio
                StepDTO randomStep = stepList[randomIndex]; // Obtiene el elemento correspondiente al índice generado
                randomEntities.Add(randomStep);
                stepList.RemoveAt(randomIndex);
            }
            return randomEntities;
        }

        public virtual async Task<GameDTO> AddWithParticipant(GameDTO postDTO, ClaimsPrincipal User)
        {

            // Setup Game Status to wait for other players
            postDTO.GameStatus = GameStatusEnum.Waiting;
            var gameResult = await _repository.Add(postDTO);

            await _gameRepo.AddSteps(gameResult.Id, await getRandomSteps(gameResult.LanguageId, 3));

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
            return await _gameRepo.GetById<GameDetailDTO>(id, isActive);
        }

        public async Task<IEnumerable<GameDetailDTO>> ListByFilter(int? languageId = null, int? gameModeId = null, GameStatusEnum? gameStatus = null)
        {
            var result = await _gameRepo.ListBySpec<GameDetailDTO>(
                x => x.IsActive &&
                 (gameModeId != null ? x.GameModeId == gameModeId : x.GameModeId == x.GameModeId) &&
                 (languageId != null ? x.LanguageId == languageId : x.LanguageId == x.LanguageId) &&
                 (gameStatus != null ? x.GameStatus == gameStatus : x.GameStatus == x.GameStatus)
                 );

            return result;
        }

    }
}