using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Poli.Makro.Core.ClipboardManager.Clipboard;
using Poli.Makro.Core.ClipboardManager.Hooks;
using Poli.Makro.Core.Database;
using Poli.Makro.Core.ViewModel.Base;

namespace Poli.Makro.Core.ViewModel.ClipboardManager
{
    public class Clipboard : BaseViewModel
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Clipboard()
        {
            ClipboardDatabaseProcesses.GetKeyLocks();

            SetKey = new RelayParameterizedCommand(SetKeyValue);
            Keyx = "x";
            Keyc = "c";
            Keyv = "v";
            Keylshift = "lshift";

            SetButton = new RelayParameterizedCommand(SetButtonValue);
            Mouseltext = "text";
            Mouselimage = "image";

            Tag = "Bu listede henüz bir içerik bulunmuyor, eklendiğinde görüntüleyebileceksiniz.";
        }

        public string Keyx { get; set; }
        public static bool KeyX { get; set; }

        public string Keyc { get; set; }
        public static bool KeyC { get; set; }

        public string Keyv { get; set; }
        public static bool KeyV { get; set; }

        public string Keylshift { get; set; }
        public static bool KeyLShift { get; set; }

        public ICommand SetKey { get; set; }

        public void SetKeyValue(object parameter)
        {
            var values = (object[])parameter;
            ClipboardDatabaseProcesses.SetKeyValue("key_" + values[0], values[1] as bool? ?? false);

            ClipboardEnviroment.Hooker();
        }

        public static bool MouseRL { get; set; }

        public static string Mouseltext { get; set; }
        public static bool MouseRLText { get; set; }

        public static string Mouselimage { get; set; }
        public static bool MouseRLImage { get; set; }

        public static string Textselection { get; set; }
        public static bool TextSelection { get; set; }

        public ICommand SetButton { get; set; }

        public void SetButtonValue(object parameter)
        {
            var values = (object[])parameter;
            ClipboardDatabaseProcesses.SetKeyValue("mouse_rl_" + values[0], values[1] as bool? ?? false);

            if (MouseRLText == false && MouseRLImage == false)
            {
                MouseRL = false;
                ClipboardDatabaseProcesses.SetKeyValue("mouse_rl", false);
            } else if (MouseRL == false && MouseRLText || MouseRLImage)
            {
                MouseRL = true;
                ClipboardDatabaseProcesses.SetKeyValue("mouse_rl", true);
            }

            ClipboardEnviroment.Hooker();
        }

        public static int ContentCount = 0;

        public string Tag { get; set; }

        public string StatusText { get; set; }
    }
}
