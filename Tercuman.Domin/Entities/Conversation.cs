using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Entities;

namespace Tercuman.Domain.Entities;

public class Conversation
{
    public Guid Id { get; set; }

    public Guid User1Id { get; set; }
    public Guid User2Id { get; set; }

    public List<Message> Messages { get; set; } = new();
}
