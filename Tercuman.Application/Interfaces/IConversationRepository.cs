using Tercuman.Application.DTOs.Conversation;
using Tercuman.Domain.Entities;

namespace Tercuman.Application.Interfaces;

public interface IConversationRepository
{
    Task<Conversation> GetOrCreateAsync(Guid user1, Guid user2);

    Task<List<ConversationListDto>> GetUserConversations(Guid userId);
}