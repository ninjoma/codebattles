using codebattle_api.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController{

        private readonly IAuthService _AuthSv;
        public AuthenticationController(IAuthService AuthSv)
        {
            _AuthSv = AuthSv;
        }
    }
}