using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Poli.Makro.Converters
{
	[Localizability(LocalizationCategory.NeverLocalize)]
	public class Selection2VisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is int index)
			{
				if (index > 0)
				{
					return Visibility.Visible;
				}
			}

			return Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is Visibility visibility && visibility == Visibility.Visible)
			{
				return false;
			}
			return true;
		}
	}
}
