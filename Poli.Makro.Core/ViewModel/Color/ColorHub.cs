using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using ColorThiefDotNet;
using KOR.ColorConversions;
using Microsoft.Win32;
using Newtonsoft.Json;
using Poli.Makro.Core.Database;
using Poli.Makro.Core.Json.Color.ImportExport;
using Poli.Makro.Core.ViewModel.Base;

namespace Poli.Makro.Core.ViewModel.Color
{
	public class ColorHub : BaseViewModel
	{
		/// <summary>
		/// Main constructor
		/// </summary>
		public ColorHub()
		{
            IsOpenColorPickerMini = false;

            PickedColors = new ObservableCollection<CoColor>();
			ColorGroups = new ObservableCollection<ColorGroups>();
			ScanImageComm = new RelayParameterizedCommand(parameter => ScanImage(parameter));
			DominantColors = new ObservableCollection<CoColor>();

			worker.DoWork += worker_DoWork;
			worker.RunWorkerCompleted += worker_RunWorkerCompleted;
			worker.WorkerReportsProgress = true;

			ScanImageIsEnabled = true;
			LoaderVisibility = Visibility.Hidden;

			LoadColors();

			PickerConvert = new RelayParameterizedCommand(parameter => ConvertPickerColors());
			CelarPickerColors = new RelayParameterizedCommand(parameter => ClearPickedColors());
			CopyColorStringComm = new RelayParameterizedCommand(parameter => CopyColorString(parameter));
			DeleteColorComm = new RelayParameterizedCommand(async parameter => await DeleteColor(parameter));
			DeleteColorGroupComm = new RelayParameterizedCommand(async parameter => await DeleteGroup(parameter));

			ClearScansComm = new RelayParameterizedCommand(parameter => ClearScans());
		}

        public static bool IsOpenColorPickerMini { get; set; }

        public string _mouseHex { get; set; }
		public string MouseHex
		{
			get { return _mouseHex; }
			set
			{
				if (_mouseHex != value)
				{
					_mouseHex = value;
					LastSelectedBox = "hex";
				}
			}
		}

		public string _mouseRgb { get; set; }
		public string MouseRgb
		{
			get { return _mouseRgb; }
			set
			{
				if (_mouseRgb != value)
				{
					_mouseRgb = value;
					LastSelectedBox = "rgb";
				}
			}
		}

		public string _mouseArgb { get; set; }
		public string MouseArgb
		{
			get { return _mouseArgb; }
			set
			{
				if (_mouseArgb != value)
				{
					_mouseArgb = value;
					LastSelectedBox = "argb";
				}
			}
		}
		
		public bool MousePicker { get; set; }
		public string LastSelectedBox { get; set; }
		public static ObservableCollection<CoColor> PickedColors { get; set; }
		public static ObservableCollection<ColorGroups> ColorGroups { get; set; }
		public string Status { get; set; }

		public ColorGroups SelectedColorGroup { get; set; }
		public CoColor SelectedColor { get; set; }
		private readonly Stopwatch _stopwatch = new Stopwatch();
		private readonly BackgroundWorker worker = new BackgroundWorker();

		public ObservableCollection<CoColor> DominantColors { get; set; }

		public Visibility LoaderVisibility { get; set; }
		public bool ScanImageIsEnabled { get; set; }

		public CoColor SelectedDominantColor { get; set; }

		public string ImageName { get; set; }
		public BitmapImage ImageSource { get; set; }


		public void MediaColorToAll(System.Windows.Media.Color color)
		{
			var colors = Conversions.ConvertColors(color);
			MouseHex = colors.Hex;
			MouseRgb = colors.Rgb;
			MouseArgb = colors.Argb;

			AddItemToList(colors);
		}

		#region Commands

		public ICommand PickerConvert { get; set; }
		public ICommand CelarPickerColors { get; set; }
		public ICommand CopyColorStringComm { get; set; }
		public ICommand DeleteColorComm { get; set; }
		public ICommand DeleteColorGroupComm { get; set; }
		public ICommand ClearScansComm { get; set; }

		#endregion
		private MatchColor match { get; set; }

