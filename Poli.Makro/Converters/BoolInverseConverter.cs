using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Poli.Makro.Converters
{
    [Localizability(LocalizationCategory.NeverLocalize)]
    public class BoolInverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = value is bool;
            return !val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool;
        }
    }
}
