using Microsoft.AspNetCore.SignalR;

namespace BlazorChatNoAuth.Server.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string name, string message)
    {
        await Clients.All.SendAsync("SendMessage", name, message);
    }
}