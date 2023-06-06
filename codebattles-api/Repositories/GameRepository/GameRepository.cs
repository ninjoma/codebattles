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
                    if (game.Steps != null){
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

    }
}