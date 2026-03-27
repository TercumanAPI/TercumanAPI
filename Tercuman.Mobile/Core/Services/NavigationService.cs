using Tercuman.Mobile.Core.Abstractions;

namespace Tercuman.Mobile.Core.Services;

public class NavigationService : INavigationService
{
    public Task GoToAsync(string route) => Shell.Current.GoToAsync(route);
    public Task GoBackAsync() => Shell.Current.GoToAsync("..");
}
