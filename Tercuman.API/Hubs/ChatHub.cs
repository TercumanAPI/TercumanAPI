using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tercuman.Application.Interfaces;
using Tercuman.Domin.Entities;

namespace Tercuman.API.Hubs;

[Authorize]
public class ChatHub : Hub
{
    private readonly IMessageRepository _messageRepository;

    public ChatHub(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
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


        await Clients.User(receiverId.ToString())
            .SendAsync("ReceiveMessage", message);
    }
}