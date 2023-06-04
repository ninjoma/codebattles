using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Services.GameServices;
using codebattle_api.Services.ParticipantServices;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : MainController<IParticipantService, ParticipantDTO, ParticipantDetailDTO, Participant>
    {
        public ParticipantController(IParticipantService service) : base(service)
        {
        }
    }
}