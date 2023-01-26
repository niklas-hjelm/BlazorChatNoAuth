using BlazorChatNoAuth.Server.DataAccess.Repositories;
using BlazorChatNoAuth.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BlazorChatNoAuth.Server.Hubs;

public class ChatHub : Hub
{
    private readonly IChatRepository _repo;

    public ChatHub(IChatRepository repo)
    {
        _repo = repo;
    }
    public async Task SendMessage(ChatMessage message)
    {
        await _repo.AddMessage(message);
        await Clients.All.SendAsync("SendMessage", message);
    }
}