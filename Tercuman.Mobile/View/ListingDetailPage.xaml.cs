using Tercuman.Contracts.DTOs.Listing;

namespace Tercuman.Mobile.View;

[QueryProperty(nameof(Listing), "listing")]
public partial class ListingDetailPage : ContentPage
{
    public ListingDto Listing
    {
        set
        {
            BindingContext = value;  
        }
    }

    public ListingDetailPage()
    {
        InitializeComponent();
    }
}