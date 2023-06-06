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


        public virtual async Task<IEnumerable<UserDetailDTO>> FilterUsers(string username = "", string email = "", string? role = "User")
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
            return await _repository
                .ListBySpec<UserDetailDTO>(
                    specification: x => x.Username != null && x.Email != null
                        && x.Username.Contains(username)
                        && x.Email.Contains(email)
                        && x.IsActive,
                    selectExpression: selectExpression);
        }


        public override async Task<UserDetailDTO> GetById(int id, bool isActive = true)
        {
            #pragma warning disable CS8603 //OmniSharp Reconoce la expresion como un tipo simple y siempre da warning de posible referencia nula
            var includes = new List<Expression<Func<User, object>>>
            {
                u => u.Badges,
                u => u.Friends,
                u => u.Participants,
                u => u.WinnedGames
            };
            #pragma warning restore CS8603
            return await _repository.GetById<UserDetailDTO>(id, includes, isActive);
        }
    }
}