using System;
using System.Diagnostics;
using System.IO;

namespace Poli.Makro.Core.ClipboardManager.Controllers
{
    public class FileFolderController
    {
        public static string ExePath = AppDomain.CurrentDomain.BaseDirectory;
        public static string ClipboardDir = ExePath + "Clipboard\\";
        public static string ImagesDir = ClipboardDir + "Images\\";

        public static void CheckDirs()
        {

        }

        public static bool CreateDir(string dir)
        {
            bool ret = false;

            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                ret = true;
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp);
            }

            return ret;
        }
    }
}
