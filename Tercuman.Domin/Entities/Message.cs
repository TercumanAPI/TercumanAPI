using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domin.Common;

namespace Tercuman.Domin.Entities
{
    public class Message : BaseEntity
    {
        public string Content { get; set; }

        public Guid SenderId { get; set; }
        public User Sender { get; set; }

        public Guid ReceiverId { get; set; }
        public User Receiver { get; set; }

        public bool IsRead { get; set; } = false;
    }
}