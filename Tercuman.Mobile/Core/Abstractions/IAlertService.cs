namespace Tercuman.Mobile.Core.Abstractions;

public interface IAlertService
{
    Task ShowAlertAsync(string title, string message, string cancel = "Tamam");
}
