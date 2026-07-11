using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Tercuman.Mobile.Shared.Converters;

public class IntToBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int currentStep && parameter is string target)
        {
            // 'not1' parametresi 1 dışındaki her durumda true döner (Geri butonu için)
            if (target == "not1") return currentStep > 1;
            // 'not3' parametresi 3 dışındaki her durumda true döner (İleri butonu için)
            if (target == "not3") return currentStep < 3;

            // Sayfa görünürlüğü için: Adım parametreye eşitse göster
            return currentStep == int.Parse(target);
        }
        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}