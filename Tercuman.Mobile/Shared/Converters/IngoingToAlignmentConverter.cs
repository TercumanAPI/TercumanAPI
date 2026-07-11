using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Tercuman.Mobile.Shared.Converters;

public class IngoingToAlignmentConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool isIncoming)
        {
            // Gelen mesajsa Sola (Start), biz gönderdiysek Sağa (End) yasla
            return isIncoming ? LayoutOptions.Start : LayoutOptions.End;
        }
        return LayoutOptions.Start;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}