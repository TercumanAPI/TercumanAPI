using Microsoft.EntityFrameworkCore;
using Tercuman.Application.DTOs.Conversation;
using Tercuman.Application.Interfaces;
using Tercuman.Domain.Entities;
using Tercuman.Infrastructure.Persistence;

namespace Tercuman.Infrastructure.Repositories;

public class ConversationRepository : IConversationRepository
{
    private readonly AppDbContext _context;

    public ConversationRepository(AppDbContext context)
    {
        _context = context;
    }

    // ======================================
    // GET OR CREATE CONVERSATION
    // ======================================
    public async Task<Conversation> GetOrCreateAsync(Guid user1, Guid user2)
    {
        var conversation = await _context.Conversations
            .FirstOrDefaultAsync(x =>
                (x.User1Id == user1 && x.User2Id == user2) ||
                (x.User1Id == user2 && x.User2Id == user1));

        if (conversation != null)
            return conversation;

        conversation = new Conversation
        {
            Id = Guid.NewGuid(),
            User1Id = user1,
            User2Id = user2,
            CreatedDate = DateTime.UtcNow,
            LastMessage = "",
            LastMessageDate = null
        };

        _context.Conversations.Add(conversation);
        await _context.SaveChangesAsync();

        return conversation;
    }

    // ======================================
    // GET USER CONVERSATIONS (CHAT LIST)
    // ======================================
    public async Task<List<ConversationListDto>> GetUserConversations(Guid userId)
    {
        return await _context.Conversations
            .Include(c => c.User1)
            .Include(c => c.User2)
            .Where(c => c.User1Id == userId || c.User2Id == userId)
            .Select(c => new ConversationListDto
            {
                ConversationId = c.Id,

                UserId = c.User1Id == userId
                    ? c.User2Id
                    : c.User1Id,

                UserName = c.User1Id == userId
                    ? c.User2.FullName
                    : c.User1.FullName,

                LastMessage = c.LastMessage,

                LastMessageDate = c.LastMessageDate
            })
            .OrderByDescending(x => x.LastMessageDate)
            .ToListAsync();
    }
}