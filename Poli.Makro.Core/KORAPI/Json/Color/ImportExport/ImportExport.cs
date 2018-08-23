using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poli.Makro.Core.Json.Color.ImportExport
{
    public class RootobjectforColorImportExport
    {
        public string title { get; set; }
        public Color[] colors { get; set; }
    }

    public class Color
    {
        public string title { get; set; }
        public string hex { get; set; }
    }
}
