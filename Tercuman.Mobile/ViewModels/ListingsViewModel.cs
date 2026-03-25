using CommunityToolkit.Mvvm.Input;
using Tercuman.Contracts.DTOs.Listing;
using Tercuman.Mobile.Services;

namespace Tercuman.Mobile.ViewModels;

public partial class ListingsViewModel : BaseViewModel
{
    private readonly IApiService _apiService;
    private readonly AuthService _authService;

    public ListingsViewModel(IApiService apiService, AuthService authService)
    {
        _apiService = apiService;
        _authService = authService;
    }

    [RelayCommand]
    private async Task LoadListings()
    {
        if (IsLoading)
        {
            return;
        }

        try
        {
            IsLoading = true;
            ErrorMessage = null;

            var response = await _apiService.GetListings();

            if (!response.Success)
            {
                ErrorMessage = response.Message;
                Listings = new List<ListingDto>();
                return;
            }

            Listings = response.Data?.Items ?? new List<ListingDto>();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            Listings = new List<ListingDto>();
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private async Task Logout()
    {
        await _authService.LogoutAsync();
        await Shell.Current.GoToAsync("//login");
    }
}
