using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Services.GameServices;
using codebattle_api.Services.ParticipantServices;
using codebattle_api.utils;
using codebattle_api.utils.Extensions;
using codebattle_api.Exceptions;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("")]
        public override async Task<IActionResult> Create([FromBody] ParticipantDTO postDTO)
        {
            try
            {
                if(postDTO?.UserId == null && (postDTO?.UserId != null && this.User.GetUserRole() != "Admin")) {
                    postDTO.UserId = this.User.GetUserId();
                }
 
                var result = await _service.Add(postDTO);
                return Ok(result);
            }
            catch (CodeBattleException ex)
            {
                return ReturnError(ex);
            }
        }
    }
}