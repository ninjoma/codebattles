using codebattle_api.DTO;
namespace codebattle_api.Services.UserServices{
    public class UserService : IUserService
    {
        public UserService()
        {
            
        }

        public Task<UserDTO> Add(UserDTO entryDTO)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> EditById(UserDTO entryDTO)
        {
            throw new NotImplementedException();
        }

        public Task<UserDetailDTO> GetById(int id, bool isActive = true)
        {
            throw new NotImplementedException();
        }
    }
}