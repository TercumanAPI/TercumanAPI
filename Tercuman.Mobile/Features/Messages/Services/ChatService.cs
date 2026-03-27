using Microsoft.AspNetCore.SignalR.Client;
using Tercuman.Mobile.Core.Config;

namespace Tercuman.Mobile.Features.Messages.Services;

public class ChatService : IChatService
{
    private HubConnection? _hubConnection;

    public async Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        _hubConnection ??= new HubConnectionBuilder()
            .WithUrl($"{ApiSettings.BaseUrl}{ApiSettings.ChatHub}")
            .WithAutomaticReconnect()
            .Build();

        if (_hubConnection.State == HubConnectionState.Disconnected)
        {
            await _hubConnection.StartAsync(cancellationToken);
        }
    }

    public async Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        if (_hubConnection is not null)
        {
            await _hubConnection.StopAsync(cancellationToken);
        }
    }

    public Task SendAsync(string conversationId, string message, CancellationToken cancellationToken = default)
    {
        if (_hubConnection is null)
        {
            return Task.CompletedTask;
        }

        return _hubConnection.SendAsync("SendMessage", conversationId, message, cancellationToken);
    }
}
