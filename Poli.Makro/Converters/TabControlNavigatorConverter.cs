using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;

namespace Poli.Makro.Converters
{
    [ValueConversion(typeof(bool), typeof(ScrollBarVisibility))]
    class TabControlNavigatorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                // get as tabcontrol
                var tabControl = (TabControl)value;

                // get icons resource dictionary
                var resourceDictionary = new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/Poli.Makro;component/UICollection/Icons.xaml", UriKind.RelativeOrAbsolute)
                };

                // default icon
                var defaultIcon = resourceDictionary["Select"] is Path path ? path : null;

                if (tabControl.Items.Count == 1)
                {
                    return defaultIcon;
                }
                else if (tabControl.Items.Count > 1 && tabControl.SelectedIndex == 0)
                {
                    return resourceDictionary["ArrowDown"] is Path ? (Path)resourceDictionary["ArrowDown"] : defaultIcon;
                }
                else if (tabControl.Items.Count > 1 && tabControl.SelectedIndex == tabControl.Items.Count)
                {
                    return resourceDictionary["ArrowUp"] is Path ? (Path)resourceDictionary["ArrowUp"] : defaultIcon;
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