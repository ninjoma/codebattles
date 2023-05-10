using codebattle_api.DTO;
using codebattle_api.Services.FriendServices;
using codebattle_api.Services.GameServices;
using Microsoft.AspNetCore.Mvc;

namespace codebattle_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FriendController : MainController<IFriendService, FriendDTO, FriendDTO>
    {
        public FriendController(IFriendService service) : base(service)
        {
        }
    }
}