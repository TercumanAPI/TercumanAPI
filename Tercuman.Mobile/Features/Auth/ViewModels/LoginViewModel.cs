using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Contracts.DTOs.Auth;
using Tercuman.Mobile.Base;
using Tercuman.Mobile.Core.Abstractions;

namespace Tercuman.Mobile.Features.Auth.ViewModels;

public partial class LoginViewModel(IAuthService authService, INavigationService navigationService) : BaseViewModel
{
    [ObservableProperty] private string email = string.Empty;
    [ObservableProperty] private string password = string.Empty;

    [RelayCommand]
    private async Task LoginAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        try
        {
            var response = await authService.LoginAsync(new LoginDto { Email = Email, Password = Password });
            if (response is not null)
            {
                await navigationService.GoToAsync("//dashboard");
            }
        }
        finally
        {
            IsBusy = false;
        }
    }
}
