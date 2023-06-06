using codebattle_api.DTO;

namespace codebattle_api.Repositories.GameRepository
{
    public interface IGameRepository
    {
        Task<GameDTO> AddSteps(int gameId, ICollection<StepDTO> steps);
    }
}