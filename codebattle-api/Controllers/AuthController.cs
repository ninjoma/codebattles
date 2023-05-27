using System.Security.Claims;
using codebattle_api.DTO;
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
        public async Task<IActionResult> GenerateToken([FromBody] UserDTO user)
        {
            if (user.Email != null)
            {
                var result = await _UserSv.GetBySpec<UserDTO>(x => x.Email != null && x.Email.Equals(user.Email.Trim()));
                if (result != null)
                {
                    //TODO: Repensar como funciona este sistema
                    if (user.Password != null && result.Password != null)
                    {
                        if (PasswordHasher.VerifyPassword(user.Password, result.Password))
                        {
                            return Ok(_AuthSv.GenerateToken(result));
                        }
                        else
                        {
                            return BadRequest("Wrong Password");
                        }
                    }
                    else
                    {
                        return BadRequest("No Password Supplied");
                    }
                }
            }
            return NotFound("No account Binded to email");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDTO user)
        {
            if (user != null)
            {
                if (user.Password != null)
                {
                    user.Password = PasswordHasher.HashPassword(user.Password);
                    return Ok(await _AuthSv.RegisterUser(user));
                }
                else
                {
                    return BadRequest("No Password Supplied");
                }
            }
            else
            {
                return BadRequest("No Data Supplied");
            }
        }
    }
}