using Tercuman.Domain.Entities;

namespace Tercuman.Domain.Entities;

public class Conversation
{
    public Guid Id { get; set; }

    public Guid User1Id { get; set; }

    public Guid User2Id { get; set; }

    public User? User1 { get; set; }

    public User? User2 { get; set; }

    public string LastMessage { get; set; } = string.Empty;

    public DateTime? LastMessageDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public ICollection<Message> Messages { get; set; } = new List<Message>();
}