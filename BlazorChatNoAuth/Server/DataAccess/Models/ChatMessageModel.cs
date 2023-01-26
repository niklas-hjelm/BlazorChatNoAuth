using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorChatNoAuth.Server.DataAccess.Models;

public class ChatMessageModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }    

    [BsonElement]
    public string Name { get; set; }

    [BsonElement]
    public string Message { get; set; }

    [BsonElement]
    public DateTime Time { get; set; } = DateTime.Now;
}