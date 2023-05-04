namespace codebattle_api.Services
{
    public interface IMainService<PostDTO,DetailDTO> where PostDTO : class
    {
        Task<DetailDTO> GetById(int id, bool isActive = true);
        Task <IEnumerable<DetailDTO>> GetList(bool isActive);
        Task<PostDTO> EditById(PostDTO entryDTO);
        Task<PostDTO> Add(PostDTO entryDTO);
        Task<bool> DeleteById(int id, bool isDbDelete = false);
    }
}