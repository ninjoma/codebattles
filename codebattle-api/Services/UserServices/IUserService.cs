using codebattle_api.DTO;
using codebattle_api.Entities;

namespace codebattle_api.Services.UserServices{
    public interface IUserService : IMainService<UserDTO, UserDetailDTO, User>
    {

    }
}