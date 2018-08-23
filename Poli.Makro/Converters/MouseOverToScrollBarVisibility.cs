using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace Poli.Makro.Converters
{
    [ValueConversion(typeof(bool), typeof(ScrollBarVisibility))]
    sealed class MouseOverToScrollBarVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((bool)value) ? ScrollBarVisibility.Auto : ScrollBarVisibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
