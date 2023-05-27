using codebattle_api.DTO;
using codebattle_api.Services.AuthServices;
using codebattle_api.Services.UserServices;
using codebattle_api.utils;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {

        private readonly IAuthService _AuthSv;
        private readonly IUserService _UserSv;
        public AuthController(IAuthService AuthSv, IUserService UserSv)
        {
            _AuthSv = AuthSv;
            _UserSv = UserSv;
        }

        [HttpPost("Authenticate")]
        public async Task<string> GenerateToken([FromBody] UserDTO user)
        {
            var result = await _UserSv.GetBySpec<UserDTO>(x => x.Email != null && x.Email.Equals(user.Email.Trim()));
            if (result != null)
            {
                //TODO: Repensar como funciona este sistema
                if (PasswordHasher.VerifyPassword(user.Password, result.Password)){
                    return _AuthSv.GenerateToken(result);
                } 
                else
                {
                    return "Wrong Password";
                }
            }
            return "User not found";
        }
    }
}