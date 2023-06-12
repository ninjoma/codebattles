using Microsoft.AspNetCore.SignalR;

namespace codebattle_api.Hubs
{

    public class CodeHub : Hub
    {

        public async Task JoinBattle(string battleId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, battleId);
            await Clients.GroupExcept(battleId, Context.ConnectionId).SendAsync("UserJoined", "New User Joined the Battle");
        }

        public async Task LeaveBattle(string battleId)
        {
            await Clients.GroupExcept(battleId, Context.ConnectionId).SendAsync("UserLeft", "A user left the battle");
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, battleId);
        }

        public async Task SendCode(string battleId, string mensaje, string userId)
        {
            await Clients.GroupExcept(battleId, Context.ConnectionId).SendAsync("RecieveCode", new { code = mensaje, userId = userId });
        }
    }
}