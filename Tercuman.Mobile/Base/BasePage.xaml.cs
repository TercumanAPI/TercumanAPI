namespace Tercuman.Mobile.Base;

public class BasePage : ContentPage
{
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is BaseViewModel vm)
        {
            await vm.OnAppearingAsync();
        }
    }
}
