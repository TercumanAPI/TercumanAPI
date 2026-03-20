using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tercuman.Application.Interfaces;
using Tercuman.Domain.Entities;
using Tercuman.Infrastructure.Persistence;

namespace Tercuman.API.Hubs;

[Authorize]
public class ChatHub : Hub
{
    private readonly IMessageRepository _messageRepository;
    private readonly AppDbContext _context;

    public ChatHub(IMessageRepository messageRepository, AppDbContext context)
    {
        _messageRepository = messageRepository;
        _context = context;
    }

    public async Task SendMessage(Guid conversationId, Guid receiverId, string text)
    {
        var userIdClaim = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdClaim, out Guid senderId))
            throw new Exception("Invalid UserId");

        var message = new Message
        {
            Id = Guid.NewGuid(),
            ConversationId = conversationId,
            SenderId = senderId,
            ReceiverId = receiverId,
            Text = text,
            CreatedDate = DateTime.UtcNow,
            IsRead = false
        };

        await _messageRepository.AddAsync(message);
        await _messageRepository.SaveChangesAsync();

        var conversation = await _context.Conversations
            .FirstOrDefaultAsync(c => c.Id == conversationId);

        if (conversation != null)
        {
            conversation.LastMessage = text;
            conversation.LastMessageDate = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();

        await Clients.User(receiverId.ToString())
            .SendAsync("ReceiveMessage", message);
    }
}