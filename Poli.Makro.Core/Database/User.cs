using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.Globalization;

namespace Poli.Makro.Core.Database
{
    public class User
    {
		/// <summary>
		/// Get logged in user info
		/// </summary>
		public static UserInfo GetUserInfo()
		{
			using (var conn = new SQLiteConnection(Connection.ConnString))
			{
				conn.Open();

				UserInfo userInfo = new UserInfo();

				using (var comm = new SQLiteCommand(conn))
				{
					comm.CommandText = "SELECT * FROM users WHERE active='1'";

					using (var reader = comm.ExecuteReader())
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								userInfo.UserId = Convert.ToInt64(reader["userid"].ToString());
								userInfo.UserName = reader["username"].ToString();
								userInfo.Token = reader["token"].ToString();
								userInfo.TokenExpire = DateTime.ParseExact(reader["token_expire"].ToString(), "dd-MM-yyyy HH':'mm':'ss", CultureInfo.InvariantCulture);
								userInfo.UserImage = reader["user_image"].ToString();
							}
						}
					}
				}

				conn.Close();

				return userInfo;
			}
		}

		/// <summary>
		/// Getting active user id
		/// </summary>
		/// <returns></returns>
		public static string GetUserId()
        {
            using (var conn = new SQLiteConnection(Connection.ConnString))
            {
                conn.Open();

                using (var comm = new SQLiteCommand(conn))
                {
                    comm.CommandText = "SELECT userid FROM users WHERE active='1'";

                    using (var reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader["userid"].ToString();
                        }
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Get user token
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static string GetUserToken(string userid)
        {
            try
            {
                using (var conn = new SQLiteConnection(Connection.ConnString))
                {
                    conn.Open();

                    using (var comm = new SQLiteCommand(conn))
                    {
                        comm.CommandText = "SELECT token FROM users WHERE userid='" + userid + "'";

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

        /// <summary>
        /// Saves or updates username, surid, token and expire
        /// </summary>
        /// <param name="username"></param>
        /// <param name="userid"></param>
        /// <param name="token"></param>
        /// <param name="expire"></param>
        /// <returns></returns>
        public static bool SaveUserToken(string userid, string username, string token, string expire, string image)
        {
            try
            {
                using (var conn = new SQLiteConnection(Connection.ConnString))
                {
                    conn.Open();

                    using (var comm = new SQLiteCommand(conn))
                    {
                        comm.CommandText = "SELECT rowid FROM users WHERE userid='" + userid + "'";

                        using (var reader = comm.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                using (var commup = new SQLiteCommand(conn))
                                {
                                    commup.CommandText = "UPDATE users SET token=@token, token_expire=@expire, user_image=@userimage, active='1' WHERE userid='" + userid + "'";
									commup.Parameters.AddWithValue("@token", token);
                                    commup.Parameters.AddWithValue("@expire", expire);
									commup.Parameters.AddWithValue("@userimage", image);

									var rows = commup.ExecuteNonQuery();
                                    if (rows > 0)
                                        return true;

                                    UnsetActiveUser(userid);
                                }
                            }
                            else
                            {
                                using (var commin = new SQLiteCommand(conn))
                                {
                                    commin.CommandText = "INSERT INTO users (userid, username, token, token_expire, active, user_image) values(?,?,?,?,?,?)";

                                    commin.Parameters.AddWithValue("@0", userid);
                                    commin.Parameters.AddWithValue("@1", username);
                                    commin.Parameters.AddWithValue("@2", token);
                                    commin.Parameters.AddWithValue("@3", expire);
                                    commin.Parameters.AddWithValue("@4", "1");
									commin.Parameters.AddWithValue("@5", image);

									var rows = commin.ExecuteNonQuery();
                                    if (rows > 0)
                                        return true;

                                    UnsetActiveUser(userid);
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp);
            }
            return false;
        }

        /// <summary>
        /// Unset active user
        /// </summary>
        /// <param name="userid"></param>
        private static void UnsetActiveUser(string userid)
        {
            using (var conn = new SQLiteConnection(Connection.ConnString))
            {
                conn.Open();

                using (var comm = new SQLiteCommand(conn))
                {
                    comm.CommandText = "SELECT * FROM users WHERE active='1'";

                    using (var reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (reader["userid"].ToString() != userid)
                                {
                                    using (var commup = new SQLiteCommand(conn))
                                    {
                                        commup.CommandText = "UPDATE users SET active='0' WHERE userid='" + reader["userid"] + "'";

                                        var rows = commup.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

		public static bool LogOutUser()
		{
			using (var conn = new SQLiteConnection(Connection.ConnString))
			{
				conn.Open();

				using (var comm = new SQLiteCommand(conn))
				{
					comm.CommandText = "SELECT * FROM users WHERE active='1'";

					using (var reader = comm.ExecuteReader())
					{
						if (reader.HasRows)
						{
							while (reader.Read())
							{
								using (var commup = new SQLiteCommand(conn))
								{
									commup.CommandText = "UPDATE users SET active='0' WHERE userid='" + reader["userid"] + "'";

									var rows = commup.ExecuteNonQuery();

									if (rows > 0)
									{
										return true;
									}
								}
							}
						}
					}
				}
			}

			return false;
		}
	}

	public class UserInfo
	{
		public long UserId { get; set; }
		public string UserName { get; set; }
		public string Token { get; set; }
		public DateTime TokenExpire { get; set; }
		public string UserImage { get; set; }
	}
}
