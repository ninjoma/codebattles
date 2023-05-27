using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Services.UserServices;
using codebattle_api.utils;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : MainController<IUserService, UserDTO, UserDetailDTO, User>
    {
        public UserController(IUserService service) : base(service)
        {
        }

        public override async Task<UserDTO> Create([FromBody] UserDTO postDTO)
        {
            if (postDTO.Password != null){
                postDTO.Password = PasswordHasher.HashPassword(postDTO.Password);
                return await _service.Add(postDTO);
            }
            return null;
        }

    }
}