using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Tercuman.Mobile.Core.Abstractions;

namespace Tercuman.Mobile.Shell;

public partial class AppShellViewModel(IAuthService authService, INavigationService navigationService) : ObservableObject
{
    [ObservableProperty] private string userName = "Misafir";

    [RelayCommand]
    private async Task LogoutAsync()
    {
        await authService.LogoutAsync();
        await navigationService.GoToAsync("//login");
    }
}
