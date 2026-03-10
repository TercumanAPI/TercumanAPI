using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Application.DTOs.Conversation
{
    public class ConversationListDto
    {
        public Guid ConversationId { get; set; }

        public Guid UserId { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string LastMessage { get; set; } = string.Empty;

        public DateTime? LastMessageDate { get; set; }
    }
}
