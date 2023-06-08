using System.Linq.Expressions;
using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace codebattle_api.Repositories.GameRepository
{
    public class GameRepository : IGameRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<Game> dbSet;
        private bool disposed = false;

        public GameRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            dbSet = _context.Set<Game>();
        }

        public async Task<GameDTO> AddSteps(int gameId, ICollection<StepDTO> steps)
        {
            var game = await dbSet.Include(g => g.Steps).FirstOrDefaultAsync(g => g.Id == gameId);

            if (game != null)
            {
                foreach (var stepDto in steps)
                {
                    var step = _mapper.Map<Step>(stepDto);

                    // Verificar si el step ya existe en el juego
                    if (game.Steps != null)
                    {
                        var existingStep = game.Steps.FirstOrDefault(s => s.Id == step.Id);
                        if (existingStep != null)
                        {
                            // Actualizar las propiedades del step existente
                            _mapper.Map(stepDto, existingStep);
                        }
                        else
                        {
                            // Agregar el nuevo step al juego
                            game.Steps.Add(step);
                        }
                    }
                }

                await _context.SaveChangesAsync();
            }

            return _mapper.Map<GameDTO>(game);
        }

        public async Task<returnDTO> GetById<returnDTO>(int id, bool isActive = true)
        {
            IQueryable<Game> query = dbSet;
#pragma warning disable CS8620
            query = query.Include(x => x.GameMode);
            query = query.Include(x => x.Language);
            query = query.Include(x => x.Participants).ThenInclude(x => x.User);
            query = query.Include(x => x.Winner);
            query = query.Include(x => x.Steps).ThenInclude(x => x.Validations);
#pragma warning restore CS8620
            return _mapper.Map<returnDTO>(await query.FirstOrDefaultAsync(x => x.Id.Equals(id) && x.IsActive == isActive));
        }

        public async Task<IEnumerable<returnDTO>> ListBySpec<returnDTO>(Expression<Func<Game, bool>> specification, Expression<Func<Game, Game>>? selectExpression = null)
        {
            IQueryable<Game> query = dbSet;


#pragma warning disable CS8620
            query = query.Include(x => x.GameMode);
            query = query.Include(x => x.Language);
            query = query.Include(x => x.Winner);
            query = query.Include(x => x.Steps);
            query = query.Include(x => x.Participants).ThenInclude(x => x.User);
#pragma warning restore CS8620

            query = query.Where(specification);

            if (selectExpression != null)
            {
                query = query.Select(selectExpression);
            }

            return _mapper.Map<IEnumerable<returnDTO>>(await query.AsNoTracking().ToListAsync());
        }
    }
}