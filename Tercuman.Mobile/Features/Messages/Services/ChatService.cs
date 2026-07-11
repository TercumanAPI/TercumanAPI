using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Mobile.Features.Messages.Models;

namespace Tercuman.Mobile.Features.Messages.Services;

public class ChatService : IChatService
{
    private readonly IApiService _apiService;

    public ChatService(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<List<ConversationListItem>> GetConversationsAsync()
    {
        return await _apiService.GetAsync<List<ConversationListItem>>("messages/conversations");
    }

    public async Task<List<MessageBubbleItem>> GetMessagesAsync(Guid conversationId)
    {
        return await _apiService.GetAsync<List<MessageBubbleItem>>($"messages/{conversationId}");
    }

    public async Task<bool> SendMessageAsync(SendMessageRequestModel request)
    {
        return await _apiService.PostAsync<SendMessageRequestModel, bool>("messages/send", request);
    }
}