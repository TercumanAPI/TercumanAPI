using Tercuman.Mobile.ViewModels;

namespace Tercuman.Mobile.View;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = vm;

    }
}
