using KOR.Updater.Core;
using Poli.Makro.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Poli.Makro.Core.Database
{
	public class Updater
	{
		/// <summary>
		/// Get app version for update checks
		/// </summary>
		/// <returns></returns>
		public string GetAppVersion()
		{
			// if there is not an database
			if (!DatabaseController.DatabaseCheck())
			{
				// return null
				return string.Empty;
			}

			// else get content
			using (var conn = new SQLiteConnection(Connection.ConnString))
			{
				conn.Open();

				using (SQLiteCommand comm = new SQLiteCommand("SELECT * FROM updater WHERE rowid=1", conn))
				{
					using (SQLiteDataReader reader = comm.ExecuteReader())
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								return !string.IsNullOrEmpty(reader["version"].ToString()) ? reader["version"].ToString() : "0";
							}
						}
					}
				}

				conn.Close();
			}

			return string.Empty;
		}

		/// <summary>
		/// Save some last update info
		/// </summary>
		public bool UpdateVersionString(string newversion, string updateid, string afeatures = null, string rfeatures = null, string reasoncode = null, string reasontitle = null)
		{
			// if there is not an database
			if (!DatabaseController.DatabaseCheck())
			{
				// return null
				return false;
			}

			using (var conn = new SQLiteConnection())
			{
				conn.ConnectionString = Connection.ConnString;
				conn.Open();

				using (var comm = new SQLiteCommand(conn))
				{
					// updates app current version, set last update id and review reset
					comm.CommandText = "UPDATE updater SET version=:version, last_update=:last_update, feedback=:feedback WHERE rowid=1";
					comm.Parameters.Add("version", DbType.String).Value = newversion;
					comm.Parameters.Add("last_update", DbType.String).Value = updateid;
					comm.Parameters.Add("feedback", DbType.Int32).Value = "0";
					var rows = comm.ExecuteNonQuery();

					// if update successful
					if (rows > 0)
					{
						using (var commupdates = new SQLiteCommand(conn))
						{
							// add update info
							commupdates.CommandText = "INSERT INTO updates (updateid, date, version, added_features, removed_features, reason_code, reason_title) values(?,?,?,?,?,?,?)";
							commupdates.Parameters.Add("updateid", DbType.String).Value = updateid;
							commupdates.Parameters.Add("date", DbType.String).Value = DateTime.UtcNow;
							commupdates.Parameters.Add("version", DbType.String).Value = newversion;
							commupdates.Parameters.Add("afeatures", DbType.String).Value = afeatures;
							commupdates.Parameters.Add("rfeatures", DbType.String).Value = rfeatures;
							commupdates.Parameters.Add("reasoncode", DbType.String).Value = reasoncode;
							commupdates.Parameters.Add("reasontitle", DbType.String).Value = reasontitle;

							rows = commupdates.ExecuteNonQuery();

							return rows > 0 ? true : false;
						}
					}

					return false;
				}
			}
		}

		/// <summary>
		/// Get last update id for review
		/// </summary>
		/// <returns></returns>
		public string GetLastUpdateId()
		{
			// if there is not an database
			if (!DatabaseController.DatabaseCheck())
			{
				// return null
				return string.Empty;
			}

			// else get content
			using (var conn = new SQLiteConnection(Connection.ConnString))
			{
				conn.Open();

				using (SQLiteCommand comm = new SQLiteCommand("SELECT * FROM updater WHERE rowid=1", conn))
				{
					using (SQLiteDataReader reader = comm.ExecuteReader())
					{
						while (reader.Read())
						{
							if (!string.IsNullOrEmpty(reader["feedback"].ToString()))
							{
								if (reader["feedback"].ToString() == "0")
								{
									return !string.IsNullOrEmpty(reader["last_update"].ToString()) ? reader["last_update"].ToString() : string.Empty;
								}
							}
						}
					}
				}

				conn.Close();
			}

			return string.Empty;
		}

		/// <summary>
		/// Update feedback value after send
		/// </summary>
		public bool UpdatedFeedback()
		{
			// if there is not an database
			if (!DatabaseController.DatabaseCheck())
			{
				// return null
				return false;
			}

			using (var conn = new SQLiteConnection())
			{
				conn.ConnectionString = Connection.ConnString;
				conn.Open();

				using (var comm = new SQLiteCommand(conn))
				{
					// updates app current version, set last update id and review reset
					comm.CommandText = "UPDATE updater SET feedback=:feedback WHERE rowid=1";
					comm.Parameters.Add("feedback", DbType.Int32).Value = "1";
					var rows = comm.ExecuteNonQuery();

					return rows > 0 ? true : false;
				}
			}
		}

		/// <summary>
		/// Get last successfull updates
		/// </summary>
		/// <returns></returns>
		public List<Update> GetLastUpdates()
		{
			// if there is not an database
			if (!DatabaseController.DatabaseCheck())
			{
				// return null
				return null;
			}

			// else get content
			using (var conn = new SQLiteConnection(Connection.ConnString))
			{
				conn.Open();

				using (SQLiteCommand comm = new SQLiteCommand("SELECT * FROM updates", conn))
				{
					using (SQLiteDataReader reader = comm.ExecuteReader())
					{
						if (reader.HasRows)
						{
							List<Update> updates = new List<Update>();
							while (reader.Read())
							{
								Update update = new Update()
								{
									UpdateId = reader["updateid"].ToString(),
									AddedDate = reader["date"].ToString(),
									AppVersion = reader["version"].ToString(),
									AddedFeatures = reader["added_features"].ToString(),
									RemovedFeatures = reader["removed_features"].ToString(),
									ReasonCode = reader["reason_code"].ToString(),
									ReasonTitle = reader["reason_title"].ToString()
								};

								updates.Add(update);
							}

							return updates;
						}
					}
				}

				conn.Close();
			}

			return null;
		}
	}
}
