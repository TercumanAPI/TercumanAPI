using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Mobile.Base;
using Tercuman.Mobile.Features.Messages.Models;
using Tercuman.Mobile.Features.Messages.Services;
using Tercuman.Mobile.Features.Messages.Views;

namespace Tercuman.Mobile.Features.Messages.ViewModels;

public partial class MessagesViewModel : BaseViewModel
{
    private readonly IChatService _chatService;

    public MessagesViewModel(IChatService chatService)
    {
        _chatService = chatService;
        Conversations = new ObservableCollection<ConversationListItem>();
    }

    public ObservableCollection<ConversationListItem> Conversations { get; }

    // HATA ÇÖZÜMÜ (CS0103): Değişken ismini küçük harfle başlatmalısın (camelCase)
    // [ObservableProperty] otomatik olarak büyük harfli 'SelectedConversation'ı oluşturur.
    [ObservableProperty]
    private ConversationListItem selectedConversation;

    // HATA ÇÖZÜMÜ (CS0759): OnSelectedConversationChanged metodu 
    // küçük harfli değişken ismine göre otomatik üretilir.
    partial void OnSelectedConversationChanged(ConversationListItem value)
    {
        if (value == null) return;

        MainThread.BeginInvokeOnMainThread(async () =>
        {
            // HATA ÇÖZÜMÜ (CS0234): 'Tercuman.Mobile.Shell' ile çakışıyor. 
            // Başına 'Microsoft.Maui.Controls' ekleyerek asıl Shell'i çağırıyoruz.
            await Microsoft.Maui.Controls.Shell.Current.GoToAsync($"{nameof(ConversationDetailPage)}?conversationId={value.Id}");

            SelectedConversation = null;
        });
    }

    public async Task InitializeAsync()
    {
        if (IsBusy) return;
        IsBusy = true;

        try
        {
            var result = await _chatService.GetConversationsAsync();

            Conversations.Clear();
            if (result != null)
            {
                foreach (var item in result)
                {
                    Conversations.Add(item);
                }
            }
        }
        catch (Exception ex)
        {
            // Shell hatası burada da olabilir, tam yol yazalım:
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", "Mesaj listesi alınamadı.", "Tamam");
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task Refresh()
    {
        await InitializeAsync();
    }
}