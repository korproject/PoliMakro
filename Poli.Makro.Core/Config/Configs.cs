using System;
using System.Diagnostics;

namespace Poli.Makro.Core
{
    public class Configs
    {
        public Configs()
        {
        }

        public static string ConnString = string.Empty;

        public static string SelectedTabHeader { get; set; }
        public static string SelectedSubTabHeader { get; set; }
        public static string Title = $"Poli Makro - {SelectedTabHeader} > {SelectedSubTabHeader}";

		public static readonly string API_KEY = "A468ABF7CC032230D68DE5792360A50C0BB118EAB8214041F59C5D7FA17956F12E4247EE52390CDC08771F391E2E2D9A7D90";
		public static readonly string API_SECRET = "b5efe28bd1f96cf446b6c966fafc86e206c6bf18f8af1ac21c48ef7d7e2ac4fced9fb6d9d99ad5cd6f43702d385fa8e03b2b2f9c0880c661b5491225adf75752";
    }
}
