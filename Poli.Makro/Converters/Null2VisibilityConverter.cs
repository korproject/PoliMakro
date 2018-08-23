using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Poli.Makro.Converters
{
    [Localizability(LocalizationCategory.NeverLocalize)]
    public class Null2VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return Visibility.Visible;
            }

            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
