using codebattle_api.DTO;
using codebattle_api.Entities;

namespace codebattle_api.Services.UserServices{
    public interface IUserService : IMainService<UserDTO, UserDetailDTO, User>
    {
        /// <summary>
        /// Method that returns a list of users with a username similar
        /// </summary>
        /// <param name="username"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        Task<IEnumerable<UserDetailDTO>> ListByUsername(string username, string? role = "User");
    }
}