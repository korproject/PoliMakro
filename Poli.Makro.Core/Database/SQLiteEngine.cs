using Poli.Makro.Core.Helpers.String;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poli.Makro.Core.Database
{
    public static class SQLiteEngine
    {
        public static List<List<string>> Select(string table, SQLParameters sqlparameters, SQLParameters where)
        {
            try
            {
                if (!string.IsNullOrEmpty(table) && sqlparameters != null)
                {
                    #region SQL Parameters Check Point

                    if (sqlparameters.Parameters is string || sqlparameters.Values is string)
                    {
                        sqlparameters = CheckParamValues(sqlparameters);
                    }

                    if (((List<string>)sqlparameters.Parameters).Count != ((List<string>)sqlparameters.Values).Count)
                    {
                        return null;
                    }

                    #endregion

                    #region WHERE Check Point

                    if (where != null)
                    {
                        if (where.Parameters is string || where.Values is string)
                        {
                            where = CheckParamValues(where);
                        }

                        if (((List<string>)where.Parameters).Count != ((List<string>)where.Values).Count)
                        {
                            return null;
                        }
                    }

                    #endregion
                    List<List<string>> rows = new List<List<string>>();

                    using (var conn = new SQLiteConnection(Connection.ConnString))
                    {
                        conn.Open();

                        using (var comm = new SQLiteCommand(conn))
                        {
                            comm.CommandText = $"SELECT {Common.Implode(",", (List<string>)sqlparameters.Parameters)} FROM {table}";
                            comm.CommandText += where != null ? $" WHERE {Common.Implode(" AND ", (List<string>)where.Parameters)}" : "";

                            //int i = 0;
                            //foreach (var parameter in (List<string>)sqlparameters.Parameters)
                            //{
                            //    comm.Parameters.AddWithValue($"@{parameter}", ((List<string>)sqlparameters.Values)[i]);
                            //}

                            if (where != null)
                            {
                                int ii = 0;
                                foreach (var parameter in (List<string>)where.Parameters)
                                {
                                    comm.Parameters.AddWithValue($"@{parameter}", ((List<string>)where.Values)[ii++]);
                                }
                            }

                            using (var reader = comm.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    List<string> items = new List<string>();

                                    foreach (var parameter in ((List<string>)sqlparameters.Parameters))
                                    {
                                        items.Add(reader[parameter.Replace(" ", "")].ToString());
                                    }

                                    if (items != null)
                                    {
                                        rows.Add(items);
                                    }
                                    //items.Clear();
                                }
                            }
                        }

                        conn.Close();
                    }

                    return rows;
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp);
            }

            return null;
        }

        private static SQLParameters CheckParamValues(SQLParameters sqlparameters)
        {
            sqlparameters.Parameters = Common.Explode(',', (string)sqlparameters.Parameters);

            if (sqlparameters.Values is string)
            {
                sqlparameters.Values = Common.Explode(',', (string)sqlparameters.Values);
            }

            return sqlparameters;
        }
    }


    public class SQLParameters
    {
        public object Parameters { get; set; }
        public object Values { get; set; }
    }
}
