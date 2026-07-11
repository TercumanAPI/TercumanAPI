using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Tercuman.Mobile.Shared.Converters;

public class IngoingToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool isIncoming)
        {
            // Gelen mesaj (isIncoming = true) -> Gri/Mavi (Sohbet tonu)
            // Giden mesaj (isIncoming = false) -> Ana Mor/Mavi rengimiz
            return isIncoming ? Color.Parse("#94A3B8") : Color.Parse("#6366F1");
        }
        return Color.Parse("#6366F1");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
}