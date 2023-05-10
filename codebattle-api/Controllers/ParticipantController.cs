using codebattle_api.DTO;
using codebattle_api.Services.GameServices;
using codebattle_api.Services.ParticipantServices;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : MainController<IParticipantService, ParticipantDTO, ParticipantDTO>
    {
        public ParticipantController(IParticipantService service) : base(service)
        {
        }
    }
}