using Tercuman.Domain.Common;

namespace Tercuman.Domain.Entities;

public class Message : BaseEntity
{
    public Guid ConversationId { get; set; }

    public Guid SenderId { get; set; }

    public Guid ReceiverId { get; set; }

    public string Text { get; set; } = string.Empty;

    public bool IsRead { get; set; }

    public Conversation? Conversation { get; set; }

    public User? Sender { get; set; }

    public User? Receiver { get; set; }
}