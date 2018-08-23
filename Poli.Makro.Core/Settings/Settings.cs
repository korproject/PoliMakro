using Poli.Makro.Core.Database;
using System.Data.SQLite;

namespace Poli.Makro.Core
{
	public static class AppSettings
	{
		/// <summary>
		/// Load all app settings
		/// </summary>
		public static void LoadSettings()
		{
			using (var conn = new SQLiteConnection(Connection.ConnString))
			{
				conn.Open();

				using (var comm = new SQLiteCommand(conn))
				{
					comm.CommandText = "SELECT rowid, * FROM settings";

					using (var reader = comm.ExecuteReader())
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								// window state setting
								if (reader["title"].ToString() == "WindowState")
								{
									WindowState = Conv.Int(reader["setting"].ToString(), 0, 0, 3);
								}
								// window top most setting
								if (reader["title"].ToString() == "WindowTopMost")
								{
									WindowTopMost = Conv.Int(reader["setting"].ToString(), 0, 0, 2);
								}

								#region Window Coordinates

								// top
								if (reader["title"].ToString() == "WindowTop")
								{
									WindowTop = Conv.Double(reader["setting"].ToString(), 0);
								}
								// left
								if (reader["title"].ToString() == "WindowLeft")
								{
									WindowLeft = Conv.Double(reader["setting"].ToString(), 0);
								}
								// width
								if (reader["title"].ToString() == "WindowWidth")
								{
									WindowWidth = Conv.Double(reader["setting"].ToString(), 750);
								}
								// height
								if (reader["title"].ToString() == "WindowHeight")
								{
									WindowHeight = Conv.Double(reader["setting"].ToString(), 700);
								}

								#endregion
							}
						}
					}
				}

				conn.Close();
			}
		}


		/// <summary>
		/// Window state setting
		/// 0 = Minimized
		/// 1 = Normal
		/// 2 = Maximized
		/// 3 = Full Cover
		/// </summary>
		public static int WindowState { get; set; }

		/// <summary>
		/// WindowState setting saver
		/// </summary>
		public static void SaveWindowState()
		{
			using (var conn = new SQLiteConnection(Connection.ConnString))
			{
				conn.Open();

				using (var comm = new SQLiteCommand(conn))
				{
					comm.CommandText = "UPDATE settings SET setting=@setting WHERE title=@WindowState";
					comm.Parameters.AddWithValue("@setting", WindowState);
					comm.Parameters.AddWithValue("@WindowState", "WindowState");

					var rows = comm.ExecuteNonQuery();
				}

				conn.Close();
			}
		}

		/// <summary>
		/// Window top most setting
		/// </summary>
		public static int WindowTopMost { get; set; }

		/// <summary>
		/// Save window top most setting
		/// </summary>
		public static void SaveWindowTopMost()
		{
			using (var conn = new SQLiteConnection(Connection.ConnString))
			{
				conn.Open();

				using (var comm = new SQLiteCommand(conn))
				{
					comm.CommandText = "UPDATE settings SET setting=@setting WHERE title=@WindowTopMost";
					comm.Parameters.AddWithValue("@setting", WindowTopMost);
					comm.Parameters.AddWithValue("@WindowTopMost", "WindowTopMost");

					var rows = comm.ExecuteNonQuery();
				}

				conn.Close();
			}
		}


		public static double WindowTop { get; set; }
		public static double WindowLeft { get; set; }
		public static double WindowWidth { get; set; }
		public static double WindowHeight { get; set; }

		/// <summary>
		/// Save window location
		/// </summary>
		public static void SaveWindowLocation()
		{
			using (var conn = new SQLiteConnection(Connection.ConnString))
			{
				conn.Open();

				using (var comm = new SQLiteCommand(conn))
				{
					comm.CommandText = "UPDATE settings SET setting=@setting WHERE title=@WindowTopMost";
					comm.Parameters.AddWithValue("@setting", WindowTopMost);
					comm.Parameters.AddWithValue("@WindowTopMost", "WindowTopMost");
					var rows = comm.ExecuteNonQuery();

					comm.CommandText = "UPDATE settings SET setting=@setting WHERE title=@WindowTop";
					comm.Parameters.AddWithValue("@setting", WindowTop);
					comm.Parameters.AddWithValue("@WindowTop", "WindowTop");
					rows = comm.ExecuteNonQuery();

					comm.CommandText = "UPDATE settings SET setting=@setting WHERE title=@WindowLeft";
					comm.Parameters.AddWithValue("@setting", WindowLeft);
					comm.Parameters.AddWithValue("@WindowLeft", "WindowLeft");
					rows = comm.ExecuteNonQuery();

					comm.CommandText = "UPDATE settings SET setting=@setting WHERE title=@WindowHeight";
					comm.Parameters.AddWithValue("@setting", WindowHeight);
					comm.Parameters.AddWithValue("@WindowHeight", "WindowHeight");
					rows = comm.ExecuteNonQuery();

					comm.CommandText = "UPDATE settings SET setting=@setting WHERE title=@WindowWidth";
					comm.Parameters.AddWithValue("@setting", WindowWidth);
					comm.Parameters.AddWithValue("@WindowWidth", "WindowWidth");
					rows = comm.ExecuteNonQuery();
				}

				conn.Close();
			}
		}
	}
}
