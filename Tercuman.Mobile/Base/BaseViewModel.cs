using CommunityToolkit.Mvvm.ComponentModel;

namespace Tercuman.Mobile.Base;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty] private bool isBusy;
    [ObservableProperty] private string title = string.Empty;
    [ObservableProperty] private bool hasError;
    [ObservableProperty] private string? errorMessage;
    [ObservableProperty] private ViewModelState state = ViewModelState.Idle;

    public virtual Task OnAppearingAsync() => Task.CompletedTask;
    public virtual Task OnNavigatedToAsync(IDictionary<string, object>? parameters = null) => Task.CompletedTask;
}
