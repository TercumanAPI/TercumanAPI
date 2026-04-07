using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Mobile.Base;
using Tercuman.Mobile.Features.Messages.Models;
using Tercuman.Mobile.Features.Messages.Services;

namespace Tercuman.Mobile.Features.Messages.ViewModels;

[QueryProperty(nameof(ConversationId), "conversationId")] // Sayfaya gelen ID'yi yakalar
public partial class ConversationDetailViewModel : BaseViewModel
{
    private readonly IChatService _chatService;

    public ConversationDetailViewModel(IChatService chatService)
    {
        _chatService = chatService;
        Messages = new ObservableCollection<MessageBubbleItem>();
    }

    [ObservableProperty] Guid conversationId;
    [ObservableProperty] string newMessageText;
    public ObservableCollection<MessageBubbleItem> Messages { get; }

    // Sayfa açıldığında tetiklenir
    public async Task InitializeAsync()
    {
        if (IsBusy) return;
        IsBusy = true;

        try
        {
            var result = await _chatService.GetMessagesAsync(ConversationId);
            Messages.Clear();
            foreach (var msg in result)
                Messages.Add(msg);
        }
        catch (Exception ex)
        {
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", "Mesajlar yüklenemedi.", "Tamam");
        }
        finally { IsBusy = false; }
    }

    [RelayCommand]
    async Task SendMessage()
    {
        if (string.IsNullOrWhiteSpace(NewMessageText)) return;

        var request = new SendMessageRequestModel
        {
            ConversationId = this.ConversationId,
            Text = NewMessageText
        };

        // Hız hissi için UI'ya hemen ekleyelim
        var tempMsg = new MessageBubbleItem { Text = NewMessageText, SentDate = DateTime.Now, IsIncoming = false };
        Messages.Add(tempMsg);

        var textToSend = NewMessageText;
        NewMessageText = string.Empty;

        var success = await _chatService.SendMessageAsync(request);
        if (!success)
        {
            // Gönderilemediyse kullanıcıyı uyar
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", "Mesaj gönderilemedi.", "Tamam");
        }
    }
}