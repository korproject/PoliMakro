using System;
using System.Data.SQLite;
using System.Diagnostics;

namespace Poli.Makro.Core.Database
{
    public class App
    {
        /// <summary>
        /// Get any application info
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object GetAppInfo(string parameters)
        {
            try
            {
                using (var conn = new SQLiteConnection(Connection.ConnString))
                {
                    conn.Open();

                    using (var comm = new SQLiteCommand(conn))
                    {
                        comm.CommandText = $"SELECT {parameters} FROM application";

                        using (var reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return reader["token"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp);
            }

            return string.Empty;
        }
    }
}
