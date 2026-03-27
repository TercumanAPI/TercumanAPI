namespace Tercuman.Mobile.Features.Messages.Models;

public class SendMessageRequestModel
{
    public string ConversationId { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
