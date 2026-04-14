using Tercuman.Mobile.Features.Messages.ViewModels;

namespace Tercuman.Mobile.Features.Messages.Views;

public partial class ConversationDetailPage : ContentPage
{
    private readonly ConversationDetailViewModel _viewModel;

    public ConversationDetailPage(ConversationDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }
}