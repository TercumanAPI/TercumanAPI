using Tercuman.Mobile.Features.Ads.ViewModels;

namespace Tercuman.Mobile.Features.Ads.Views;

public partial class CreateAdPage : ContentPage
{
	public CreateAdPage(CreateAdViewModel viewModel)
    {
		InitializeComponent();
        BindingContext = viewModel;
    }
}