		public void ConvertPickerColors()
		{
			if (string.IsNullOrEmpty(LastSelectedBox))
			{
				MessageBox.Show("Bir renk türü için değer girin.", "Dönüştürme İşlemi Yapılamadı", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			Detector.Hash = true;
			switch (LastSelectedBox)
			{
				case "hex" : match = Detector.ParseExtract(MouseHex); break;
				case "rgb": match = Detector.ParseExtract(MouseHex); break;
				case "argb": match = Detector.ParseExtract(MouseHex); break;
			}

			if (match.Type == ColorType.Undefined)
			{
				MessageBox.Show("Geçersiz formatta veri girişi yapıldı, renk türü tanımlamadı.", "Dönüştürme İşlemi Yapılamaz", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			var colors = Conversions.ConvertColors(match.Color);
			MouseHex = colors.Hex;
			MouseRgb = colors.Rgb;
			MouseArgb = colors.Argb;

			AddItemToList(colors);
		}

		public void AddItemToList(Colors colors)
		{
			if (colors == null)
			{
				MessageBox.Show("Listeye eklenecek renk yok.", "Listeye Ekleme Başarısız", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			var newcolor = new CoColor()
			{
				HexCode = colors.Hex,
				RgbCode = colors.Rgb,
				ArgbCode = colors.Argb,
				InverseColorHex_1 = colors.InverseColorHex_1,
				InverseColorHex_2 = colors.InverseColorHex_2
			};

			PickedColors.Add(newcolor);
		}

		public void ClearPickedColors()
		{
			MouseHex = string.Empty;
			MouseRgb = string.Empty;
			MouseArgb = string.Empty;
			LastSelectedBox = string.Empty;
		}

		public bool SavePickedColors(string groupName)
		{
			if (PickedColors != null)
			{
				if (string.IsNullOrEmpty(groupName))
				{
					MessageBox.Show("Renk grubu için bir isim girin.", "Renk Grubu Kaydedilemez", MessageBoxButton.OK, MessageBoxImage.Warning);
					return false;
				}

				try
				{
					using (var conn = new SQLiteConnection(Connection.ConnString))
					{
						conn.Open();

						using (var comm = new SQLiteCommand(conn))
						{
							comm.CommandText = "INSERT INTO color_lib_groups (userid, title, star) values(?,?,?)";

							comm.Parameters.AddWithValue("@0", User.GetUserId());
							comm.Parameters.AddWithValue("@1", groupName);
							comm.Parameters.AddWithValue("@4", "0");

							var rows = comm.ExecuteNonQuery();
							if (rows > 0)
							{
								long i = 1;
								var groupid = conn.LastInsertRowId;
								foreach (var color in PickedColors)
								{
									using (var commcolor = new SQLiteCommand(conn))
									{
										commcolor.CommandText = "INSERT INTO color_lib_colors (userid, title, hex, rgb, argb, invert_hex_1, invert_hex_2, groupid, date) values(?,?,?,?,?,?,?,?,?)";

										commcolor.Parameters.AddWithValue("@0", User.GetUserId());
										commcolor.Parameters.AddWithValue("@1", $"Color #{i++}");
										commcolor.Parameters.AddWithValue("@2", color.HexCode);
										commcolor.Parameters.AddWithValue("@3", color.RgbCode);
										commcolor.Parameters.AddWithValue("@4", color.ArgbCode);
										commcolor.Parameters.AddWithValue("@6", color.InverseColorHex_1);
										commcolor.Parameters.AddWithValue("@7", color.InverseColorHex_2);
										commcolor.Parameters.AddWithValue("@8", groupid);
										commcolor.Parameters.AddWithValue("@9", DateTime.Now.ToString("dd-MM-yyyy HH':'mm':'ss"));

										var rowss = commcolor.ExecuteNonQuery();
									}

									color.RowId = conn.LastInsertRowId;
								}

								if (ColorGroups != null)
								{
									if (ColorGroups.Any(group => group.RowId != groupid))
									{
										var newgroup = new ColorGroups()
										{
											RowId = groupid,
											Title = groupName,
											Star = false,
											Colors = new ObservableCollection<CoColor>()
										};

										if (PickedColors != null)
										{
											int order = 1;
											foreach (var color in PickedColors)
											{
												var newcolor = new CoColor()
												{
													RowId = color.RowId,
													OrderNum = order++,
													HexCode = color.HexCode,
													RgbCode = color.RgbCode,
													ArgbCode = color.ArgbCode,
													Title = color.Title,

													InverseColorHex_1 = color.InverseColorHex_1,
													InverseColorHex_2 = color.InverseColorHex_2
												};

												newgroup.Colors.Add(newcolor);
											}
										}

										Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
										() =>
										{
											ColorGroups.Add(newgroup);
											SelectedColorGroup = newgroup;
										}));
									}
								}

								PickedColors.Clear();

								return true;
							}
						}

						conn.Close();
					}
				}
				catch (Exception exp)
				{
					MessageBox.Show(exp.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}

			return false;
		}

		public bool AddColor(string color, string title)
		{
			try
			{
				using (var conn = new SQLiteConnection(Connection.ConnString))
				{
					conn.Open();

					using (var comm = new SQLiteCommand(conn))
					{
						Colors colors = Conversions.ConvertColors(color);
						comm.CommandText = "INSERT INTO color_lib_colors (userid, title, hex, rgb, argb, invert_hex_1, invert_hex_2, groupid, date) values(?,?,?,?,?,?,?,?,?)";

						comm.Parameters.AddWithValue("@0", User.GetUserId());
						comm.Parameters.AddWithValue("@1", title);
						comm.Parameters.AddWithValue("@2", colors.Hex);
						comm.Parameters.AddWithValue("@3", colors.Rgb);
						comm.Parameters.AddWithValue("@4", colors.Argb);
						comm.Parameters.AddWithValue("@6", colors.InverseColorHex_1);
						comm.Parameters.AddWithValue("@7", colors.InverseColorHex_2);
						comm.Parameters.AddWithValue("@8", SelectedColorGroup.RowId);
						comm.Parameters.AddWithValue("@9", DateTime.Now.ToString("dd-MM-yyyy HH':'mm':'ss"));

						var rows = comm.ExecuteNonQuery();
						if (rows > 0)
						{
							var rowid = conn.LastInsertRowId;

							var newcolor = new CoColor()
							{
								RowId = rowid,
								Title = title,
								GroupId = SelectedColorGroup.RowId,
								HexCode = colors.Hex,
								RgbCode = colors.Rgb,
								ArgbCode = colors.Argb,
								InverseColorHex_1 = colors.InverseColorHex_1,
								InverseColorHex_2 = colors.InverseColorHex_2
							};

							if (ColorGroups.Any(group => group.RowId == SelectedColorGroup.RowId))
							{
								var i = 0;
								foreach (var group in ColorGroups)
								{
									var ii = i;
									Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
									() =>
									{
										ColorGroups[ii].Colors.Add(newcolor);
									}));

									i++;
								}
							}
						}
					}

					conn.Close();
					return true;
				}
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
			}

			return false;
		}

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
										Colors = new ObservableCollection<CoColor>()
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

													var coloradd = new CoColor()
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

			}
			catch (Exception exp)
			{
				Debug.WriteLine(exp.ToString());
			}
		}

		public bool AddGroup(string title, string desc = null)
		{
			try
			{
				using (var conn = new SQLiteConnection(Connection.ConnString))
				{
					conn.Open();

					using (var trns = conn.BeginTransaction())
					{
						using (var comm = new SQLiteCommand(conn))
						{
							comm.CommandText = "INSERT INTO color_lib_groups (userid, title, desc, desc_prev, star) values(?,?,?,?,?)";

							comm.Parameters.AddWithValue("@0", User.GetUserId());
							comm.Parameters.AddWithValue("@1", title);
							comm.Parameters.AddWithValue("@2",
								!string.IsNullOrEmpty(desc)
									? desc
									: string.Empty);
							comm.Parameters.AddWithValue("@3", !string.IsNullOrEmpty(desc)
									? ((desc).Length >= 200 ? (desc).Substring(0, 200) : desc)
									: string.Empty);
							comm.Parameters.AddWithValue("@4", "0");

							var rows = comm.ExecuteNonQuery();
							if (rows > 0)
							{
								var rowid = conn.LastInsertRowId;

								if (ColorGroups != null)
								{
									if (ColorGroups.Any(group => group.RowId != rowid))
									{
										var newgroup = new ColorGroups()
										{
											RowId = conn.LastInsertRowId,
											Title = title,
											Desc = desc,
											DescPrev = !string.IsNullOrEmpty(desc)
											? ((desc).Length >= 200
												? (desc).Substring(0, 200)
												: desc)
											: string.Empty,
											Star = false,
											Colors = new ObservableCollection<CoColor>()
										};

										Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
										() =>
										{
											ColorGroups.Add(newgroup);
											SelectedColorGroup = newgroup;
										}));

										Status = (title) + " eklendi (rowid " + rowid + ")";
									}
								}
								else
								{
									var newgroup = new ColorGroups()
									{
										RowId = conn.LastInsertRowId,
										Title = title,
										Desc = desc,
										DescPrev = !string.IsNullOrEmpty(desc)
										? ((desc).Length >= 200
											? (desc).Substring(0, 200)
											: desc)
										: string.Empty,
										Star = false,
										Colors = new ObservableCollection<CoColor>()
									};

									Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
									() =>
									{
										ColorGroups.Add(newgroup);
										SelectedColorGroup = newgroup;
									}));
								}
							}
						}

						trns.Commit();
					}

					conn.Close();

					return true;
				}
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
			}

