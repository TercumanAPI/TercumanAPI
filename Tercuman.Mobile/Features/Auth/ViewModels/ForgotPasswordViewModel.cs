using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace Tercuman.Mobile.Features.Auth.ViewModels
{
    public partial class ForgotPasswordViewModel
    {
        [RelayCommand]
        async Task GoBack()
        {
            // Giriş sayfasına geri döner
            await global::Microsoft.Maui.Controls.Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
