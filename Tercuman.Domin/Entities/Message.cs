using Tercuman.Domin.Common;
using Tercuman.Domin.Entities;

public class Message : BaseEntity
{
    public string Content { get; set; }

    public Guid SenderId { get; set; }
    public User Sender { get; set; }

    public Guid ReceiverId { get; set; }
    public User Receiver { get; set; }

    public bool IsRead { get; set; } = false;
}