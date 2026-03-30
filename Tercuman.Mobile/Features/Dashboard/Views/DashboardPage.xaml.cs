using Tercuman.Mobile.Features.Dashboard.ViewModels;

namespace Tercuman.Mobile.Features.Dashboard.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage(DashboardViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}