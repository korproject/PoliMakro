using System;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace Poli.Makro.Core.Controllers
{
    /// <summary>
    /// InternetController contains
    /// </summary>
    public class InternetController
    {
        [DllImport("wininet.dll")]
        public static extern bool InternetGetConnectedState(ref InternetConnectionState lpdwFlags, int dwReserved);
        public enum InternetConnectionState : int
        {
            INTERNET_CONNECTION_OFFLINE = 0x20,
            INTERNET_CONNECTION_CONFIGURED = 0x40
        }

        /// <summary>
        /// Internet connection check
        /// </summary>
        /// <returns>bool value</returns>
        public static bool InternetCheck()
        {
            InternetConnectionState connection = 0;
            bool state = (connection & InternetConnectionState.INTERNET_CONNECTION_CONFIGURED) != 0;
            return InternetGetConnectedState(ref connection, 0);
        }
    }
}
