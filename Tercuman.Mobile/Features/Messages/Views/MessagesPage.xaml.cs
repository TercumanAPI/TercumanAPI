using Tercuman.Mobile.Features.Messages.ViewModels;

namespace Tercuman.Mobile.Features.Messages.Views;

public partial class MessagesPage : ContentPage
{
    private readonly MessagesViewModel _viewModel;

    public MessagesPage(MessagesViewModel viewModel)
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