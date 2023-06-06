using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Services.GameModeServices;
using codebattle_api.Services.LanguageServices;
using codebattle_api.Services.ValidationServices;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValidationController : MainController<IValidationService, ValidationDTO, ValidationDetailDTO, Validation>
    {
        public ValidationController(IValidationService service) : base(service)
        {
        }
    }
}