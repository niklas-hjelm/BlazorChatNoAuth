using BlazorChatNoAuth.Server.DataAccess.Models;
using BlazorChatNoAuth.Shared;
using MongoDB.Driver;

namespace BlazorChatNoAuth.Server.DataAccess.Repositories;

public class ChatRepository : IChatRepository
{
    private readonly IMongoCollection<ChatMessageModel> _collection;

    public ChatRepository()
    {
        var hostname = "localhost";
        var databaseName = "BlazorChat";
        var connectionString = $"mongodb://{hostname}:27017";

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<ChatMessageModel>("Messages", new MongoCollectionSettings() { AssignIdOnInsert = true });
    }

    public async Task AddMessage(ChatMessage message)
    {
        await _collection.InsertOneAsync(new ChatMessageModel()
        {
            Name = message.Name,
            Message = message.Message,
            Time = message.Time
        });
    }

    public async Task<ChatMessage[]> GetAllMessages()
    {
        var messagesData = await _collection.FindAsync(_ => true);
        var messages = messagesData.ToList().Select(m => new ChatMessage
        {
            Message = m.Message,
            Name = m.Name,
            Time = m.Time
        });
        return messages.ToArray();
    }
}