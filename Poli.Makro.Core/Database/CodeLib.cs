using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poli.Makro.Core.Database
{
    public class CodeLib
    {
        public static string GetCode(long rowid)
        {
            try
            {
                using (var conn = new SQLiteConnection(Connection.ConnString))
                {
                    conn.Open();

                    using (var comm = new SQLiteCommand(conn))
                    {
                        comm.CommandText = "SELECT code FROM code_lib_codes WHERE rowid='" + rowid + "'";
                        Debug.WriteLine(comm.CommandText);

                        using (var reader = comm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return reader["code"].ToString();
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
