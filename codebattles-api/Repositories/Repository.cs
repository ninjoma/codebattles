using System.Linq.Expressions;
using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace codebattle_api.Repositories
{
    public class Repository<PostDTO, Entity> : IRepository<PostDTO, Entity> where PostDTO : BaseDTO where Entity : Entities.Entity
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<Entity> dbSet;
        private bool disposed = false;

        public Repository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            dbSet = _context.Set<Entity>();
        }

        public async Task<PostDTO> Add(PostDTO newDto)
        {
            var newEntity = _mapper.Map<Entity>(newDto);
            await dbSet.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PostDTO>(newEntity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                if (entity.IsActive)
                {
                    entity.IsActive = !entity.IsActive;
                }
                else
                {
                    throw new CodeBattleException(ErrorCode.NotFound);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DbDelete(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<PostDTO> Edit(PostDTO newDto)
        {
            var existingEntity = await dbSet.FindAsync(newDto.Id);

            if (existingEntity == null)
            {
                // La entidad no existe, puedes manejar esto según tus necesidades.
                throw new CodeBattleException(ErrorCode.NotFound);
            }

            // Actualizar solo los campos no nulos
            var properties = typeof(PostDTO).GetProperties();

            foreach (var property in properties)
            {
                var newValue = property.GetValue(newDto);

                if (newValue != null)
                {
                    var existingProperty = typeof(Entity).GetProperty(property.Name);
                    existingProperty.SetValue(existingEntity, newValue);
                }
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<PostDTO>(existingEntity);
        }

        public async Task<returnDTO> GetById<returnDTO>(int id, List<Expression<Func<Entity, object>>>? includes = null, bool isActive = true)
        {
            IQueryable<Entity> query = dbSet;

            if (includes != null)
            {
                foreach (Expression<Func<Entity, object>>? include in includes)
                {
                    query = query.Include(include);
                }
            }

            return _mapper.Map<returnDTO>(await query.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id) && x.IsActive == isActive));
        }

        public async Task<IEnumerable<returnDTO>> List<returnDTO>(List<Expression<Func<Entity, object>>>? includes = null, bool isActive = true)
        {
            IQueryable<Entity> query = dbSet;

            if (includes != null)
            {
                foreach (Expression<Func<Entity, object>>? include in includes)
                {
                    query = query.Include(include);
                }
            }
            return _mapper.Map<IEnumerable<returnDTO>>(await query.AsNoTracking().Where(x => x.IsActive == isActive).ToListAsync());
        }

        public async Task<bool> Save()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<returnDTO> GetBySpec<returnDTO>(Expression<Func<Entity, bool>> specification, List<Expression<Func<Entity, object>>>? includes = null)
        {
            IQueryable<Entity> query = dbSet;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return _mapper.Map<returnDTO>(await query.AsNoTracking().FirstOrDefaultAsync(specification));
        }

        public async Task<IEnumerable<returnDTO>> ListBySpec<returnDTO>(Expression<Func<Entity, bool>> specification, List<Expression<Func<Entity, object>>>? includes = null, Expression<Func<Entity, Entity>>? selectExpression = null)
        {
            IQueryable<Entity> query = dbSet;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            query = query.Where(specification);

            if (selectExpression != null)
            {
                query = query.Select(selectExpression);
            }

            return _mapper.Map<IEnumerable<returnDTO>>(await query.AsNoTracking().ToListAsync());
        }
    }
}