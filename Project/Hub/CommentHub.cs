using Microsoft.AspNetCore.SignalR;

namespace Project.Hubs
{
    public class CommentHub : Hub
    {
        public async Task Connect(string itemId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, itemId);
        }
    }
}
