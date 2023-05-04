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

        public async Task<PostDTO> Add(PostDTO entryDTO)
        {
            return await _repository.Add(entryDTO);
        }

        public async Task<bool> DeleteById(int id, bool isDbDelete = false)
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

        public async Task<PostDTO> EditById(PostDTO entryDTO)
        {
            return await _repository.Edit(entryDTO);

        }

        public async Task<DetailDTO> GetById(int id, bool isActive = true)
        {
            return await _repository.GetById<DetailDTO>(id, null , isActive);
        }

        public async Task<IEnumerable<DetailDTO>> GetList(bool isActive = true)
        {
            return await _repository.List<DetailDTO>(null, isActive);
        }
    }
}