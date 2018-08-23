using System.Data.SQLite;
using Poli.Makro.Core.Database;

namespace Poli.Makro.Core.ClipboardManager.Clipboard
{
    public class ClipboardDatabaseProcesses
    {
        /// <summary>
        /// Getting key lock values from database
        /// </summary>
        public static void GetKeyLocks()
        {
            using (SQLiteConnection conn = new SQLiteConnection(Connection.ConnString))
            {
                conn.Open();

                using (SQLiteCommand comm = new SQLiteCommand(conn))
                {
                    comm.CommandText = "SELECT * FROM clipboard_settings WHERE rowid='1'";

                    using (SQLiteDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // keyboard keys
                            ViewModel.ClipboardManager.Clipboard.KeyX = int.Parse(reader["key_x"].ToString()) != 0;
                            ViewModel.ClipboardManager.Clipboard.KeyC = int.Parse(reader["key_c"].ToString()) != 0;
                            ViewModel.ClipboardManager.Clipboard.KeyV = int.Parse(reader["key_v"].ToString()) != 0;
                            ViewModel.ClipboardManager.Clipboard.KeyLShift = int.Parse(reader["key_lshift"].ToString()) != 0;

                            // mouse buttons
                            ViewModel.ClipboardManager.Clipboard.MouseRL = int.Parse(reader["mouse_rl"].ToString()) != 0;
                            ViewModel.ClipboardManager.Clipboard.MouseRLText = int.Parse(reader["mouse_rl_text"].ToString()) != 0;
                            ViewModel.ClipboardManager.Clipboard.MouseRLImage = int.Parse(reader["mouse_rl_image"].ToString()) != 0;
                        }
                    }
                }
            }
        }

        public static void SetKeyValue(string column, bool value)
        {
            using (SQLiteConnection conn = new SQLiteConnection(Connection.ConnString))
            {
                conn.Open();

                using (SQLiteCommand comm = new SQLiteCommand(conn))
                {
                    comm.CommandText = "UPDATE clipboard_settings SET " + column + "=@parm1 WHERE rowid='1'";
                    comm.Parameters.AddWithValue("@parm1", value);

                    var rows = comm.ExecuteNonQuery();
                }
            }
        }
    }
}