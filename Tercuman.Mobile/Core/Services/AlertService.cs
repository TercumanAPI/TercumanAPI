using Tercuman.Mobile.Core.Abstractions;

namespace Tercuman.Mobile.Core.Services;

public class AlertService : IAlertService
{
    public Task ShowAlertAsync(string title, string message, string cancel = "Tamam")
        => Shell.Current.DisplayAlert(title, message, cancel);
}
