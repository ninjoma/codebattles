namespace codebattle_api.Services
{
    public interface IMainService<PostDTO,DetailDTO> where PostDTO : class
    {
        Task<DetailDTO> GetById(int id, bool isActive = true);
        Task<PostDTO> EditById(PostDTO entryDTO);
        Task<PostDTO> Add(PostDTO entryDTO);
        Task<PostDTO> DeleteById(int id);
    }
}