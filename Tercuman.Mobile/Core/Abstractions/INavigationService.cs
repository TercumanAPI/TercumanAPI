namespace Tercuman.Mobile.Core.Abstractions;

public interface INavigationService
{
    Task GoToAsync(string route);
    Task GoBackAsync();
}
