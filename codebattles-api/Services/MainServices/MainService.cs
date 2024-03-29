using System.Linq.Expressions;
using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Repositories;

namespace codebattle_api.Services
{
    public abstract class MainService<Entity, PostDTO, DetailDTO> where PostDTO : BaseDTO where DetailDTO : BaseDTO
    {
        #region Builder & Properties
        protected readonly IMapper _mapper;
        protected readonly IRepository<PostDTO, Entity> _repository;

        public MainService(IMapper mapper, IRepository<PostDTO, Entity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        #endregion Builder & Properties

        public virtual async Task<PostDTO> Add(PostDTO entryDTO)
        {
            return await _repository.Add(entryDTO);
        }

        public virtual async Task<bool> DeleteById(int id, bool isDbDelete = false)
        {
            if (isDbDelete)
            {
                return await _repository.DbDelete(id);
            }
            else
            {
                return await _repository.Delete(id);
            }
        }

        public virtual async Task<PostDTO> EditById(PostDTO entryDTO)
        {
            entryDTO.CreationDate = DateTime.Now.ToUniversalTime();
            return await _repository.Edit(entryDTO);

        }

        public virtual async Task<DetailDTO> GetById(int id, bool isActive = true)
        {
            return await _repository.GetById<DetailDTO>(id, null, isActive);
        }

        public virtual async Task<IEnumerable<DetailDTO>> GetList(List<Expression<Func<Entity, object>>>? include = null, bool isActive = true)
        {
            return await _repository.List<DetailDTO>(include, isActive);
        }

        public virtual async Task<returnDTO> GetBySpec<returnDTO>(Expression<Func<Entity, bool>> specification)
        {
            return await _repository.GetBySpec<returnDTO>(specification);
        }

        public virtual async Task<IEnumerable<returnDTO>> ListBySpec<returnDTO>(Expression<Func<Entity, bool>> specification, List<Expression<Func<Entity, object>>>? include = null)
        {
            return await _repository.ListBySpec<returnDTO>(specification, include);
        }
    }
}