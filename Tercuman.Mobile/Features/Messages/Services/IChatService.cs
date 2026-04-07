using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Mobile.Features.Messages.Models;

namespace Tercuman.Mobile.Features.Messages.Services;

public interface IChatService
{
    Task<List<ConversationListItem>> GetConversationsAsync();
    Task<List<MessageBubbleItem>> GetMessagesAsync(Guid conversationId);
    Task<bool> SendMessageAsync(SendMessageRequestModel request);
}
