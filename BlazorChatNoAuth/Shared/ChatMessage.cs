using System.ComponentModel.DataAnnotations;

namespace BlazorChatNoAuth.Shared;

public class ChatMessage
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Message { get; set; }

    public DateTime Time { get; set; } = DateTime.Now;
}