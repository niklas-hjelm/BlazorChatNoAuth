using BlazorChatNoAuth.Shared;

namespace BlazorChatNoAuth.Server.DataAccess.Repositories;

public interface IChatRepository
{
    Task AddMessage(ChatMessage message);
    Task<ChatMessage[]> GetAllMessages();
}