using Tercuman.Mobile.Features.Auth.ViewModels;
namespace Tercuman.Mobile.Features.Auth.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}