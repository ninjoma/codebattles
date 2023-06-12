using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Exceptions;
using codebattle_api.Services.GameModeServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameModeController : MainController<IGameModeService, GameModeDTO, GameModeDetailDTO, GameMode>
    {
        public GameModeController(IGameModeService service) : base(service)
        {
        }

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> List([FromQuery] string? name = null)
        {
            try
            {
                var result = await _service.ListBySpec<GameModeDetailDTO>(x => (x.Name != null && name != null ? x.Name.Contains(name) : x.Name == x.Name) && x.IsActive);
                return result != null && result.Any() ? Ok(result) : NotFound(new ErrorResponse(new CodeBattleException(ErrorCode.NotFound)));
            }
            catch (CodeBattleException ex)
            {
                return ReturnError(ex);
            }
        }
    }
}