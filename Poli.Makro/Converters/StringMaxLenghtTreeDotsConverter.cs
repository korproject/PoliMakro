using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace Poli.Makro.Converters
{
    [ValueConversion(typeof(bool), typeof(ScrollBarVisibility))]
    sealed class StringMaxLenghtTreeDotsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !string.IsNullOrEmpty((string) value)
                ? (((string) value).Length >= 32 ? ((string) value).Substring(0, 32) + "..." : (string) value)
                : string.Empty;


            //var parameterString = parameter as string;
            //if (string.IsNullOrEmpty(parameterString)) return string.Empty;
            //var parameters = parameterString.Split('|');

            //if (string.IsNullOrEmpty(parameters[0]) || string.IsNullOrEmpty(parameters[1])) return string.Empty;
            //if (!int.TryParse(parameters[1], out var i)) return string.Empty;
            //return parameters[0].Length >= i ? parameters[0].Substring(0, i) + "..." : parameters[0];

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
