using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Mobile.Features.Messages.Models;

public class MessageBubbleItem
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime SentDate { get; set; }
    public bool IsIncoming { get; set; } // true: Karşıdan geldi (Sol), false: Biz gönderdik (Sağ)
    public string SenderName { get; set; }
}