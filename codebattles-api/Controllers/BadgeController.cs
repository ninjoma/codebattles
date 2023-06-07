using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Exceptions;
using codebattle_api.Services.BadgeServices;
using codebattle_api.Services.FriendServices;
using codebattle_api.Services.GameServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BadgeController : MainController<IBadgeService, BadgeDTO, BadgeDetailDTO, Badge>
    {
        public BadgeController(IBadgeService service) : base(service)
        {
        }


        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> List([FromQuery] string? badgeName = null)
        {
            try
            {
                var result = await _service.ListBySpec<BadgeDetailDTO>(x => x.Name != null && badgeName != null ? x.Name.Contains(badgeName) : x.Name == x.Name && x.IsActive);
                return result != null ? Ok(result) : NotFound(new ErrorResponse(new CodeBattleException(ErrorCode.NotFound)));
            }
            catch (CodeBattleException ex)
            {
                return ReturnError(ex);
            }
        }

    }
}