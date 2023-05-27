using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Services.GameServices;
using codebattle_api.Services.StepServices;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StepController : MainController<IStepService, StepDTO, StepDetailDTO, Step>
    {
        public StepController(IStepService service) : base(service)
        {
        }
    }
}