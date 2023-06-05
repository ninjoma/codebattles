using System.Linq.Expressions;
using AutoMapper;
using codebattle_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace codebattle_api.Repositories
{
    public class Repository<PostDTO, Entity> : IRepository<PostDTO, Entity> where PostDTO : class where Entity : Entities.Entity
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
            newEntity.CreationDate = DateTime.Now.ToUniversalTime();
            await dbSet.AddAsync(newEntity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PostDTO>(newEntity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                entity.IsActive = !entity.IsActive;
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
            var entity = _mapper.Map<Entity>(newDto);
            dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<PostDTO>(entity);
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

            return _mapper.Map<returnDTO>(await query.FirstOrDefaultAsync(x => x.Id.Equals(id) && x.IsActive == isActive));
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
            return _mapper.Map<IEnumerable<returnDTO>>(await query.Where(x => x.IsActive == isActive).ToListAsync());
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
            return _mapper.Map<returnDTO>(await query.FirstOrDefaultAsync(specification));
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

            return _mapper.Map<IEnumerable<returnDTO>>(await query.ToListAsync());
        }
    }
}