using System.Linq.Expressions;

namespace codebattle_api.Services
{
    public interface IMainService<PostDTO,DetailDTO,Entity> where PostDTO : class
    {
        Task<DetailDTO> GetById(int id, bool isActive = true);
        Task <IEnumerable<DetailDTO>> GetList(bool isActive = true);
        Task<returnDTO> GetBySpec<returnDTO>(Expression<Func<Entity, bool>> specification);
        Task<PostDTO> EditById(PostDTO entryDTO);
        Task<PostDTO> Add(PostDTO entryDTO);
        Task<bool> DeleteById(int id, bool isDbDelete = false);
    }
}