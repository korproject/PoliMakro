using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Poli.Makro.Core.Database;
using Poli.Makro.Core.ViewModel.Base;
using Poli.Makro.Core.ViewModel.Color;

namespace Poli.Makro.Core.ViewModel.Code
{
    public class Code : BaseViewModel
    {
        public Code()
        {
            CodeGroups = new ObservableCollection<CodeGroups>();
            ColorGroups = new ObservableCollection<ColorGroups>();

            AddCodeComm = new RelayParameterizedCommand(async parameter => await AddCode(parameter));
            AddCodeIsEnabled = true;
            AddCodeDesc = "Bu kısma kod bloğu hakkında küçük bir not veya URL adersi eklenebilir.";
            AddCodeText = "Bu kısma kod bloğu gelecek.";
            AddCodeExpanderIsExpanded = true;


            AddGroupComm = new RelayParameterizedCommand(async parameter => await AddGroup(parameter));
            AddGroupIsEnabled = true;
            AddGroupDesc = "Kod grubunun içeriği ile ilgili birkaç şey yazılabilir.";


            AddLangComm = new RelayParameterizedCommand(async parameter => await AddLang(parameter));
            AddLangIsEnabled = true;
            AddLangDesc = "Eklenecek dil hakkında bir açıklama eklenebilir.";

            CodeLangs = new ObservableCollection<CodeLangs>();
            LoadLangs();

            CodeListSelectionChangedComm = new RelayParameterizedCommand(SetCode);
            LangSelectedChanged = new RelayParameterizedCommand(async parameter => await SeletAndLoadLangs());

            GroupSetStarComm = new RelayParameterizedCommand(async parameter => await GroupSetStar(parameter));
            DeleteCodeComm = new RelayParameterizedCommand(DeleteCode);
            DeleteGroupComm = new RelayParameterizedCommand(DeleteGroup);
            CodeSetStarComm = new RelayParameterizedCommand(async parameter => await CodeSetStar(parameter));

            UpdateCodeComm = new RelayParameterizedCommand(parameter => UpdateCode(parameter));

            ReloadColors = new RelayParameterizedCommand(async parameter => await LoadColors());
        }

        public string Status { get; set; }

        public ObservableCollection<ColorGroups> ColorGroups { get; set; }

        public ColorGroups SelectedColorGroup { get; set; }
        public Color.CoColor SelectedColor { get; set; }

        #region Code, Group, And Lists

        public ObservableCollection<CodeGroups> CodeGroups { get; set; }
        public ObservableCollection<CodeLangs> CodeLangs { get; set; }

        #endregion

        #region Add Group Constructors

        public string AddGroupDesc { get; set; }
        public CodeGroups SelectedCodeGroup { get; set; }

        #endregion

