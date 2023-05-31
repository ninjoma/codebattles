using System.Linq.Expressions;
using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Repositories;

namespace codebattle_api.Services.UserServices
{
    public class UserService : MainService<User, UserDTO, UserDetailDTO>, IUserService
    {
        #region Builder & Properties
        public UserService(IMapper mapper, IRepository<UserDTO, User> repository) : base(mapper, repository)
        {
        }
        #endregion Builder & Properties


        public virtual async Task<IEnumerable<UserDetailDTO>> ListByUsername(string username, string? role = "User")
        {
            Expression<Func<User, User>> selectExpression;
            if (role != null && role == "Admin")
            {
                selectExpression = p => new User
                {
                    Id = p.Id,
                    Username = p.Username,
                    IsAdmin = p.IsAdmin,
                    IsPremium = p.IsPremium,
                    Email = p.Email,
                };
            }
            else
            {
                selectExpression = p => new User
                {
                    Id = p.Id,
                    Username = p.Username,
                    IsAdmin = p.IsAdmin,
                    IsPremium = p.IsPremium,
                };
            }
            return await _repository.ListBySpec<UserDetailDTO>(specification: x => x.Username != null && x.Username.Contains(username) && x.IsActive, selectExpression: selectExpression);
        }
    }
}