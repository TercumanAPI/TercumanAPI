using Tercuman.Mobile.Features.Auth.ViewModels;

namespace Tercuman.Mobile.Features.Auth.Views;

public partial class LoginPage : ContentPage
{
    // Constructor'da ViewModel'i dýþarýdan alýyoruz (Dependency Injection)
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}