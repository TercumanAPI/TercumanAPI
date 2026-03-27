namespace Tercuman.Mobile.Features.Messages.Models;

public class MessageBubbleItem
{
    public string Message { get; set; } = string.Empty;
    public DateTime SentAt { get; set; }
    public bool IsMine { get; set; }
}
