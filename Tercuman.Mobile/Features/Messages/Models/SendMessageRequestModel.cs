using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Mobile.Features.Messages.Models;

public class SendMessageRequestModel
{
    public Guid ConversationId { get; set; }
    public string Text { get; set; }
}
