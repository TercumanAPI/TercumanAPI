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
}