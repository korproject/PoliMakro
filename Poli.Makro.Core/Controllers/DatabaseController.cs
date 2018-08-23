using Poli.Makro.Core.Database;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Poli.Makro.Core.Controllers
{
	/// <summary>
	/// Database controller class
	/// </summary>
	public class DatabaseController
	{
		public static bool DatabaseCheck()
		{
			// if the database file does not exist
			if (!File.Exists(Connection.DbPath))
			{
				// create new database file
				SQLiteConnection.CreateFile(Connection.DbPath);

				// and then check again file exists
				if (File.Exists(Connection.DbPath))
				{
					using (var conn = new SQLiteConnection(Connection.ConnString))
					{
						conn.Open();

						// create new updater table
						using (var commUpdater = new SQLiteCommand(conn))
						{
							commUpdater.CommandText = "CREATE TABLE `updater` ( `name` TEXT, `version` TEXT DEFAULT 0, `bit` TEXT, `deploy` TEXT, `lang` TEXT, `last_update` TEXT, `feedback` INTEGER DEFAULT 0 )";
							commUpdater.ExecuteNonQuery();
						}

						// insert default values
						using (var commDefault = new SQLiteCommand(conn))
						{
							commDefault.CommandText = "INSERT INTO updater (version, feedback) values(?,?)";
							commDefault.Parameters.Add("version", DbType.String).Value = "0.0.0.1";
							commDefault.Parameters.Add("feedback", DbType.String).Value = "1";
							commDefault.ExecuteNonQuery();
						}

						// create new updates table
						using (var commupdates = new SQLiteCommand(conn))
						{
							commupdates.CommandText = "CREATE TABLE `updates` ( `updateid` TEXT, `date` TEXT, `version` TEXT, `added_features` TEXT NOT NULL, `removed_features` TEXT NOT NULL, `reason_code` TEXT, `reason_title` TEXT )";
							commupdates.ExecuteNonQuery();
						}

						conn.Close();
					}
				}

				return false;
			}

			// already setup database
			return true;
		}
	}
}
