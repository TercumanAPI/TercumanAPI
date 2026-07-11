using Tercuman.Mobile.Features.Listings.ViewModels;

namespace Tercuman.Mobile.Features.Listings.Views;

public partial class CreateListingPage : ContentPage
{
    public CreateListingPage(CreateListingViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}