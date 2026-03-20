using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tercuman.Mobile.Services
{
    public class NavigationService
    {
        public async Task GoToAsync(string route)
        {
            await Shell.Current.GoToAsync(route);
        }
    }
}
