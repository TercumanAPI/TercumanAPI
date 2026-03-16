using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tercuman.API.Models;
using Tercuman.Application.Interfaces;

namespace Tercuman.API.Controllers;

[ApiController]
[Route("api/messages")]
[Authorize]
public class MessagesController : ControllerBase
{
    private readonly IMessageRepository _messageRepository;

    public MessagesController(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    [HttpGet("{conversationId}")]
    public async Task<IActionResult> GetMessages(Guid conversationId)
    {
        var messages = await _messageRepository.GetConversationMessages(conversationId);
        return Ok(ApiResponse<object>.Ok(messages));
    }
}
