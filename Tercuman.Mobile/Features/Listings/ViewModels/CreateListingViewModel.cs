using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Mobile.Base;
using Tercuman.Mobile.Core.Abstractions;
using Tercuman.Contracts.DTOs.Listing;
using Tercuman.Domain.Enums; 

namespace Tercuman.Mobile.Features.Listings.ViewModels;

// 1. Mutlaka 'public partial' olmalı.
// 2. BaseViewModel'den türemeli (IsBusy hatasını bu çözer).
public partial class CreateListingViewModel : BaseViewModel
{
    private readonly IApiService _apiService;

    public CreateListingViewModel(IApiService apiService)
    {
        _apiService = apiService;
        CurrentStep = 1;
    }

    [ObservableProperty] int currentStep;
    [ObservableProperty] string title;
    [ObservableProperty] string description;
    [ObservableProperty] decimal price;

    [RelayCommand]
    void NextStep() => CurrentStep = Math.Min(3, CurrentStep + 1);

    [RelayCommand]
    void PreviousStep() => CurrentStep = Math.Max(1, CurrentStep - 1);

    [RelayCommand]
    async Task SubmitListingAsync()
    {
        try
        {
            IsBusy = true; // BaseViewModel'den geliyor

            var dto = new CreateListingDto
            {
                Title = this.Title ?? string.Empty,
                Description = this.Description ?? string.Empty,
                Price = this.Price,

                SourceLanguageId = Guid.Empty,
                TargetLanguageId = Guid.Empty,
                CityId = Guid.Empty,

                // Enum kullanımı: Eğer 'Enums' bulunamadı diyorsa 
                // doğrudan DTO içindeki tipi kullanmak için cast ediyoruz.
                ExperienceLevel = (ExperienceLevel)0,
                ServiceType = (ServiceType)0,

                Name = "Mobil Kullanıcı",
                PhoneNumber = "0500000000"
            };

            // _apiService artık sınıfın bir üyesi olduğu için tanınacaktır.
            var result = await _apiService.PostAsync<CreateListingDto, bool>("listings/create", dto);

            if (result)
            {
                await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Başarılı", "İlanınız yayınlandı!", "Tamam");
                await Microsoft.Maui.Controls.Shell.Current.GoToAsync("..");
            }
        }
        catch (Exception ex)
        {
            await Microsoft.Maui.Controls.Shell.Current.DisplayAlert("Hata", ex.Message, "Tamam");
        }
        finally
        {
            IsBusy = false;
        }
    }
}