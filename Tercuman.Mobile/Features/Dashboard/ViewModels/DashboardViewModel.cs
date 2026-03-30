using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tercuman.Mobile.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Tercuman.Mobile.Features.Dashboard.ViewModels;

public partial class DashboardViewModel : BaseViewModel
{
    public DashboardViewModel()
    {
        Title = "Gösterge Paneli";
    }
    
    [RelayCommand]
    async Task GoToCreateAd()
    {
        // Kaydettiğimiz rota ismiyle sayfaya gidiyoruz
        await global::Microsoft.Maui.Controls.Shell.Current.GoToAsync("CreateAdPage");
    }
}
