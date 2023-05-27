using System.Security.Claims;
using codebattle_api.DTO;
using codebattle_api.Exceptions;
using codebattle_api.Services.AuthServices;
using codebattle_api.Services.UserServices;
using codebattle_api.utils;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _AuthSv;
        private readonly IUserService _UserSv;
        public AuthController(IAuthService AuthSv, IUserService UserSv)
        {
            _AuthSv = AuthSv;
            _UserSv = UserSv;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            try
            {
                return Ok(await _AuthSv.Login(user));
            }
            catch (CodeBattleException ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user)
        {
            try
            {
                return Ok(await _AuthSv.RegisterUser(user));
            }
            catch (CodeBattleException ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }
    }
}