        public string AddCodeDesc { get; set; }
        public string AddCodeText { get; set; }
        public bool AddCodeIsEnabled { get; set; }
        public ICommand AddCodeComm { get; set; }
        public bool AddCodeExpanderIsExpanded { get; set; }
        public async Task AddCode(object parameter)
        {
            try
            {
                Status = "";

                if (SelectedLang == null)
                {
                    Status = "Kod'un kaydedilebilmesi için bir dil seçilmelidir.";
                    return;
                }
                if (SelectedCodeGroup == null)
                {
                    Status = "Kod'un kaydedilebilmesi için bir grup seçilmelidir.";
                    return;
                }

				using (var conn = new SQLiteConnection(Connection.ConnString))
				{
					conn.Open();

					AddCodeIsEnabled = false;

					using (var comm = new SQLiteCommand(conn))
					{
						comm.CommandText = "INSERT INTO code_lib_codes (userid, title, desc, desc_prev, code, code_prev, date, groupid, lenght, color, invert_color, langid) values(?,?,?,?,?,?,?,?,?,?,?,?)";

						comm.Parameters.AddWithValue("@userid", User.GetUserId());
						comm.Parameters.AddWithValue("@title", (string)parameter);
						comm.Parameters.AddWithValue("@desc", !string.IsNullOrEmpty(AddCodeDesc) ? AddCodeDesc : string.Empty);
						comm.Parameters.AddWithValue("@desc_prev", AddCodeDesc.Length >= 200 ? AddCodeDesc.Substring(0, 200) : AddCodeDesc);
						comm.Parameters.AddWithValue("@code", !string.IsNullOrEmpty(AddCodeText) ? AddCodeText : string.Empty);
						comm.Parameters.AddWithValue("@code_prev", AddCodeText.Length >= 300 ? AddCodeText.Substring(0, 300) : AddCodeText);
						comm.Parameters.AddWithValue("@date", DateTime.Now.ToString("dd-MM-yyyy HH':'mm':'ss"));
						comm.Parameters.AddWithValue("@groupid", SelectedCodeGroup.RowId);
						comm.Parameters.AddWithValue("@lenght", !string.IsNullOrEmpty(AddCodeText) ? AddCodeText.Length : 0);
						comm.Parameters.AddWithValue("@color", SelectedColor.HexCode != null ? SelectedColor.HexCode : "#FFE53935");
						comm.Parameters.AddWithValue("@invert_color", SelectedColor.InverseColorHex_2 ?? "");
						comm.Parameters.AddWithValue("@langid", SelectedLang.RowId);


						var rows = comm.ExecuteNonQuery();
						if (rows > 0)
						{
							var rowid = conn.LastInsertRowId;
							var newcode = new Codes()
							{
								RowId = rowid,
								Title = (string)parameter,
								Desc = AddCodeDesc,
								DescPrev = AddCodeDesc.Length >= 200 ? AddCodeDesc.Substring(0, 200) : AddCodeDesc,
								Code = AddCodeText,
								CodePrev = AddCodeText.Length >= 300 ? AddCodeText.Substring(0, 300) : AddCodeText,
								Date = DateTime.Now.ToString("dd-MM-yyyy HH':'mm':'ss"),
								GroupId = SelectedCodeGroup.RowId,
								Star = false,
								Lenght = !string.IsNullOrEmpty(AddCodeText) ? AddCodeText.Length : 0,
								Color = SelectedColor.HexCode,
								InvertColor = SelectedColor.InverseColorHex_2
							};

							var i = 0;
							foreach (var group in CodeGroups)
							{
								var ii = i;
								await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
								() =>
								{
									CodeGroups[ii].Codes.Add(newcode);
								}));

								i++;
							}
						}
					}

					AddCodeIsEnabled = true;
				}
			}
			catch (Exception exp)
            {
                AddCodeIsEnabled = true;

                Debug.WriteLine(exp.ToString());
            }
        }

        public Codes SelectedCode { get; set; }
        public string SelectedCodeString { get; set; }

        public ICommand CodeListSelectionChangedComm { get; set; }
        public void SetCode(object parameter)
        {
            if (SelectedCode != null)
            SelectedCodeString = Database.CodeLib.GetCode(SelectedCode.RowId);
        }

        public ICommand LangSelectedChanged { get; set; }
        public async Task LoadCodes()
        {
            try
            {
                Status = "";

                if (CodeGroups != null)
                {
                    await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                    () =>
                    {
                        CodeGroups.Clear();
                    }));
                }


                await Task.Factory.StartNew(async () =>
                {
                    using (var conn = new SQLiteConnection(Connection.ConnString))
                    {
                        conn.Open();

                        using (var trns = conn.BeginTransaction())
                        {
                            using (var comm = new SQLiteCommand(conn))
                            {
                                comm.CommandText =
                                    "SELECT code_lib_groups.rowid, code_lib_groups.title, code_lib_groups.desc, code_lib_groups.desc_prev, code_lib_groups.star " +
                                    "FROM code_lib_groups " +
                                    "JOIN code_lib_langs ON code_lib_groups.langid = code_lib_langs.rowid " +
                                    "WHERE code_lib_groups.userid = (SELECT userid FROM users WHERE active) " +
                                    "AND code_lib_groups.langid = (SELECT active_langid FROM code_lib_settings WHERE active_langid)";

                                using (var reader = comm.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        var i = 0;
                                        while (reader.Read())
                                        {
                                            var groupadd = new CodeGroups()
                                            {
                                                RowId = Convert.ToInt64(reader["rowid"]),
                                                Title = reader["title"].ToString(),
                                                Desc = reader["desc"].ToString(),
                                                DescPrev = reader["desc_prev"].ToString(),
                                                Star = Convert.ToBoolean(Convert.ToInt32(reader["star"] != null ? reader["star"].ToString() : "0")),
                                                Codes = new ObservableCollection<Codes>()
                                            };

                                            await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                                            () =>
                                            {
                                                CodeGroups.Add(groupadd);
                                            }));

                                            using (var commforcodes = new SQLiteCommand(conn))
                                            {
                                                commforcodes.CommandText =
                                                    "SELECT rowid,* FROM code_lib_codes " +
                                                    "WHERE code_lib_codes.userid = (SELECT userid FROM users WHERE active) " +
                                                    "AND code_lib_codes.groupid = '" + reader["rowid"] + "' " +
                                                    "ORDER BY code_lib_codes.date";

                                                using (var readerforcodes = commforcodes.ExecuteReader())
                                                {
                                                    if (readerforcodes.HasRows)
                                                    {
                                                        var icodecount = 0;
                                                        while (readerforcodes.Read())
                                                        {
                                                            icodecount++;

                                                            var codeadd = new Codes()
                                                            {
                                                                RowId = Convert.ToInt64(readerforcodes["rowid"]),
                                                                OrderNum = icodecount,
                                                                Title = readerforcodes["title"].ToString(),
                                                                Desc = readerforcodes["desc"].ToString(),
                                                                DescPrev = readerforcodes["desc_prev"].ToString(),
                                                                GroupId = Convert.ToInt64(readerforcodes["groupid"].ToString()),
                                                                Color = readerforcodes["color"].ToString(),
                                                                InvertColor = readerforcodes["invert_color"].ToString(),
                                                            };

                                                            var ii = i;
                                                            await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                                                            () =>
                                                            {
                                                                CodeGroups[ii].Codes.Add(codeadd);
                                                            }));
                                                        }
                                                    }
                                                }
                                            }

                                            i++;
                                        }
                                    }
                                }
                            }

                            trns.Commit();
                        }

                        SelectedCodeGroup = CodeGroups[0];

                        conn.Close();
                    }
                }).ContinueWith(async (T) => 
                {
                    await LoadColors();
                });
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
            }
        }

        public bool AddGroupIsEnabled { get; set; }
        public ICommand AddGroupComm { get; set; }
        public async Task AddGroup(object parameter)
        {
            try
            {
                Status = "";

                if (SelectedLang == null)
                {
                    Status = "Kod ve kod gruplarının kaydedilebilmesi için bir sil seçiniz.";
                    return;
                }

                await Task.Factory.StartNew(async () =>
                {
                    using (var conn = new SQLiteConnection(Connection.ConnString))
                    {
                        conn.Open();

                        using (var comm = new SQLiteCommand(conn))
                        {
                            AddGroupIsEnabled = false;

                            comm.CommandText = "INSERT INTO code_lib_groups (userid, title, desc, desc_prev, langid, star) values(?,?,?,?,?,?)";

                            comm.Parameters.AddWithValue("@0", User.GetUserId());
                            comm.Parameters.AddWithValue("@1", (string)parameter);
                            comm.Parameters.AddWithValue("@2",
                                !string.IsNullOrEmpty(AddGroupDesc)
                                    ? AddGroupDesc
                                    : string.Empty);
                            comm.Parameters.AddWithValue("@3", !string.IsNullOrEmpty(AddGroupDesc)
                                    ? (AddGroupDesc.Length >= 200 ? AddGroupDesc.Substring(0, 200) : AddGroupDesc)
                                    : string.Empty);
                            comm.Parameters.AddWithValue("@4", SelectedLang.RowId);
                            comm.Parameters.AddWithValue("@5", "0");

                            var rows = comm.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                var rowid = conn.LastInsertRowId;
								var newgroup = new CodeGroups()
								{
									RowId = conn.LastInsertRowId,
									Title = (string)parameter,
									Desc = AddGroupDesc,
									DescPrev = !string.IsNullOrEmpty(AddGroupDesc)
									? (AddGroupDesc.Length >= 200
										? AddGroupDesc.Substring(0, 200)
										: AddGroupDesc)
									: string.Empty,
									Star = false,
									Codes = new ObservableCollection<Codes>()
								};

								await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
								() =>
								{
									CodeGroups.Add(newgroup);
									SelectedCodeGroup = newgroup;
								}));
							}
						}

                        conn.Close();
                    }

                    AddGroupIsEnabled = true;
                });
            }
            catch (Exception exp)
            {
                AddGroupIsEnabled = true;

                Debug.WriteLine(exp.ToString());
            }
        }

        public string AddLangDesc { get; set; }
        public string AddLangText { get; set; }
        public bool AddLangIsEnabled { get; set; }
        public ICommand AddLangComm { get; set; }
        public CodeLangs SelectedLang { get; set; }

        public async Task AddLang(object parameter)
        {
            try
            {
                Status = "";

                await Task.Factory.StartNew(async () =>
                {
                    AddLangIsEnabled = false;

                    using (var conn = new SQLiteConnection(Connection.ConnString))
                    {
                        conn.Open();

                        using (var trns = conn.BeginTransaction())
                        {
                            AddLangIsEnabled = false;

                            using (var comm = new SQLiteCommand(conn))
                            {
                                comm.CommandText = "INSERT INTO code_lib_langs (userid, title, desc, desc_prev) values(?,?,?,?)";

                                comm.Parameters.AddWithValue("@0", User.GetUserId());
                                comm.Parameters.AddWithValue("@1", (string)parameter);
                                comm.Parameters.AddWithValue("@2",
                                    !string.IsNullOrEmpty(AddLangDesc) && AddLangDesc.Trim() !=
                                    "Bu kısma kod bloğu hakkında küçük bir not veya URL adersi eklenebilir."
                                        ? AddLangDesc
                                        : string.Empty);

                                comm.Parameters.AddWithValue("@3",
                                    !string.IsNullOrEmpty(AddLangDesc) && AddLangDesc.Trim() !=
                                    "Bu kısma kod bloğu hakkında küçük bir not veya URL adersi eklenebilir."
                                        ? (AddLangDesc.Length >= 200 ? AddLangDesc.Substring(0, 200) : AddLangDesc)
                                        : string.Empty);

                                var rows = comm.ExecuteNonQuery();
                                if (rows > 0)
                                {
                                    var rowid = conn.LastInsertRowId;
                                    if (CodeLangs.Any(Lang => Lang.RowId != rowid))
                                    {
                                        //if (CodeLangs.Any(Lang => Lang.RowId != rowid))
                                        //{
                                        //    CodeLangs.Add(new CodeLangs()
                                        //    {
                                        //        RowId = conn.LastInsertRowId,
                                        //        Title = (string)parameter,
                                        //        Desc = !string.IsNullOrEmpty(AddLangDesc) && AddLangDesc !=
                                        //               "Bu kısma kod bloğu hakkında küçük bir not veya URL adersi eklenebilir."
                                        //            ? AddLangDesc
                                        //            : string.Empty,
                                        //        DescPrev =
                                        //            !string.IsNullOrEmpty(AddLangDesc) && AddLangDesc !=
                                        //            "Bu kısma kod bloğu hakkında küçük bir not veya URL adersi eklenebilir."
                                        //                ? (AddLangDesc.Length >= 200
                                        //                    ? AddLangDesc.Substring(0, 200)
                                        //                    : AddLangDesc)
                                        //                : string.Empty
                                        //    });
                                        //}

                                        var newitem = new CodeLangs()
                                        {
                                            RowId = conn.LastInsertRowId,
                                            Title = (string)parameter,
                                            DescPrev =
                                                !string.IsNullOrEmpty(AddLangDesc) && AddLangDesc !=
                                                "Bu kısma kod bloğu hakkında küçük bir not veya URL adersi eklenebilir."
                                                    ? (AddLangDesc.Length >= 200
                                                        ? AddLangDesc.Substring(0, 200)
                                                        : AddLangDesc)
                                                    : string.Empty
                                        };

                                        await Task.Delay(1000);

                                        await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                                        () =>
                                        {
                                            CodeLangs.Add(newitem);
                                        }));

                                        SelectedLang = newitem;
                                    }
                                }
                            }

                            trns.Commit();
                        }

                        conn.Close();
                    }

                    await Task.Delay(1000);
                    AddLangIsEnabled = true;
                });
            }
            catch (Exception exp)
            {
                AddLangIsEnabled = true;

                Debug.WriteLine(exp.ToString());
            }
        }

        public async Task SeletAndLoadLangs()
        {
            try
            {
                if (CodeLangs != null && SelectedLang != null)
                {
                    using (var conn = new SQLiteConnection(Connection.ConnString))
                    {
                        conn.Open();

                        using (var comm = new SQLiteCommand(conn))
                        {
                            comm.CommandText = "UPDATE code_lib_settings SET active_langid=@active_langid";
                            comm.Parameters.AddWithValue("@active_langid", SelectedLang.RowId);

                            var rows = comm.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                await LoadCodes();
                            }
                        }

                        conn.Close();
                    }
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp);
            }
        }

        public async Task LoadLangs()
        {
            try
            {
                Status = "";
                SelectedLang = new CodeLangs();

                await Task.Factory.StartNew(async () =>
                {
                    using (var conn = new SQLiteConnection(Connection.ConnString))
                    {
                        conn.Open();

                        using (var comm = new SQLiteCommand(conn))
                        {
                            comm.CommandText = "SELECT rowid,* FROM code_lib_langs WHERE userid=(SELECT userid FROM users WHERE active)";

                            using (var reader = comm.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        var lang = new CodeLangs()
                                        {
                                            RowId = Convert.ToInt64(reader["rowid"]),
                                            Title = reader["title"].ToString(),
                                            Desc = reader["desc"].ToString(),
                                            DescPrev = reader["desc_prev"].ToString()
                                        };

                                        await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                                        () =>
                                        {
                                            CodeLangs.Add(lang);
                                        }));
                                    }
                                }
                            }
                        }

                        if (CodeLangs != null)
                        {
                            using (var commgetactivelang = new SQLiteCommand(conn))
                            {
                                commgetactivelang.CommandText = "SELECT active_langid FROM code_lib_settings";

                                using (var reader = commgetactivelang.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        reader.Read();

                                        foreach (var lang in CodeLangs)
                                        {
                                            if (lang.RowId == Convert.ToInt64(reader["active_langid"] ?? "0"))
                                            {
                                                SelectedLang = lang;
                                            }
                                        }

                                        if (SelectedLang == null)
                                        {
                                            SelectedLang = CodeLangs[0];
                                        }
                                    }
                                    else
                                    {
                                        SelectedLang = CodeLangs[0];
                                    }
                                }
                            }
                        }

                        AddGroupIsEnabled = true;
                        conn.Close();
                    }
                });
            }
            catch (Exception exp)
            {
                AddGroupIsEnabled = true;

                Debug.WriteLine(exp.ToString());
            }
        }

        public ICommand GroupSetStarComm { get; set; }
        public async Task GroupSetStar(object parameter)
        {
            try
            {
                if (SelectedCodeGroup != null)
                {
                    using (var conn = new SQLiteConnection(Connection.ConnString))
                    {
                        conn.Open();

                        using (var commup = new SQLiteCommand(conn))
                        {
                            commup.CommandText = "UPDATE code_lib_groups SET star=@star WHERE rowid='" + SelectedCodeGroup.RowId + "'";
                            commup.Parameters.AddWithValue("@star", (((bool)parameter) ? "1" : "0"));

                            var rows = commup.ExecuteNonQuery();

                            foreach (var item in CodeGroups)
                            {
                                if (item.RowId == SelectedCodeGroup.RowId)
                                {
                                    item.Star = ((bool)parameter);
                                }
                            }
                        }

                        conn.Close();
                    }
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp);
            }
        }

        public ICommand DeleteCodeComm { get; set; }
        public void DeleteCode(object parameter)
        {
            try
            {
                if (SelectedCodeGroup != null)
                {
                    using (var conn = new SQLiteConnection(Connection.ConnString))
                    {
                        conn.Open();

                        using (var commup = new SQLiteCommand(conn))
                        {
                            commup.CommandText = "DELETE FROM code_lib_codes WHERE rowid='" + SelectedCode.RowId + "'";

                            var rows = commup.ExecuteNonQuery();
                            if (rows > 0)
                                foreach (var group in CodeGroups)
                                    if (group.RowId == SelectedCode.GroupId)
                                        foreach (var code in group.Codes)
                                            if (code.RowId == SelectedCode.RowId && code != null)
                                                group.Codes.Remove(code);
                        }

                            conn.Close();
                    }
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp);
            }
        }

        public ICommand CodeSetStarComm { get; set; }
        public async Task CodeSetStar(object parameter)
        {
            try
            {
                if (SelectedCodeGroup != null)
                {
                    using (var conn = new SQLiteConnection(Connection.ConnString))
                    {
                        conn.Open();

                        using (var commup = new SQLiteCommand(conn))
                        {
                            commup.CommandText = "UPDATE code_lib_codes SET star=@star WHERE rowid='" + SelectedCode.RowId + "'";
                            commup.Parameters.AddWithValue("@star", (((bool)parameter) ? "1" : "0"));

                            var rows = commup.ExecuteNonQuery();

                            foreach (var group in CodeGroups)
                            {
                                if (group.RowId == SelectedCode.GroupId)
                                {
                                    foreach (var code in group.Codes)
                                    {
                                        if (code == SelectedCode)
                                        {
                                            code.Star = ((bool)parameter);
                                            return;
                                        }
                                    }
                                }
                            }
                        }

                        conn.Close();
                    }
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp);
            }
        }

        public ICommand DeleteGroupComm { get; set; }
        public void DeleteGroup(object parameter)
        {
            try
            {
                if (SelectedCodeGroup != null)
                {
                    using (var conn = new SQLiteConnection(Connection.ConnString))
                    {
                        conn.Open();

                        // delete code group of codes
                        using (var comm = new SQLiteCommand(conn))
                        {
                            comm.CommandText = "SELECT rowid FROM code_lib_codes WHERE groupid='" + SelectedCodeGroup.RowId + "'";
                            using (var reader = comm.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    using (var commdelcodes = new SQLiteCommand(conn))
                                    {
                                        commdelcodes.CommandText = "DELETE FROM code_lib_codes WHERE groupid='" + SelectedCodeGroup.RowId + "'";
                                        commdelcodes.ExecuteNonQuery();
                                    }
                                }
                            }

                            // delete code group and remove from list
                            using (var commdelgroups = new SQLiteCommand(conn))
                            {
                                commdelgroups.CommandText = "DELETE FROM code_lib_groups WHERE rowid='" + SelectedCodeGroup.RowId + "'";

                                foreach (var group in CodeGroups)
                                {
                                    if (group.RowId == SelectedCodeGroup.RowId)
                                    {
                                        commdelgroups.ExecuteNonQuery();
                                        CodeGroups.Remove(group);
                                    }
                                }
                            }
                        }

                        conn.Close();
                    }
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp);
            }
        }

        public ICommand UpdateCodeComm { get; set; }
        public void UpdateCode(object parameter)
        {
            try
            {
                var values = (object[])parameter;

                if (parameter != null)
                {
                    using (var conn = new SQLiteConnection(Connection.ConnString))
                    {
                        conn.Open();

                        using (var comm = new SQLiteCommand(conn))
                        {
                            comm.CommandText = "UPDATE code_lib_codes SET code=@code, code_prev=@code_prev, desc=@desc, desc_prev=@desc_prev WHERE rowid='" + values[2] as string + "'";
                            comm.Parameters.AddWithValue("@code", !string.IsNullOrEmpty(values[0] as string) ? values[0] as string : string.Empty);
                            comm.Parameters.AddWithValue("@code_prev", (values[0] as string).Length >= 300 ? (values[0] as string).Substring(0, 300) : (values[0] as string));
                            comm.Parameters.AddWithValue("@desc", !string.IsNullOrEmpty(values[1] as string) ? values[1] as string : string.Empty);
                            comm.Parameters.AddWithValue("@desc_prev", (values[1] as string).Length >= 300 ? (values[1] as string).Substring(0, 300) : (values[1] as string));
                            var rows = comm.ExecuteNonQuery();
                        }

                        conn.Close();
                    }
                }
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp);
            }
        }

        public ICommand ReloadColors { get; set; }
        public async Task LoadColors()
        {
            try
            {
                Status = "";

                if (ColorGroups != null)
                {
                    await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                    () =>
                    {
                        ColorGroups.Clear();
                    }));
                }

                await Task.Factory.StartNew(async () =>
                {
                    using (var conn = new SQLiteConnection(Connection.ConnString))
                    {
                        await Task.Delay(500);
                        conn.Open();

                        using (var comm = new SQLiteCommand(conn))
                        {
                            comm.CommandText =
                                "SELECT color_lib_groups.rowid, color_lib_groups.title, color_lib_groups.desc, color_lib_groups.desc_prev, color_lib_groups.star " +
                                "FROM color_lib_groups " +
                                "WHERE color_lib_groups.userid = (SELECT userid FROM users WHERE active)";

                            using (var reader = comm.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    var i = 0;
                                    while (reader.Read())
                                    {
                                        var groupadd = new ColorGroups()
                                        {
                                            RowId = Convert.ToInt64(reader["rowid"]),
                                            Title = reader["title"].ToString(),
                                            Desc = reader["desc"].ToString(),
                                            DescPrev = reader["desc_prev"].ToString(),
                                            Star = Convert.ToBoolean(Convert.ToInt32(reader["star"] != null ? reader["star"].ToString() : "0")),
                                            Colors = new ObservableCollection<Color.CoColor>()
                                        };

                                        await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                                        () =>
                                        {
                                            ColorGroups.Add(groupadd);
                                        }));

                                        using (var commforcolors = new SQLiteCommand(conn))
                                        {
                                            commforcolors.CommandText =
                                                "SELECT rowid,* FROM color_lib_colors " +
                                                "WHERE color_lib_colors.userid = (SELECT userid FROM users WHERE active) " +
                                                "AND color_lib_colors.groupid = '" + reader["rowid"] + "' " +
                                                "ORDER BY color_lib_colors.date";

                                            using (var readerforcolors = commforcolors.ExecuteReader())
                                            {
                                                if (readerforcolors.HasRows)
                                                {
                                                    var icolorcount = 0;
                                                    while (readerforcolors.Read())
                                                    {
                                                        icolorcount++;

                                                        var coloradd = new Color.CoColor()
                                                        {
                                                            RowId = Convert.ToInt64(readerforcolors["rowid"]),
                                                            OrderNum = icolorcount,
                                                            Title = readerforcolors["title"].ToString(),
                                                            HexCode = readerforcolors["hex"].ToString(),
                                                            RgbCode = readerforcolors["rgb"].ToString(),
                                                            ArgbCode = readerforcolors["argb"].ToString(),
                                                            GroupId = Convert.ToInt64(readerforcolors["groupid"].ToString()),
                                                            InverseColorHex_1 = readerforcolors["invert_hex_1"].ToString(),
                                                            InverseColorHex_2 = readerforcolors["invert_hex_2"].ToString()
                                                        };

                                                        var ii = i;
                                                        await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                                                        () =>
                                                        {
                                                            ColorGroups[ii].Colors.Add(coloradd);
                                                        }));
                                                    }
                                                }
                                            }
                                        }

                                        i++;
                                    }
                                }
                            }
                        }

                        SelectedColorGroup = ColorGroups[0];

                        conn.Close();
                    }
                });
            }
            catch (Exception exp)
            {
                Debug.WriteLine(exp.ToString());
            }
        }
    }

    /// <summary>
    /// Code Library Codes
    /// </summary>
    public class Codes
    {
        public long RowId { get; set; }
        public long OrderNum { get; set; }

        public string Title { get; set; }
        public string Desc { get; set; }
        public string DescPrev { get; set; }
        public string Code { get; set; }
        public string CodePrev { get; set; }
        public string Date { get; set; }

        public long GroupId { get; set; }
        public bool Star { get; set; }
        public int Lenght { get; set; }
        public string Color { get; set; }
        public string InvertColor { get; set; }
    }

    /// <summary>
    /// Code Groups Class
    /// </summary>
    public class CodeGroups
    {
        public long RowId { get; set; }

        public string Title { get; set; }
        public string Desc { get; set; }
        public string DescPrev { get; set; }
        public bool Star { get; set; }

        public ObservableCollection<Codes> Codes { get; set; }
    }

    /// <summary>
    /// Basic Code Languages Class
    /// </summary>
    public class CodeLangs
    {
        public long RowId { get; set; }

        public string Title { get; set; }
        public string Desc { get; set; }
        public string DescPrev { get; set; }
    }
}
