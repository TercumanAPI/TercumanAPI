using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tercuman.API.Models;
using Tercuman.Application.DTOs.Notification;
using Tercuman.Application.Interfaces;

namespace Tercuman.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class NotificationsController : ControllerBase
{
    private readonly IMessageRepository _messageRepository;

    public NotificationsController(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetNotifications()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            return Unauthorized(ApiResponse<object>.Fail("Unauthorized"));

        var userId = Guid.Parse(userIdClaim.Value);
        var messages = await _messageRepository.GetUserNotificationsAsync(userId);

        var result = messages.Select(x => new NotificationDto
        {
            MessageId = x.Id,
            SenderId = x.SenderId,
            SenderName = x.Sender?.FullName ?? "Unknown",
            Content = x.Text,
            SentAt = x.CreatedDate,
            IsRead = x.IsRead
        }).ToList();

        return Ok(ApiResponse<object>.Ok(new
        {
            unreadCount = result.Count(x => !x.IsRead),
            items = result
        }));
    }

    [HttpPut("{messageId}/read")]
    public async Task<IActionResult> MarkAsRead(Guid messageId)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
            return Unauthorized(ApiResponse<object>.Fail("Unauthorized"));

        var userId = Guid.Parse(userIdClaim.Value);
        await _messageRepository.MarkAsReadAsync(messageId, userId);

        return Ok(ApiResponse<object>.Ok(null, "Notification marked as read"));
    }
}
