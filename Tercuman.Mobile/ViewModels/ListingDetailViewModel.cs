using Tercuman.Contracts.DTOs.Listing;

namespace Tercuman.Mobile.ViewModels;

public class ListingDetailViewModel
{
    public ListingDto Listing { get; set; }

    public string Title => Listing?.Title;
    public decimal Price => Listing?.Price ?? 0;
    public string CityName => Listing?.City;
}