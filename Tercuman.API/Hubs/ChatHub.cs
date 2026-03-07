using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
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

    public async Task SendMessage(Guid receiverId, string content)
    {
        var userIdClaim = Context.User?.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
            throw new HubException("UserId bulunamadı");

        var senderId = Guid.Parse(userIdClaim.Value);

        var message = new Message
        {
            Name = content.Length > 50 ? content.Substring(0, 50) : content,

            SenderId = senderId,
            ReceiverId = receiverId,
            Content = content
        };

        await _messageRepository.AddAsync(message);
        await _messageRepository.SaveChangesAsync();

        await Clients.User(receiverId.ToString())
            .SendAsync("ReceiveMessage", message);
    }
}