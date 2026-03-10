using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tercuman.Application.Interfaces;
using Tercuman.Domin.Entities;

namespace Tercuman.API.Controllers;

[ApiController]
[Route("api/conversations")]
[Authorize]
public class ConversationsController : ControllerBase
{
    private readonly IConversationRepository _conversationRepository;

    public ConversationsController(IConversationRepository conversationRepository)
    {
        _conversationRepository = conversationRepository;
    }

    [HttpPost("start")]
    public async Task<IActionResult> StartConversation(Guid receiverId)
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        var conversation = await _conversationRepository.GetOrCreateAsync(userId, receiverId);

        return Ok(new
        {
            conversationId = conversation.Id
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetMyConversations()
    {
        var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        var conversations = await _conversationRepository.GetUserConversations(userId);

        return Ok(conversations);
    }
}