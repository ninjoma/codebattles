using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Services.GameModeServices;
using codebattle_api.Services.LanguageServices;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : MainController<ILanguageService, LanguageDTO, LanguageDetailDTO, Language>
    {
        public LanguageController(ILanguageService service) : base(service)
        {
        }
    }
}