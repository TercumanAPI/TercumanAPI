using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Contracts.DTOs.Listing;
using Tercuman.Mobile.Services;
using Tercuman.Mobile.ViewModels;

namespace Tercuman.Mobile.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isLoading;

    [ObservableProperty]
    private string? errorMessage;

    [ObservableProperty]
    private List<ListingDto> listings = new();
}