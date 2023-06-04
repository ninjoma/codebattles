using Microsoft.AspNetCore.SignalR;

namespace codebattle_api.Hubs
{

    public class CodeHub : Hub
    {

        public async Task JoinBattle(string battleId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, battleId);

            string? sender = null;
            if (Context != null && Context.User != null && Context.User.Identity != null)
            {
                sender = Context.User.Identity.Name;
                if (sender != null){
                    await Clients.GroupExcept(battleId, sender).SendAsync("UserJoined", "New User Joined the Battle");
                }
            }
        }

        public async Task LeaveBattle(string battleId)
        {
            string? sender = null;
            if (Context != null && Context.User != null && Context.User.Identity != null)
            {
                sender = Context.User.Identity.Name;
                if (sender != null){
                    await Clients.GroupExcept(battleId, sender).SendAsync("UserLeft", "A user left the battle");
                }
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, battleId);
            }
        }

        public async Task SendCode(string battleId, string mensaje, string userId)
        {
            string? sender = null;
            if (Context != null && Context.User != null && Context.User.Identity != null)
            {
                sender = Context.User.Identity.Name;
                if (sender != null){
                    await Clients.GroupExcept(battleId, sender).SendAsync("RecieveCode", new { code = mensaje, userId = userId });
                }
            }
        }
    }
}