using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Exceptions;
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

        public override async Task<IActionResult> Create([FromBody] UserDTO postDTO)
        {
            try {
                if (postDTO.Password != null){
                    postDTO.Password = PasswordHasher.HashPassword(postDTO.Password);
                    return Ok(await _service.Add(postDTO));
                }
                return BadRequest();
            } catch(CodeBattleException ex){
                return ReturnError(ex);
            }
        }

    }
}