using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tercuman.Application.Interfaces;
using Tercuman.Domin.Entities;
using Tercuman.Infrastructure.Persistence;

namespace Tercuman.Infrastructure.Repositories;

public class MessageRepository
    : GenericRepository<Message>, IMessageRepository
{
    private readonly AppDbContext _context;

    public MessageRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Message>> GetConversationAsync(Guid user1, Guid user2)
    {
        return await _context.Messages
            .Where(m =>
                (m.SenderId == user1 && m.ReceiverId == user2) ||
                (m.SenderId == user2 && m.ReceiverId == user1))
            .OrderBy(m => m.CreatedDate)
            .ToListAsync();
    }
    public async Task<List<Message>> GetUserNotificationsAsync(Guid userId)
    {
        return await _context.Messages
            .Include(x => x.Sender)
            .Where(x => x.ReceiverId == userId)
            .OrderByDescending(x => x.CreatedDate)
            .Take(10)
            .ToListAsync();
    }
    public async Task MarkAsReadAsync(Guid messageId, Guid userId)
    {
        var message = await _context.Messages
            .FirstOrDefaultAsync(x => x.Id == messageId && x.ReceiverId == userId);

        if (message == null)
            return;

        message.IsRead = true;

        await _context.SaveChangesAsync();
    }
}