			return false;
		}

		public void CopyColorString(object parameter)
		{
			Status = null;
			if (parameter == null)
				return;

			Clipboard.SetText((string)parameter);
		}

		public async Task DeleteColor(object parameter)
		{
			try
			{
				Status = null;
				if (parameter == null)
					return;

				await Task.Factory.StartNew(async () =>
				{
					using (var conn = new SQLiteConnection(Connection.ConnString))
					{
						conn.Open();

						using (var commup = new SQLiteCommand(conn))
						{
							commup.CommandText = "DELETE FROM color_lib_colors WHERE rowid='" + SelectedColor.RowId + "'";

							var rows = commup.ExecuteNonQuery();
							if (rows > 0)
							{
								foreach (var group in ColorGroups)
								{
									if (group.RowId == SelectedColor.GroupId)
									{
										foreach (var color in group.Colors)
										{
											if (color == SelectedColor)
											{
												await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
												() =>
												{
													group.Colors.Remove(color);
												}));

											}
										}
									}
								}
							}
						}

						conn.Close();
					}
				});
			}
			catch (Exception exp)
			{
				Debug.WriteLine(exp.ToString());
			}
		}

		public async Task DeleteGroup(object parameter)
		{
			try
			{
				if (parameter == null)
					return;

				using (var conn = new SQLiteConnection(Connection.ConnString))
				{
					conn.Open();

					using (var comm = new SQLiteCommand(conn))
					{
						comm.CommandText = "DELETE FROM color_lib_groups WHERE rowid='" + SelectedColorGroup.RowId + "'";

						var rows = comm.ExecuteNonQuery();
						if (rows > 0)
						{
							using (var comms = new SQLiteCommand(conn))
							{
								comms.CommandText = "DELETE FROM color_lib_colors WHERE groupid='" + SelectedColorGroup.RowId + "'";

								var rowss = comms.ExecuteNonQuery();

								foreach (var group in ColorGroups)
								{
									if (group.RowId == SelectedColorGroup.RowId)
									{
										ColorGroups.Remove(group);
										break;
									}
								}
							}
						}
					}

					conn.Close();
				}
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.ToString());
			}
		}

		private async void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			_stopwatch.Restart();

			try
			{
				OpenFileDialog opfiledialog = new OpenFileDialog
				{
					DefaultExt = ".jpg",
					Title = "Taramak istediğiniz resmi seçiniz."
				};

				bool? result = opfiledialog.ShowDialog();
				if (result == true)
				{
					if (DominantColors != null)
					{
						await Task.Run(() => Application.Current.Dispatcher.Invoke(async () =>
						{
							DominantColors.Clear();
						}));
					}

					Uri imageUri = new Uri(opfiledialog.FileName, UriKind.RelativeOrAbsolute);
					ImageName = Path.GetFileName(opfiledialog.FileName);
					await Task.Run(() => Application.Current.Dispatcher.Invoke(() =>
					{
						Status = Path.GetFileName(opfiledialog.FileName);
						ImageSource = new BitmapImage(imageUri);

						ScanImageIsEnabled = false;
						LoaderVisibility = Visibility.Visible;
					}));

					var bitmapImage = new BitmapImage(imageUri);
					var encoder = new PngBitmapEncoder();
					encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
					var stream = new MemoryStream();
					encoder.Save(stream);
					stream.Flush();
					var image = new Bitmap(stream);

					await Task.Run(() => Application.Current.Dispatcher.Invoke(() =>
					{
						Status += "  (" + image.Width + "x" + image.Height + " = " + Convert.ToDouble((image.Width * image.Height)).ToString("N0") + " piksel)";
					}));

					await Task.Delay(500);
					var colorThief = new ColorThief();


					if (image != null)
					{
						var colorpalette = colorThief.GetPalette(image, 10, 10, true);
						if (colorpalette != null)
						{
							foreach (var color in colorpalette)
							{
								KOR.ColorConversions.Colors colors = Conversions.ConvertColors(color.Color.ToHexString());

								await Task.Delay(100);
								var newcolor = new CoColor()
								{
									HexCode = colors.Hex,
									RgbCode = colors.Rgb,
									ArgbCode = colors.Argb,
									InverseColorHex_1 = colors.InverseColorHex_1,
									InverseColorHex_2 = colors.InverseColorHex_2
								};

								await Task.Run(() => Application.Current.Dispatcher.Invoke(() =>
								{
									DominantColors.Add(newcolor);
								}));
							}

							await Task.Run(() => Application.Current.Dispatcher.Invoke(() =>
							{
								LoaderVisibility = Visibility.Hidden;
								ScanImageIsEnabled = true;
							}));
						}
						else
						{
							Status = "Renk Bulunamadı";
						}
					}
					else
					{
						Status = "Görsel Boş";
					}
				}

				_stopwatch.Stop();
				await Task.Run(() => Application.Current.Dispatcher.Invoke(() =>
				{
					Status += " " + Math.Round(_stopwatch.Elapsed.TotalSeconds, 0) + " sn Sürdü.";
				}));
			}
			catch (Exception exp)
			{
				if (_stopwatch.IsRunning)
				{
					_stopwatch.Stop();
				}

				await Task.Run(() => Application.Current.Dispatcher.Invoke(() =>
				{
					LoaderVisibility = Visibility.Hidden;
					ScanImageIsEnabled = true;
				}));

				Debug.WriteLine(exp.ToString());
			}
			finally
			{
				if (DominantColors != null)
				{
					//CreateGradients();
				}
			}
		}

		private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//Status 
		}

		public ICommand ScanImageComm { get; set; }
		public void ScanImage(object parameter)
		{
			worker.RunWorkerAsync();
		}

		public ICommand SaveGroupComm { get; set; }
		public void SaveDominantColorsGroup(string title)
		{
			if (DominantColors == null)
			{
				Status = "Çıkartılmış herhangi bir renk yok. Taramak için bir görsel seçin ve taramanın bitmesini bekleyin.";
				return;
			}

			if (title == null)
			{
				Status = "Renk grubu isimsiz kaydedilemez";
				return;
			}

			try
			{
				using (var conn = new SQLiteConnection(Connection.ConnString))
				{
					conn.Open();

					using (var comm = new SQLiteCommand(conn))
					{
						comm.CommandText = "INSERT INTO color_lib_groups (userid, title, star) values(?,?,?)";

						comm.Parameters.AddWithValue("@0", User.GetUserId());
						comm.Parameters.AddWithValue("@1", title);
						comm.Parameters.AddWithValue("@4", "0");

						var rows = comm.ExecuteNonQuery();
						if (rows > 0)
						{
							var groupid = conn.LastInsertRowId;
							foreach (var color in DominantColors)
							{
								using (var commcolor = new SQLiteCommand(conn))
								{
									commcolor.CommandText = "INSERT INTO color_lib_colors (userid, hex, rgb, argb, invert_hex_1, invert_hex_2, groupid, date) values(?,?,?,?,?,?,?,?)";

									commcolor.Parameters.AddWithValue("@0", User.GetUserId());
									commcolor.Parameters.AddWithValue("@2", color.HexCode);
									commcolor.Parameters.AddWithValue("@3", color.RgbCode);
									commcolor.Parameters.AddWithValue("@4", color.ArgbCode);
									commcolor.Parameters.AddWithValue("@6", color.InverseColorHex_1);
									commcolor.Parameters.AddWithValue("@7", color.InverseColorHex_2);
									commcolor.Parameters.AddWithValue("@8", groupid);
									commcolor.Parameters.AddWithValue("@9", DateTime.Now.ToString("dd-MM-yyyy HH':'mm':'ss"));

									var rowsforcolor = commcolor.ExecuteNonQuery();
								}
							}

							if (ColorGroups != null)
							{
								if (ColorGroups.Any(group => group.RowId != groupid))
								{
									var newgroup = new ColorGroups()
									{
										RowId = groupid,
										Title = title,
										Star = false,
										Colors = new ObservableCollection<CoColor>()
									};

									if (DominantColors != null)
									{
										int order = 1;
										foreach (var color in DominantColors)
										{
											var newcolor = new CoColor()
											{
												RowId = color.RowId,
												OrderNum = order++,
												HexCode = color.HexCode,
												RgbCode = color.RgbCode,
												ArgbCode = color.ArgbCode,
												Title = color.Title,

												InverseColorHex_1 = color.InverseColorHex_1,
												InverseColorHex_2 = color.InverseColorHex_2
											};

											newgroup.Colors.Add(newcolor);
										}
									}

									Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
									() =>
									{
										ColorGroups.Add(newgroup);
										SelectedColorGroup = newgroup;
									}));
								}
							}

							Task.Run(() => Application.Current.Dispatcher.Invoke(() =>
							{
								Status = title + " renk grubu kaydedildi.";
							}));
						}
					}

					conn.Close();
				}
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public void ClearScans()
		{
			DominantColors.Clear();
		}

		#region Import - Export Colors

		public string ImporterStatus { get; set; }
		public Visibility ImporterLoaderVisibility { get; set; }
		public ICommand ImportColorsComm { get; set; }
		public RootobjectforColorImportExport ColorGroupJson { get; set; }
		public async Task ImportColors(object parameter)
		{
			try
			{
				await Task.Factory.StartNew(async () =>
				{
					OpenFileDialog opfiledialog = new OpenFileDialog();

					opfiledialog.DefaultExt = ".json";
					opfiledialog.Title = "Renkleri İçeri Aktar";

					bool? result = opfiledialog.ShowDialog();
					if (result == true)
					{
						var colorsjsontext = File.ReadAllText(opfiledialog.FileName);

						if (colorsjsontext != null)
						{
							int i = 0;

							dynamic jobj = JsonConvert.DeserializeObject(colorsjsontext);

							if (jobj != null)
							{
								await Task.Run(() => Application.Current.Dispatcher.Invoke(() =>
								{
									ImporterStatus = "İçerikler taranıyor...";
									ImporterLoaderVisibility = Visibility.Visible;
								}));
								await Task.Delay(1000);

								foreach (var groups in jobj)
								{
									if (groups != null)
									{
										foreach (var colors in groups)
										{
											ColorGroupJson = Newtonsoft.Json.JsonConvert.DeserializeObject<RootobjectforColorImportExport>(colors.ToString());

											if (ColorGroupJson.title != null && ColorGroupJson.colors != null)
											{
												using (var conn = new SQLiteConnection(Connection.ConnString))
												{
													conn.Open();

													using (var comm = new SQLiteCommand(conn))
													{
														comm.CommandText = "INSERT INTO color_lib_groups (userid, title, star) values(?,?,?)";

														comm.Parameters.AddWithValue("@0", User.GetUserId());
														comm.Parameters.AddWithValue("@1", ColorGroupJson.title);
														comm.Parameters.AddWithValue("@4", "0");

														var rows = comm.ExecuteNonQuery();

														if (rows > 0)
														{
															var groupid = conn.LastInsertRowId;

															#region Group Add to List

															// create new group
															var newgroup = new ColorGroups()
															{
																RowId = conn.LastInsertRowId,
																Title = ColorGroupJson.title,
																Desc = "",
																DescPrev = "",
																Star = false,
																Colors = new ObservableCollection<CoColor>()
															};

															// add new group
															if (ColorGroups != null)
															{
																if (ColorGroups.Any(group => group.RowId != groupid))
																{
																	await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
																	() =>
																	{
																		ColorGroups.Add(newgroup);
																		SelectedColorGroup = newgroup;
																		Status = ColorGroupJson.title + " renk grubu eklendi";
																	}));
																}
															}
															else
															{
																await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
																() =>
																{
																	ColorGroups.Add(newgroup);
																	SelectedColorGroup = newgroup;
																	Status = ColorGroupJson.title + " renk grubu eklendi";
																}));
															}

															#endregion

															foreach (var color in ColorGroupJson.colors)
															{
																KOR.ColorConversions.Colors colorss = Conversions.ConvertColors(color.hex);

																using (var commcolor = new SQLiteCommand(conn))
																{
																	commcolor.CommandText = "INSERT INTO color_lib_colors (userid, title, hex, rgb, argb, invert_hex_1, invert_hex_2, groupid, date) values(?,?,?,?,?,?,?,?,?)";

																	commcolor.Parameters.AddWithValue("@0", User.GetUserId());
																	commcolor.Parameters.AddWithValue("@1", color.title);
																	commcolor.Parameters.AddWithValue("@2", colorss.Hex);
																	commcolor.Parameters.AddWithValue("@3", colorss.Rgb);
																	commcolor.Parameters.AddWithValue("@4", colorss.Argb);
																	commcolor.Parameters.AddWithValue("@6", colorss.InverseColorHex_1);
																	commcolor.Parameters.AddWithValue("@7", colorss.InverseColorHex_2);
																	commcolor.Parameters.AddWithValue("@8", groupid);
																	commcolor.Parameters.AddWithValue("@9", DateTime.Now.ToString("dd-MM-yyyy HH':'mm':'ss"));

																	var colorrows = commcolor.ExecuteNonQuery();
																	if (colorrows > 0)
																	{
																		var colorid = conn.LastInsertRowId;

																		var newcolor = new CoColor()
																		{
																			RowId = colorid,
																			Title = color.title,
																			GroupId = groupid,
																			HexCode = colorss.Hex,
																			RgbCode = colorss.Rgb,
																			ArgbCode = colorss.Argb,
																			InverseColorHex_1 = colorss.InverseColorHex_1,
																			InverseColorHex_2 = colorss.InverseColorHex_2
																		};

																		if (ColorGroups.Any(group => group.RowId == groupid))
																		{
																			var ii = 0;
																			foreach (var group in ColorGroups)
																			{
																				await Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
																				() =>
																				{
																					ColorGroups[ii].Colors.Add(newcolor);
																					ImporterStatus = i + " Renk içeri aktarıldı.";
																				}));

																				ii++;
																			}
																		}

																		i++;
																		await Task.Delay(100);
																	}
																}
															}
														}
													}
													conn.Close();
												}
											}
										}
									}
								}
								await Task.Run(() => Application.Current.Dispatcher.Invoke(() =>
								{
									ImporterStatus = "İçeri aktarma işlemi tamamlandı. Toplam " + i + " renk aktarıldı.";
									ImporterLoaderVisibility = Visibility.Hidden;
								}));
							}
						}
						else
						{
							ImporterStatus = "Dosya içeriği boş olduğu için içeri aktarma başlatılamadı.";
						}
					}
				});
			}
			catch (Exception exp)
			{
				ImporterLoaderVisibility = Visibility.Hidden;
				Debug.WriteLine(exp.ToString());
			}
		}

		#endregion
	}

	/// <summary>
	/// Color Libraray Colors
	/// </summary>
	public class CoColor
	{
		public long RowId { get; set; }
		public long OrderNum { get; set; }
		public long GroupId { get; set; }

		public string Title { get; set; }
		public string HexCode { get; set; }
		public string RgbCode { get; set; }
		public string ArgbCode { get; set; }

		public string InverseColorHex_1 { get; set; }
		public string InverseColorHex_2 { get; set; }
	}

	public class ColorGroups
	{
		public long RowId { get; set; }

		public string Title { get; set; }
		public string Desc { get; set; }
		public string DescPrev { get; set; }
		public bool Star { get; set; }

		public ObservableCollection<CoColor> Colors { get; set; }
	}
}