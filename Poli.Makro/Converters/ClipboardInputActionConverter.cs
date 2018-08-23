using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;

namespace Poli.Makro.Converters
{
    [ValueConversion(typeof(bool), typeof(ScrollBarVisibility))]
    sealed class ClipboardInputActionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var myResourceDictionary = new ResourceDictionary();
                myResourceDictionary.Source = new Uri("pack://application:,,,/Poli.Makro;component/UICollection/Icons.xaml", UriKind.RelativeOrAbsolute);

                if (value as string != "Mouse L. Click")
                {
                    if (myResourceDictionary["Keyboard"] is Path path) return path.Data;
                } else if (value as string == "Mouse L. Click")
                {
                    if (myResourceDictionary["Mouse"] is Path path) return path.Data;
                } else
                {
                    if (myResourceDictionary["Input"] is Path path) return path.Data;
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
