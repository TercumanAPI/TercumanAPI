using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Mobile.Features.Messages.Models;

public class ConversationListItem
{
    public Guid Id { get; set; }
    public string OtherUserName { get; set; }
    public string OtherUserImageUrl { get; set; }
    public string LastMessage { get; set; }
    public DateTime LastMessageDate { get; set; }
    public int UnreadCount { get; set; }
}
