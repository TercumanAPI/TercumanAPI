namespace Tercuman.Mobile.Features.Messages.Services;

public interface IChatService
{
    Task ConnectAsync(CancellationToken cancellationToken = default);
    Task DisconnectAsync(CancellationToken cancellationToken = default);
    Task SendAsync(string conversationId, string message, CancellationToken cancellationToken = default);
}
