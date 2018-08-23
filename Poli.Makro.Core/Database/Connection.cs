using System;

namespace Poli.Makro.Core.Database
{
    public class Connection
    {
        private static readonly string ExePath = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string DbPath = ExePath + "Poli.Makro.db";
        public static readonly string ConnString = @"Data Source=" + DbPath + "; Version=3;";
    }
}
