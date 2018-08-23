using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Poli.Makro.Converters
{
	[Localizability(LocalizationCategory.NeverLocalize)]
	public class FirstCharacterConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
				if (value is string)
				{
					return ((string)value).Substring(0, 1).ToUpper();
				}
			}

			return "?";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
