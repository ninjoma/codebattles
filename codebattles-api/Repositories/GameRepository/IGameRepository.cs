using System.Linq.Expressions;
using codebattle_api.DTO;
using codebattle_api.Entities;

namespace codebattle_api.Repositories.GameRepository
{
    public interface IGameRepository
    {
        Task<GameDTO> AddSteps(int gameId, ICollection<StepDTO> steps);
        Task<returnDTO> GetById<returnDTO>(int id, bool isActive = true);
        Task<IEnumerable<returnDTO>> ListBySpec<returnDTO>(Expression<Func<Game, bool>> specification, Expression<Func<Game, Game>>? selectExpression = null);
    }
}