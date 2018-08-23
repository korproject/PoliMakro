using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Poli.Makro.Core.Helpers.Image;
using System.Threading;
using Poli.Makro.Core.ClipboardManager.Controllers;
using Poli.Makro.Core.ClipboardManager.Helpers;
using Poli.Makro.Core.ClipboardManager.Hooks;
using Poli.Makro.Core.Helpers.String;
using System.Collections.Generic;
using System.Data.SQLite;
using Microsoft.Win32;
using Poli.Makro.Core.Database;

namespace Poli.Makro.Core.ClipboardManager.Clipboard
{
    public class ClipboardEnviroment
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ClipboardEnviroment()
        {
            // create default session
            CreateSession();

            // get pettern groups
            GetPetternGroups();


            if (System.Windows.Clipboard.ContainsImage())
                _tempiamge = BitmapImageExtensions.BmpSource2BmpImage(
                    ClipboardHelper.GetContentFromClipboardWithRetry(Helpers.ContentType
                        .Image) as BitmapSource);
            if (System.Windows.Clipboard.ContainsText())
                _tempstringC = System.Windows.Clipboard.GetText();

            keyboardHook.KeyDown += keyboardHook_KeyDown;
            keyboardHook.KeyUp += keyboardHook_KeyUp;

            mouseHook.LeftButtonDown += mouseHook_LeftButtonDown;
            mouseHook.RightButtonUp += mouseHook_RightButtonUp;

            Hooker();
        }

        /// <summary>
        /// Hook manager for changes selections
        /// </summary>
        public static void Hooker()
        {
            if (ViewModel.ClipboardManager.Clipboard.KeyX || ViewModel.ClipboardManager.Clipboard.KeyC || ViewModel.ClipboardManager.Clipboard.KeyV)
            {
                InstallerKeyboardHook();
            } else
            {
                InstallerKeyboardHook(false);
            }

            if (ViewModel.ClipboardManager.Clipboard.MouseRL)
            {
                InstallerMouseHook();
            }
            else
            {
                InstallerMouseHook(false);
            }
        }

        /// <summary>
        /// define mouse hook
        /// </summary>
        public static MouseHook mouseHook = new MouseHook();

        /// <summary>
        /// define keyboard hook
        /// </summary>
        public static KeyboardHook keyboardHook = new KeyboardHook();

        /// <summary>
        /// to prevent repetitive contents
        /// </summary>
        private static string _tempstringX = string.Empty;
        private static string _tempstringC = string.Empty;
        private static string _tempstringV = string.Empty;

        /// <summary>
        /// to prevent repetitive contents
        /// </summary>
        private static BitmapImage _tempiamge;

        /// <summary>
        /// all clipboard records inserting this list
        /// </summary>
        public static ObservableCollection<ClipboardRecord> ClipboardRecordsL = new ObservableCollection<ClipboardRecord>();

        public static ObservableCollection<ClipboardHistory> ClipboardRecordHistories = new ObservableCollection<ClipboardHistory>();
        public static ObservableCollection<ClipboardRecord> ClipboardRecordHistoryL = new ObservableCollection<ClipboardRecord>();

        public static ObservableCollection<ClipboardPetternGroup> ClipboardPetternGroupL = new ObservableCollection<ClipboardPetternGroup>();

        private static bool rightclick;
        private static bool LCTRL;
        private static string action = string.Empty;
        public static string SessionKey = string.Empty;

        #region Keyboard Actions

        /// <summary>
        /// Keyboard key up event
        /// </summary>
        private static void keyboardHook_KeyUp(KeyboardHook.VKeys key)
        {
            if (key == KeyboardHook.VKeys.LCONTROL)
            {
                LCTRL = false;
            }
        }

