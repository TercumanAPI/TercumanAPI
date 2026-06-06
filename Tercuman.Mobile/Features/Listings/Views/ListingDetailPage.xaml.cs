using Tercuman.Mobile.Features.Listings.ViewModels;

namespace Tercuman.Mobile.Features.Listings.Views;

public partial class ListingDetailPage : ContentPage
{
    public ListingDetailPage(ListingDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}