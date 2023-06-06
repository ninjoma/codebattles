using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Exceptions;
using codebattle_api.Services.UserServices;
using codebattle_api.utils;
using codebattle_api.utils.Extensions;
using Microsoft.AspNetCore.Authorization;
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
            if (postDTO.Password != null)
            {
                postDTO.Password = PasswordHasher.HashPassword(postDTO.Password);
                return Ok(await _service.Add(postDTO));
            }
            return BadRequest();
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> Self()
        {
            try{
                return Ok(await _service.GetById(this.User.GetUserId(), true));
            } catch(CodeBattleException cbe) {
                return ReturnError(cbe);
            }
        }

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> FilterUsers([FromQuery] string? username = null, [FromQuery] string? email = null)
        {
            var result = await _service.FilterUsers(username ?? "", email ?? "", User.GetUserRole());
            return result != null && result.Any() ? Ok(result) : NotFound(new ErrorResponse(new CodeBattleException(ErrorCode.NotFound)));
        }

    }
}