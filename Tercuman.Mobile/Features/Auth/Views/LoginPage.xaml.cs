using Tercuman.Mobile.Features.Auth.ViewModels;

namespace Tercuman.Mobile.Features.Auth.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    // EÐER AÞAÐIDAKÝ GÝBÝ BÝR METOT VARSA VE ÝÇÝ DOLUYSA SÝL VEYA KONTROL ET
    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Burada asenkron bir servisi tetikleyen .Wait() veya .Result gibi bir kod 
        // varsa Windows kesinlikle kilitlenir. Ýçinin boþ olduðundan emin ol.
    }
}