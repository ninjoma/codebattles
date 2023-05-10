using codebattle_api.DTO;
using codebattle_api.Services.GameServices;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : MainController<IGameService, GameDTO, GameDetailDTO>
    {
        public GameController(IGameService service) : base(service)
        {
        }
    }
}