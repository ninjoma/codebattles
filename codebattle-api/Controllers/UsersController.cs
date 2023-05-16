using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : MainController<IUserService, UserDTO, UserDetailDTO, User>
    {
        public UsersController(IUserService service) : base(service)
        {
        }
    }
}