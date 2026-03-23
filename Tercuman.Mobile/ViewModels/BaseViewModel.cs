using CommunityToolkit.Mvvm.ComponentModel;
using Tercuman.Contracts.DTOs.Listing;

namespace Tercuman.Mobile.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    private bool isLoading;
    private string? errorMessage;
    private List<ListingDto> listings = new();

    public bool IsLoading
    {
        get => isLoading;
        set => SetProperty(ref isLoading, value);
    }

    public string? ErrorMessage
    {
        get => errorMessage;
        set => SetProperty(ref errorMessage, value);
    }

    public List<ListingDto> Listings
    {
        get => listings;
        set => SetProperty(ref listings, value);
    }
}
