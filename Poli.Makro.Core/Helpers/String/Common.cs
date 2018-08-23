using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poli.Makro.Core.Helpers.String
{
    public class Common
    {
        public static string Implode(string delimiter, List<string> list)
        {
            return !string.IsNullOrEmpty(delimiter) && list != null ? System.String.Join(delimiter, list) : null;
        }

        public static List<string> Explode(char delimiter, string list)
        {
            return delimiter != null && !string.IsNullOrEmpty(list) ? list.Split(delimiter).ToList() : null;
        }

        public static string GetUniqueString()
        {
            Guid guid = Guid.NewGuid();
            return Convert.ToBase64String(guid.ToByteArray()).Replace("=", "").Replace("+", "");
        }
    }
}
