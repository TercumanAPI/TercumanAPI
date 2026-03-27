namespace Tercuman.Mobile.Features.Listings.Models;

public class ListingCardItem
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string City { get; set; } = string.Empty;
}
