namespace Tercuman.Mobile.Features.Profile.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(ViewModels.ProfileViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}