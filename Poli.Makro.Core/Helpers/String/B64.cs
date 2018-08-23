using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poli.Makro.Core.Helpers.String
{
    public class B64
    {

        /// <summary>
        /// Basic base64 converter
        /// </summary>
        /// <param name="content">sended content</param>
        /// <param name="type">encode(0)/decode(1) type</param>
        /// <returns></returns>
        public static string Base64Engine(string content, int type = 0)
        {
            string ret = string.Empty;

            // encode
            if (type == 0)
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(content);
                ret = Convert.ToBase64String(plainTextBytes);
            }

            // decode
            if (type == 1)
            {
                var base64EncodedBytes = Convert.FromBase64String(content);
                ret = Encoding.UTF8.GetString(base64EncodedBytes);
            }

            return ret;
        }
    }
}
