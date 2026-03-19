using Tercuman.Mobile.ViewModels;


namespace Tercuman.Mobile.View;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent(); // HATA BURADAN GELÝYOR
        BindingContext = vm;
    }
}