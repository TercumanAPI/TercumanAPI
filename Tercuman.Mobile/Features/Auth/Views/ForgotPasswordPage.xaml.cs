using Tercuman.Mobile.Features.Auth.ViewModels;

namespace Tercuman.Mobile.Features.Auth.Views;

public partial class ForgotPasswordPage : ContentPage
{
    public ForgotPasswordPage(ForgotPasswordViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}