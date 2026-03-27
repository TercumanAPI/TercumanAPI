using CommunityToolkit.Mvvm.Input;
using Tercuman.Mobile.Base;
using Tercuman.Mobile.Core.Abstractions;

namespace Tercuman.Mobile.Features.Auth.ViewModels;

public partial class SplashViewModel(IAuthService authService, INavigationService navigationService) : BaseViewModel
{
    public override async Task OnAppearingAsync()
    {
        await Task.Delay(150);
        var isAuthenticated = await authService.IsAuthenticatedAsync();
        await navigationService.GoToAsync(isAuthenticated ? "//dashboard" : "//login");
    }
}
