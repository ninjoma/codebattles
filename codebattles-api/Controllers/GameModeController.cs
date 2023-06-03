using codebattle_api.DTO;
using codebattle_api.Entities;
using codebattle_api.Services.GameModeServices;
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
    }
}