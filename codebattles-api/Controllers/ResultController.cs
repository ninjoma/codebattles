using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Services.GameModeServices;
using codebattle_api.Services.LanguageServices;
using codebattle_api.Services.ResultServices;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResultController : MainController<IResultService, ResultDTO, ResultDetailDTO, Result>
    {
        public ResultController(IResultService service) : base(service)
        {
        }
    }
}