using System;
using System.Globalization;
using System.Windows.Data;

namespace Poli.Makro.Converters
{
    public class SideMenuItemColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Default Mat Color Blue Grey:300
            string ret = "#90A4AE";

            // Check valur null or string empty
            if (!string.IsNullOrEmpty(value?.ToString()))
            {
                // get value string lenght
                int vallenght = value.ToString().Length;

                // return color code
                if (vallenght >= 1 && vallenght <= 2)
                {
                    // Mat Color Red:500
                    ret = "#F44336";
                }
                else if (vallenght >= 3 && vallenght <= 5)
                {
                    // Mat Color Purple:300
                    ret = "#9575CD";
                }
                else if (vallenght >= 6 && vallenght <= 8)
                {
                    // Mat Color Blue:300
                    ret = "#64B5F6";
                }
                else if (vallenght >= 9 && vallenght <= 11)
                {
                    // Mat Color Blue:500
                    ret = "#2196F3";
                }
                else if (vallenght >= 12 && vallenght <= 14)
                {
                    // Mat Color Cyan:500
                    ret = "#00BCD4";
                }
                else if (vallenght >= 15 && vallenght <= 17)
                {
                    // Mat Color Light Green:500
                    ret = "#8BC34A";
                }
                else if (vallenght >= 18 && vallenght <= 20)
                {
                    // Mat Color Yellow:700
                    ret = "#FBC02D";
                }
                else if (vallenght >= 21 && vallenght <= 23)
                {
                    // Mat Color Orange:500
                    ret = "#FF9800";
                }
                else if (vallenght >= 24 && vallenght <= 25)
                {
                    // Mat Color Teal:500
                    ret = "#009688";
                }
                else if (vallenght >= 26 && vallenght <= 28)
                {
                    // Mat Color Amber:500
                    ret = "#FFC107";
                }
                else if (vallenght >= 29 && vallenght <= 31)
                {
                    // Mat Color Deep Purple:500
                    ret = "#673AB7";
                }
                else if (vallenght > 32)
                {
                    // Mat Color Blue:800
                    ret = "#1565C0";
                }
            }

            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string ret = string.Empty;
            if (value != null)
            {
                ret = value.ToString();
            }

            return ret;
        }
    }
}