        /// <summary>
        /// Keyboard key down event
        /// </summary>
        private static async void keyboardHook_KeyDown(KeyboardHook.VKeys key)
        {
            if (key == KeyboardHook.VKeys.LCONTROL)
            {
                LCTRL = true;
            }

            if (ViewModel.ClipboardManager.Clipboard.KeyX && LCTRL && key == KeyboardHook.VKeys.KEY_X) 
            {
                action = "CTRL + X";

                string stringX =
                    ClipboardHelper.GetContentFromClipboardWithRetry(Helpers.ContentType
                        .Text) as string;

                if (!(stringX != _tempstringX & stringX != null)) return;
                await Task.Factory.StartNew(() =>
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        var item = new ClipboardRecord()
                        {
                            OrderNumber = ClipboardRecordsL.Count + 1,
                            DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                            Size = Encoding.Unicode.GetByteCount(stringX).ToString(),
                            Action = action ?? "Unknown Action",
                            ContentType = ContentType.Text,
                            ContentText = stringX,
                            ContentTextPreview = stringX.Length >= 150 ? stringX.Substring(0, 150) + "..." : stringX
                        };

                        item.RowId = SaveContent(item);
                        ClipboardRecordsL.Add(item);
                    }));
                });

                _tempstringX = stringX;
            }

            else if (ViewModel.ClipboardManager.Clipboard.KeyC && LCTRL && key == KeyboardHook.VKeys.KEY_C)
            {
                action = "CTRL + C";
            }

            else if (ViewModel.ClipboardManager.Clipboard.KeyV && LCTRL && key == KeyboardHook.VKeys.KEY_V)
            {
                action = "CTRL + V";

                string stringV =
                    ClipboardHelper.GetContentFromClipboardWithRetry(Helpers.ContentType
                        .Text) as string;

                if (stringV != _tempstringV & stringV != null)
                {
                    Debug.WriteLine(action);
                    await Task.Factory.StartNew(() =>
                    {
                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                        {
                            var item = new ClipboardRecord()
                            {
                                OrderNumber = ClipboardRecordsL.Count + 1,
                                DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                                Size = Encoding.Unicode.GetByteCount(stringV).ToString(),
                                Action = action ?? "Unknown Action",
                                ContentType = ContentType.Text,
                                ContentText = stringV,
                                ContentTextPreview = stringV.Length >= 150 ? stringV.Substring(0, 150) + "..." : stringV
                            };

                            item.RowId = SaveContent(item);
                            ClipboardRecordsL.Add(item);
                        }));
                    });

                    _tempstringV = stringV;
                }
            }

            else if (ViewModel.ClipboardManager.Clipboard.KeyLShift && LCTRL && key == KeyboardHook.VKeys.LSHIFT)
            {
                if (ClipboardRecordsL.Any())
                {
                    var midlist = ClipboardRecordsL.Where(w => w.ContentType == ContentType.Text);

                    if (midlist.Any())
                    {
                        int outputc = 0;
                        string output = string.Empty;
                        foreach (var item in midlist)
                        {
                            if (item.ContentText.Length > 0)
                            {
                                output += item.ContentText + Environment.NewLine;
                                outputc++;
                            }
                        }
                        System.Windows.Clipboard.SetText(output);

                        MessageBox.Show(outputc + " Adet içerik liste halinede panoya kopyalandı.");
                    }
                    else
                    {
                        MessageBox.Show("Listelenecek türden veri bulunamadı.");
                    }
                }
                else
                {
                    MessageBox.Show("Listede hiç öğe yok.");
                }
            }
        }

        #endregion

        #region Mouse Actions

        /// <summary>
        /// When mouse right button up
        /// </summary>
        private static void mouseHook_RightButtonUp(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            rightclick = true;
        }

        /// <summary>
        /// When mouse right button down
        /// </summary>
        private static void mouseHook_LeftButtonDown(MouseHook.MSLLHOOKSTRUCT mouseStruct)
        {
            if (rightclick)
            {
                action = "Mouse L. Click";
                rightclick = false;
            }
        }

        #endregion

        #region Clipboard Actions

        /// <summary>
        /// When clipboard text changed
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="text">return value</param>
        public static void ClipboardTextChanged(object sender, string text)
        {
            var clippedText = text.Trim();

            if (string.IsNullOrWhiteSpace(clippedText))
            {
                return;
            }

            if (action == "CTRL + C" && clippedText != _tempstringC && ViewModel.ClipboardManager.Clipboard.KeyC)
            {
                var thread = new Thread(() =>
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        var item = new ClipboardRecord()
                        {
                            OrderNumber = ClipboardRecordsL.Count + 1,
                            DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                            Size = Encoding.Unicode.GetByteCount(clippedText).ToString(),
                            Action = action ?? "Unknown Action",
                            ContentType = ContentType.Text,
                            ContentText = clippedText,
                            ContentTextPreview = clippedText.Length >= 150
                                ? clippedText.Substring(0, 150) + "..."
                                : clippedText
                        };

                        item.RowId = SaveContent(item);
                        ClipboardRecordsL.Add(item);
                    }));
                })
                {
                    IsBackground = true
                };
                thread.Start();

                _tempstringC = clippedText;
            }

            else if (action == "CTRL + X" && clippedText != _tempstringX && ViewModel.ClipboardManager.Clipboard.KeyC)
            {
                var thread = new Thread(() =>
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        var item = new ClipboardRecord()
                        {
                            OrderNumber = ClipboardRecordsL.Count + 1,
                            DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                            Size = Encoding.Unicode.GetByteCount(clippedText).ToString(),
                            Action = action ?? "Unknown Action",
                            ContentType = ContentType.Text,
                            ContentText = clippedText,
                            ContentTextPreview = clippedText.Length >= 150
                                ? clippedText.Substring(0, 150) + "..."
                                : clippedText
                        };

                        item.RowId = SaveContent(item);
                        ClipboardRecordsL.Add(item);
                    }));
                })
                {
                    IsBackground = true
                };
                thread.Start();

                _tempstringC = clippedText;
            }

            else if (action == "Mouse L. Click" && ViewModel.ClipboardManager.Clipboard.MouseRLText)
            {
                var thread = new Thread(() =>
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        var item = new ClipboardRecord()
                        {
                            OrderNumber = ClipboardRecordsL.Count + 1,
                            DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                            Size = Encoding.Unicode.GetByteCount(clippedText).ToString(),
                            Action = action ?? "Unknown Action",
                            ContentType = ContentType.Text,
                            ContentText = clippedText,
                            ContentTextPreview = clippedText.Length >= 150
                                ? clippedText.Substring(0, 150) + "..."
                                : clippedText
                        };

                        item.RowId = SaveContent(item);
                        ClipboardRecordsL.Add(item);
                    }));
                })
                {
                    IsBackground = true
                };
                thread.Start();

                _tempstringC = clippedText;
                _tempstringX = clippedText;
                _tempstringV = clippedText;
            }
        }

        /// <summary>
        /// When clipboard image changed
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="bitmapsource">return value</param>
        public static void ClipboardImageChanged(object sender, BitmapSource bitmapsource)
        {
            if (bitmapsource == null)
            {
                return;
            }

            if (action == "Mouse L. Click" && ViewModel.ClipboardManager.Clipboard.MouseRLImage)
            {
                string img = CreateSaveLocation();

                var thread = new Thread(async () =>
                {
                    await Task.Factory.StartNew(() =>
                    {
                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                        {
                            using (var fileStream = new FileStream(img, FileMode.Create))
                            {
                                BitmapEncoder encoder = new PngBitmapEncoder();
                                encoder.Frames.Add(BitmapFrame.Create(bitmapsource));
                                encoder.Save(fileStream);
                            }
                        }));
                    }).ContinueWith((T) =>
                    {
                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                        {
                            var item = new ClipboardRecord()
                            {
                                OrderNumber = ClipboardRecordsL.Count + 1,
                                DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                                Size = (new FileInfo(img).Length / 1024).ToString(),
                                ContentImageResolution = bitmapsource.Width + " x " + bitmapsource.Height,
                                Action = action ?? "Unknown Action",
                                ContentType = ContentType.Image,
                                ContentImage = img,
                                ContentTextPreview = img
                            };

                            item.RowId = SaveContent(item);
                            ClipboardRecordsL.Add(item);
                        }));
                    });
                })
                {
                    IsBackground = true
                };
                thread.Start();
            }
        }

        #endregion

        #region Saves

        public static long SaveContent(ClipboardRecord cliprec)
        {
            long row = 0;

            var thread = new Thread(() =>
            {
                using (SQLiteConnection conn = new SQLiteConnection(Connection.ConnString))
                {
                    conn.Open();

                    using (SQLiteCommand comm = new SQLiteCommand(conn))
                    {
                        comm.CommandText = "INSERT INTO clipboard (date_time, size, content_type, content_text, content_image_path, resolution, session_key) values(?,?,?,?,?,?,?)";
                        comm.Parameters.AddWithValue("@0", cliprec.DateTime);
                        comm.Parameters.AddWithValue("@1", cliprec.Size);
                        comm.Parameters.AddWithValue("@2", cliprec.ContentType.ToString());
                        comm.Parameters.AddWithValue("@3", cliprec.ContentText);
                        comm.Parameters.AddWithValue("@4", cliprec.ContentImage);
                        comm.Parameters.AddWithValue("@5", cliprec.ContentImageResolution);
                        comm.Parameters.AddWithValue("@6", SessionKey);

                        var rows = comm.ExecuteNonQuery();
                        row = conn.LastInsertRowId;
                    }

                    conn.Close();
                }
            })
            {
                IsBackground = true
            };

            thread.Start();

            return row;
        }

        #endregion

        #region Groups

        /// <summary>
        /// Creates new pettern group
        /// </summary>
        /// <param name="newgroup"></param>
        /// <returns></returns>
        public static bool CreatePetternGroup(string newgroup)
        {
            var rows = 0;

            using (var conn = new SQLiteConnection(Connection.ConnString))
            {
                conn.Open();

                using (var comm = new SQLiteCommand(conn))
                {
                    comm.CommandText = "SELECT title FROM clipboard_petterns_groups WHERE title=?";
                    comm.Parameters.AddWithValue("@0", newgroup);

                    using (var reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return false;
                        }
                    }
                }

                using (var commup = new SQLiteCommand(conn))
                {
                    commup.CommandText = "UPDATE clipboard_petterns_groups SET status=? WHERE status=?";
                    commup.Parameters.AddWithValue("@0", "0");
                    commup.Parameters.AddWithValue("@1", "1");

                    commup.ExecuteNonQuery();
                }

                using (var commin = new SQLiteCommand(conn))
                {
                    commin.CommandText = "INSERT INTO clipboard_petterns_groups (title, date, status) values(?,?,?)";
                    commin.Parameters.AddWithValue("@0", newgroup);
                    commin.Parameters.AddWithValue("@1", DateTime.Now.ToString("dd-MM-yyyy HH':'mm':'ss"));
                    commin.Parameters.AddWithValue("@2", "1");

                    rows = commin.ExecuteNonQuery();
                }

                conn.Close();

                GetPetternGroups();

                return rows > 0 ? true : false;
            }
        }

        /// <summary>
        /// Get pettern groups list
        /// </summary>
        private static void GetPetternGroups()
        {
            if (ClipboardPetternGroupL.Count > 0)
            {
                ClipboardPetternGroupL.Clear();
            }

            using (var conn = new SQLiteConnection(Connection.ConnString))
            {
                conn.Open();

                using (var comm = new SQLiteCommand(conn))
                {
                    comm.CommandText = "SELECT rowid,* FROM clipboard_petterns_groups";

                    using (var reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int i = 1;
                            while (reader.Read())
                            {
                                // group
                                var petternGroup = new ClipboardPetternGroup()
                                {
                                    RowId = Convert.ToInt64(reader["rowid"].ToString()),
                                    Order = i++,
                                    Title = reader["title"].ToString(),
                                    Date = reader["date"].ToString(),
                                    Status = reader["status"].ToString() == "1" ? true : false
                                };

                                // get group contains
                                using (var commpt = new SQLiteCommand(conn))
                                {
                                    commpt.CommandText = "SELECT rowid, * FROM clipboard_petterns WHERE groupid=?";
                                    commpt.Parameters.AddWithValue("@0", reader["rowid"]);

                                    using (var readerpt = commpt.ExecuteReader())
                                    {
                                        if (readerpt.HasRows)
                                        {
                                            int o = 1;

                                            // create petterns group
                                            petternGroup.ClipboardPetterns = new ObservableCollection<ClipboardPettern>();

                                            while (readerpt.Read())
                                            {
                                                var pettern = new ClipboardPettern()
                                                {
                                                    RowId = Convert.ToInt64(readerpt["rowid"].ToString()),
                                                    Order = o++,
                                                    Title = readerpt["title"].ToString(),
                                                    Pettern = readerpt["pettern"].ToString(),
                                                    Date = readerpt["date"].ToString(),
                                                    GroupId = Convert.ToInt64(readerpt["rowid"].ToString())
                                                };

                                                petternGroup.ClipboardPetterns.Add(pettern);
                                            }
                                        }
                                    }
                                }

                                ClipboardPetternGroupL.Add(petternGroup);
                            }
                        }
                    }
                }

                conn.Close();
            }

        }

        /// <summary>
        /// Pettern creater
        /// </summary>
        /// <param name="petternTitle"></param>
        /// <param name="pettern"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static bool CreatePettern(string petternTitle, string pettern, long groupId)
        {
            var rows = 0;

            using (var conn = new SQLiteConnection(Connection.ConnString))
            {
                conn.Open();

                using (var comm = new SQLiteCommand(conn))
                {
                    comm.CommandText = "SELECT * FROM clipboard_petterns WHERE pettern=?";
                    comm.Parameters.AddWithValue("@0", pettern);

                    using (var reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            return false;
                        }
                    }
                }

                using (var commin = new SQLiteCommand(conn))
                {
                    commin.CommandText = "INSERT INTO clipboard_petterns (title, pettern, date, groupid) values(?,?,?,?)";
                    commin.Parameters.AddWithValue("@0", petternTitle);
                    commin.Parameters.AddWithValue("@1", pettern);
                    commin.Parameters.AddWithValue("@2", DateTime.Now.ToString("dd-MM-yyyy HH':'mm':'ss"));
                    commin.Parameters.AddWithValue("@3", groupId);

                    rows = commin.ExecuteNonQuery();
                }

                foreach (var item in ClipboardPetternGroupL)
                {
                    if (item.RowId == groupId)
                    {
                        var newpettern = new ClipboardPettern()
                        {
                            RowId = conn.LastInsertRowId,
                            Order = item.ClipboardPetterns.Count + 1,
                            Title = petternTitle,
                            Pettern = pettern,
                            Date = DateTime.Now.ToString("dd-MM-yyyy HH':'mm':'ss"),
                            GroupId = groupId
                        };

                        item.ClipboardPetterns.Add(newpettern);
                    }
                }

                conn.Close();

                return rows > 0 ? true : false;
            }
        }

        #endregion

        #region Sessions

        public static bool SessionCreated = false;

        /// <summary>
        /// Default session creator
        /// </summary>
        private static void CreateSession()
        {
            if (!SessionCreated)
            {
                // set session key
                SessionKey = Common.GetUniqueString();

                long rows = 0;

                using (var conn = new SQLiteConnection(Connection.ConnString))
                {
                    conn.Open();

                    using (var comm = new SQLiteCommand(conn))
                    {
                        comm.CommandText = "SELECT session_key FROM clipboard_sessions WHERE session_key=?";
                        comm.Parameters.AddWithValue("@0", SessionKey);

                        using (var reader = comm.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                CreateSession();
                            }
                        }
                    }

                    using (var commin = new SQLiteCommand(conn))
                    {
                        commin.CommandText = "INSERT INTO clipboard_sessions (session_key, title, date) values(?,?,?)";
                        commin.Parameters.AddWithValue("@0", SessionKey);
                        commin.Parameters.AddWithValue("@1", DateTime.Now.ToString("dd-MM-yyyy HH':'mm':'ss"));
                        commin.Parameters.AddWithValue("@2", DateTime.Now.ToString("dd-MM-yyyy HH':'mm':'ss"));

                        rows = commin.ExecuteNonQuery();
                    }

                    conn.Close();
                }


                if (rows > 0)
                {
                    SessionCreated = true;

                    // get histories
                    GetHistories();
                }
            }
        }

        /// <summary>
        /// Rename session title
        /// </summary>
        /// <param name="newtitle"></param>
        /// <returns></returns>
        public static bool RenameSessionTitle(string newtitle)
        {
            using (var conn = new SQLiteConnection(Connection.ConnString))
            {
                conn.Open();

                var rows = 0;

                using (var comm = new SQLiteCommand(conn))
                {
                    comm.CommandText = "UPDATE clipboard_sessions SET title=? WHERE session_key=?";
                    comm.Parameters.AddWithValue("@0", newtitle);
                    comm.Parameters.AddWithValue("@1", SessionKey);

                    rows = comm.ExecuteNonQuery();
                }

                conn.Close();

                GetHistories();

                return rows > 0 ? true : false;
            }
        }

        #endregion

        #region History

        /// <summary>
        /// General history list
        /// </summary>
        public static void GetHistories()
        {
            if (ClipboardRecordHistories.Count > 0)
            {
                ClipboardRecordHistories.Clear();
            }

            using (var conn = new SQLiteConnection(Connection.ConnString))
            {
                conn.Open();

                using (var comm = new SQLiteCommand(conn))
                {
                    comm.CommandText = "SELECT clipboard_sessions.rowid, COUNT(clipboard.session_key) AS count, clipboard.session_key, clipboard_sessions.title, clipboard_sessions.date " +
                        "FROM clipboard " +
                        "INNER JOIN clipboard_sessions " +
                        "ON clipboard.session_key = clipboard_sessions.session_key " +
                        "GROUP BY clipboard.session_key " +
                        "ORDER BY clipboard_sessions.rowid ASC";

                    using (var reader = comm.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var history = new ClipboardHistory()
                                {
                                    Count = Convert.ToInt32(reader["count"].ToString()),
                                    SessionKey = reader["session_key"].ToString(),
                                    Title = reader["title"].ToString(),
                                    Date = reader["date"].ToString()
                                };

                                ClipboardRecordHistories.Add(history);
                            }
                        }
                    }
                }

                conn.Close();
            }
        }

        public static void GetHistory(string sessionKey)
        {
            var thread = new Thread(() =>
            {
                if (ClipboardRecordHistoryL.Count > 0)
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        ClipboardRecordHistoryL.Clear();
                    }));
                }

                using (var conn = new SQLiteConnection(Connection.ConnString))
                {
                    conn.Open();

                    using (var comm = new SQLiteCommand(conn))
                    {
                        comm.CommandText = "SELECT rowid, * FROM clipboard WHERE session_key=?";
                        comm.Parameters.AddWithValue("@0", sessionKey);

                        using (var reader = comm.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                int i = 1;

                                while (reader.Read())
                                {
                                    var item = new ClipboardRecord()
                                    {
                                        RowId = Convert.ToInt64(reader["rowid"].ToString()),
                                        OrderNumber = i++,
                                        DateTime = reader["date_time"].ToString(),
                                        Size = reader["size"].ToString(),
                                        ContentType = (ContentType)Enum.Parse(typeof(ContentType), reader["content_type"].ToString()),
                                        ContentText = reader["content_text"].ToString(),
                                        ContentTextPreview = reader["content_text"].ToString().Length >= 150 ? reader["content_text"].ToString().Substring(0, 150) + "..." : reader["content_text"].ToString()
                                    };

                                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                                    {
                                        ClipboardRecordHistoryL.Add(item);
                                    }));
                                }
                            }
                        }
                    }

                    conn.Close();
                }
            })
            {
                IsBackground = true
            };

            thread.Start();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Keyboard hook installer
        /// </summary>
        public static void InstallerKeyboardHook(bool choice = true)
        {
            if (choice && keyboardHook.hookID == IntPtr.Zero)
            {
                keyboardHook.Install();
                Debug.WriteLine("Keyboard Hook Installed: " + keyboardHook.hookID);
            }

            if (choice == false && keyboardHook.hookID != IntPtr.Zero)
            {
                keyboardHook.Uninstall();
                Debug.WriteLine("Keyboard Hook Uninstalled: " + keyboardHook.hookID);
            }
        }

        /// <summary>
        /// Mouse hook installer
        /// </summary>
        public static void InstallerMouseHook(bool choice = true)
        {
            if (choice && mouseHook.hookID == IntPtr.Zero)
            {
                mouseHook.Install();
                Debug.WriteLine("Mouse Hook Installed: " + mouseHook.hookID);
            }
            else if (choice == false && mouseHook.hookID != IntPtr.Zero)
            {
                mouseHook.Uninstall();
                Debug.WriteLine("Mouse Hook Uninstalled: " + mouseHook.hookID);
            }
        }

        /// <summary>
        /// Cerates file path for file saving
        /// </summary>
        /// <returns>new save path</returns>
        private static string CreateSaveLocation()
        {
            string extension = ".jpg";
            string imagesavepath = FileFolderController.ImagesDir + "Image [" +
                                   long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) + "]";

            if (File.Exists(imagesavepath))
            {
                imagesavepath = FileFolderController.ImagesDir + "Image [" +
                                long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")) + "+" +
                                new Random().Next(0, 10000) + "]";
            }

            return imagesavepath + extension;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Delete recorded item list and database
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public static bool DeleteItem(long recordId)
        {
            var rows = 0;

            using (SQLiteConnection conn = new SQLiteConnection(Connection.ConnString))
            {
                conn.Open();

                using (SQLiteCommand comm = new SQLiteCommand(conn))
                {
                    comm.CommandText = "DELETE FROM clipboard WHERE rowid=?";
                    comm.Parameters.AddWithValue("@0", recordId);

                    rows = comm.ExecuteNonQuery();
                }

                conn.Close();
            }

            if (rows > 0)
            {
                var itemToRemove = ClipboardRecordsL.Single(r => r.RowId == recordId);
                ClipboardRecordsL.Remove(itemToRemove);

                return rows > 0 ? true : false;
            }
            return false;
        }

        /// <summary>
        /// Copy recorded item in list
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public static bool CopyItem(long recordId, bool source)
        {
            ClipboardRecord item = null;

            if (source)
            {
                item = ClipboardRecordsL.Single(i => i.RowId == recordId);
            }
            else
            {
                item = ClipboardRecordHistoryL.Single(i => i.RowId == recordId);
            }

            if (item != null)
            {
                if (item.ContentType == ContentType.Text)
                {
                    System.Windows.Clipboard.SetText(item.ContentText);
                }
                else if (item.ContentType == ContentType.Image)
                {
                    BitmapSource bitmapSource = new BitmapImage(new Uri(item.ContentImage));

                    System.Windows.Clipboard.SetImage(bitmapSource);
                }
            }

            return true;
        }

        /// <summary>
        /// Save as item an file
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public static bool SaveAsItem(long recordId, bool source)
        {
            ClipboardRecord item = null;

            if (source)
            {
                item = ClipboardRecordsL.Single(i => i.RowId == recordId);
            } else
            {
                item = ClipboardRecordHistoryL.Single(i => i.RowId== recordId);
            }

            if (item != null)
            {
                if (item.ContentType == ContentType.Text)
                {
                    SaveFileDialog opfiledialog = new SaveFileDialog
                    {
                        FileName = $"Copied Text {recordId}.txt",
                        DefaultExt = ".txt",
                        Filter = "TXT Files (*.txt)|*.txt|JSON Files (*.json)|*.json",
                        AddExtension = true,
                        Title = "Metni tekrar katdedeceğiniz konumu seçin"
                    };
                    bool? result = opfiledialog.ShowDialog();

                    if (result == true)
                    {
                        File.WriteAllText(opfiledialog.FileName, item.ContentText);
                    }
                }
                else if (item.ContentType == ContentType.Image)
                {
                    SaveFileDialog opfiledialog = new SaveFileDialog
                    {
                        FileName = $"Copied Image {recordId}",
                        DefaultExt = ".jpg",
                        Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png",
                        AddExtension = true,
                        Title = "Görseli tekrar katdedeceğiniz konumu seçin"
                    };
                    bool? result = opfiledialog.ShowDialog();

                    if (result == true)
                    {
                        BitmapImageExtensions.SaveBitmapSource2File(new BitmapImage(new Uri(item.ContentImage)), opfiledialog.FileName);
                    }
                }
            }

            return true;
        }

        #endregion
    }

    public class ClipboardRecord
    {
        public long RowId { get; set; }
        public int OrderNumber { get; set; }
        public string DateTime { get; set; }
        public string Size { get; set; }
        public string Action { get; set; }
        public ContentType ContentType { get; set; }
        public string ContentText { get; set; }
        public string ContentTextPreview { get; set; }

        public string ContentImage { get; set; }
        public string ContentImageResolution { get; set; }
    }

    public class ClipboardHistory
    {
        public string SessionKey { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public int Count { get; set; }
    }

    public class ClipboardPetternGroup
    {
        public long RowId { get; set; }
        public long Order { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public bool Status { get; set; }
        public ObservableCollection<ClipboardPettern> ClipboardPetterns = new ObservableCollection<ClipboardPettern>();
    }

    public class ClipboardPettern
    {
        public long RowId { get; set; }
        public long Order { get; set; }
        public string Title { get; set; }
        public string Pettern { get; set; }
        public string Date { get; set; }
        public long GroupId { get; set; }
    }

    public enum ContentType
    {
        Text,
        Image,
        Path
    }
}
