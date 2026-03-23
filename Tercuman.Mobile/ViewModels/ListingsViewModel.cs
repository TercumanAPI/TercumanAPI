using CommunityToolkit.Mvvm.Input;
using Tercuman.Contracts.DTOs.Listing;
using Tercuman.Mobile.Services;

namespace Tercuman.Mobile.ViewModels;

public partial class ListingsViewModel : BaseViewModel
{
    private readonly IApiService _apiService;

    public ListingsViewModel(IApiService apiService)
    {
        _apiService = apiService;
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

            if (response.IsSuccessStatusCode && response.Content != null)
            {
                Listings = response.Content;
            }
            else
            {
                ErrorMessage = "Veriler alınamadı";
                Listings = new List<ListingDto>();
            }
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
}
