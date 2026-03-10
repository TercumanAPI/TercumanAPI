using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Entities;

namespace Tercuman.Domin.Entities;

public class Conversation
{
    public Guid Id { get; set; }

    public Guid User1Id { get; set; }

    public Guid User2Id { get; set; }

    public User? User1 { get; set; }

    public User? User2 { get; set; }


    public DateTime CreatedDate { get; set; }

    public ICollection<Message> Messages { get; set; } = new List<Message>();
}
