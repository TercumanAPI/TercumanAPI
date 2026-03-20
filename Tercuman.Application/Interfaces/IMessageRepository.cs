using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Domain.Entities;

namespace Tercuman.Application.Interfaces
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task<List<Message>> GetConversationMessages(Guid conversationId);
        Task<List<Message>> GetConversationAsync(Guid user1, Guid user2);
        Task<List<Message>> GetUserNotificationsAsync(Guid userId);
        Task MarkAsReadAsync(Guid messageId, Guid userId);
    }
}
