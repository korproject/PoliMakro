using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Newtonsoft.Json.Linq;

namespace Poli.Makro.Converters.JSON
{
    public sealed class JValueTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
	        if (!(value is JValue jValue)) return value;
	        switch (jValue.Type)
	        {
		        case JTokenType.String:
			        return new BrushConverter().ConvertFrom("#e89f51");
		        case JTokenType.Float:
		        case JTokenType.Integer:
			        return new BrushConverter().ConvertFrom("#ffe677");
		        case JTokenType.Boolean:
			        return new BrushConverter().ConvertFrom("#53ef94");
		        case JTokenType.Null:
			        return new BrushConverter().ConvertFrom("#cad1cd");
	        }

	        return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException(GetType().Name + " can only be used for one way conversion.");
        }
    }
}
