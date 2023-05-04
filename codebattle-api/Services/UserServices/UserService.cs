using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.UserServices{
    public class UserService : MainService<User, UserDTO, UserDetailDTO>, IUserService
    {
        #region Builder & Properties
        public UserService(IMapper mapper, IRepository<UserDTO, User> repository) : base(mapper, repository)
        {
        }
        #endregion Builder & Properties
    }
}