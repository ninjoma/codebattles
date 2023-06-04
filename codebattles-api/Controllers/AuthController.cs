using System.Security.Claims;
using codebattle_api.DTO;
using codebattle_api.Exceptions;
using codebattle_api.Services.AuthServices;
using codebattle_api.Services.UserServices;
using codebattle_api.utils;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _AuthSv;
        private readonly IUserService _UserSv;
        private readonly IConfiguration Configuration;
        public AuthController(IAuthService AuthSv, IUserService UserSv, IConfiguration configuration)
        {
            _AuthSv = AuthSv;
            _UserSv = UserSv;
            Configuration = configuration;
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

        [HttpPost("/sso/login")]
        public async Task<IActionResult> SsoLogin()
        {
            try
            {
                
                StreamReader reader = new StreamReader(this.Request.Body);
                string result = await reader.ReadToEndAsync();
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(result);
                var jwtValues = jsonToken as JwtSecurityToken;
                string aud = jwtValues != null ? jwtValues.Claims.First(claim => claim.Type == "aud").Value : throw new CodeBattleException(ErrorCode.InvalidInput);

                if(aud != Configuration["GOOGLE_CLIENT_ID"]) {
                    return BadRequest();
                }

                string email = jwtValues.Claims.First(claim => claim.Type == "email").Value;
                return Ok(await _AuthSv.HandleSsoLogin(email));

                
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

        [HttpPost("ForgotPassword/Generate")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {
            try
            {
                return Ok(await _AuthSv.GeneratePasswordToken(email));
            }
            catch (CodeBattleException ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }

        [HttpPost("ForgotPassword/Check")]
        public async Task<IActionResult> CheckPassword([FromBody] PasswordDTO passwordDTO)
        {
            try
            {
                await _AuthSv.CheckPasswordToken(passwordDTO);
                return Ok();
            }
            catch (CodeBattleException ex)
            {
                return BadRequest(new ErrorResponse(ex));
            }
        }
    }
}