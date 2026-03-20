namespace Tercuman.Application.DTOs.Notification;

public class NotificationDto
{
    public Guid MessageId { get; set; }

    public Guid SenderId { get; set; }

    public string SenderName { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTime SentAt { get; set; }

    public bool IsRead { get; set; }
    public Guid? ConversationId { get; set; }
}