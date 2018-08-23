using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Threading;
using Poli.Makro.Core;
using Poli.Makro.Core.ClipboardManager.Hooks;
using Poli.Makro.Core.ViewModel.Color;

namespace Poli.Makro.States.Color
{
	/// <summary>
	/// Interaction logic for Color.xaml
	/// </summary>
	public partial class Color : UserControl
    {
		// Timer object
	    private DispatcherTimer Timer;
		private Core.ViewModel.Color.ColorHub colorHub = new Core.ViewModel.Color.ColorHub();

		/// <summary>
		/// Default constructor
		/// </summary>
		public Color()
        {
            InitializeComponent();

	        DataContext = colorHub;

			mouseHook.MouseMove += mouseHook_MouseMove;
	        InstallerMouseHook();

	        keyboardHook.KeyDown += keyboardHook_KeyDown;
	        keyboardHook.KeyUp += keyboardHook_KeyUp;
	        InstallerKeyboardHook();

			Timer = new DispatcherTimer
	        {
		        Interval = TimeSpan.FromMilliseconds(100)
	        };
			Timer.Tick += Timer_Tick;
	        Timer.Start();
		}

	    private void Timer_Tick(object sender, EventArgs e)
	    {
			mouseOvercolor = PikselRenginiGetir(Convert.ToInt32(GetMousePosition().X), Convert.ToInt32(GetMousePosition().Y));
		    MouseColorPicker.SelectedColor = mouseOvercolor;
			Brush brush = new SolidColorBrush(mouseOvercolor);
			MouseOverColorBorder.Background = brush;
		}

		#region Win Api

		#region Mouse Position

		[DllImport("user32.dll")]
	    [return: MarshalAs(UnmanagedType.Bool)]
	    internal static extern bool GetCursorPos(ref Win32Point pt);

	    [StructLayout(LayoutKind.Sequential)]
	    internal struct Win32Point
	    {
		    public Int32 X;
		    public Int32 Y;
	    }

	    #endregion

	    #region Mouse Point Color

	    [DllImport("user32.dll")]
	    static extern IntPtr GetDC(IntPtr hwnd);

	    [DllImport("user32.dll")]
	    static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

	    [DllImport("gdi32.dll")]
	    static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

		#endregion

		#endregion


	    /// <summary>
	    /// define mouse hook
	    /// </summary>
	    public static MouseHook mouseHook = new MouseHook();

	    /// <summary>
	    /// define keyboard hook
	    /// </summary>
	    public static KeyboardHook keyboardHook = new KeyboardHook();
	    private static bool LCTRL;

		public static bool WatchMousePosition;
	    public static string MousePosition = string.Empty;
	    public static System.Windows.Media.Color mouseOvercolor;

		#region Mouse Actions

		void mouseHook_MouseMove(MouseHook.MSLLHOOKSTRUCT mouseStruct)
	    {
		    MousePositions.Text = MousePosition = $"X: {mouseStruct.pt.x} - Y: {mouseStruct.pt.y}";
		}

		#endregion

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
		private void keyboardHook_KeyDown(KeyboardHook.VKeys key)
		{
			if (key == KeyboardHook.VKeys.LCONTROL)
			{
				LCTRL = true;
			}

			if (LCTRL && key == KeyboardHook.VKeys.KEY_G)
			{
				mouseOvercolor = PikselRenginiGetir(Convert.ToInt32(GetMousePosition().X), Convert.ToInt32(GetMousePosition().Y));
				MouseColorPicker.SelectedColor = mouseOvercolor;

				Brush brush = new SolidColorBrush(mouseOvercolor);
				MouseOverColorBorder.Background = brush;

				colorHub.MediaColorToAll(mouseOvercolor);
			}
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
			else if (choice == false)
			{
				mouseHook.Uninstall();
				Debug.WriteLine("Mouse Hook Uninstalled: " + mouseHook.hookID);
			}
		}

	    public static Point GetMousePosition()
	    {
			var w32Mouse = new Win32Point();
		    GetCursorPos(ref w32Mouse);
		    return new Point(w32Mouse.X, w32Mouse.Y);
	    }

	    public static System.Windows.Media.Color PikselRenginiGetir(int x, int y)
	    {
			var hdc = GetDC(IntPtr.Zero);
		    var pixel = GetPixel(hdc, x, y);
		    ReleaseDC(IntPtr.Zero, hdc);
		    var color = System.Windows.Media.Color.FromRgb((byte)((int)(pixel & 0x000000FF) + 1), (byte)((int)(pixel & 0x0000FF00) >> 8), (byte)((int)(pixel & 0x00FF0000) >> 16));
		    return color;
	    }

		#endregion

		private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
	    {
		    Configs.SelectedSubTabHeader = (string)((TabItem)TabControl.SelectedItem).Header;

			if (TabControl.SelectedIndex != 0)
			{
				Timer.Stop();
			}
			else if (TabControl.SelectedIndex == 0)
			{
				if (Timer != null)
				{
					Timer.Start();
				}
			}
		}

		#region Save As Picked Colors UI Dialog

		private void SaveAsPickedColors_Checked(object sender, RoutedEventArgs e)
		{
			var blurEffect = new BlurEffect
			{
				Radius = 7
			};

			ColorPickerGrid.Effect = blurEffect;
			ColorPickerGrid.IsEnabled = false;
			PickedGroupSaveGrid.Visibility = Visibility.Visible;

			InstallerMouseHook(false);
			InstallerKeyboardHook(false);
		}

		private void PickedGroupSave_Close(object sender, RoutedEventArgs e)
		{
			ColorPickerGrid.Effect = null;
			ColorPickerGrid.IsEnabled = true;
			PickedGroupSaveGrid.Visibility = Visibility.Hidden;
			InstallerMouseHook(true);
			InstallerKeyboardHook(true);
		}

		private void SavePickedColors(object sender, RoutedEventArgs e)
		{
			if (colorHub.SavePickedColors(PickedColorsGroupName.Text))
			{
				MessageBox.Show($"Renk grubu: {PickedColorsGroupName.Text} kaydedildi.", "İşlem Başarılı", MessageBoxButton.OK, MessageBoxImage.Warning);
				PickedGroupSave_Close(sender, e);
			}
		}

		#endregion

		#region Save New Color UI Dialog

		private void AddNewColor_Checked(object sender, RoutedEventArgs e)
		{
			if (AddNewGroupGrid.Visibility == Visibility.Visible)
			{
				AddNewGroup_Close(sender, e);
				AddNewGroupTb.IsChecked = false;
			}

			var blurEffect = new BlurEffect
			{
				Radius = 7
			};

			ColorLibGrid.Effect = blurEffect;
			ColorLibGrid.IsEnabled = false;
			AddNewColorGrid.Visibility = Visibility.Visible;
		}

		private void AddNewColor_Close(object sender, RoutedEventArgs e)
		{
			ColorLibGrid.Effect = null;
			ColorLibGrid.IsEnabled = true;
			AddNewColorGrid.Visibility = Visibility.Hidden;
			AddNewColorTB.IsChecked = false;
		}

		private void SaveColor(object sender, RoutedEventArgs e)
		{
			if (colorHub.AddColor(AddColorString.Text, AddColorTitle.Text))
			{
				AddNewColor_Close(sender, e);
			}
		}


		#endregion

		#region Add New Color Group UI Dialog

		private void AddNewGroup_Checked(object sender, RoutedEventArgs e)
		{
			if (AddNewColorGrid.Visibility == Visibility.Visible)
			{
				AddNewColor_Close(sender, e);
				AddNewColorTB.IsChecked = false;
			}

			var blurEffect = new BlurEffect
			{
				Radius = 7
			};

			ColorLibGrid.Effect = blurEffect;
			ColorLibGrid.IsEnabled = false;
			AddNewGroupGrid.Visibility = Visibility.Visible;
		}

		private void AddNewGroup_Close(object sender, RoutedEventArgs e)
		{
			ColorLibGrid.Effect = null;
			ColorLibGrid.IsEnabled = true;
			AddNewGroupGrid.Visibility = Visibility.Hidden;
			AddNewGroupTb.IsChecked = false;
		}

		private void SaveGroup(object sender, RoutedEventArgs e)
		{
			if (colorHub.AddGroup(AddGroupTitle.Text))
			{
				AddNewGroup_Close(sender, e);
			} else
			{
				MessageBox.Show("Renk grubu kaydedilemedi", "İşlem Başarısız", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		#endregion

		#region Save Dominant Color UI Dialog

		private void SaveDominantColorsGroup_Checked(object sender, RoutedEventArgs e)
		{
			var blurEffect = new BlurEffect
			{
				Radius = 7
			};

			DominantColorsGrid.Effect = blurEffect;
			DominantColorsGrid.IsEnabled = false;
			DominantColorsGroupSaveGrid.Visibility = Visibility.Visible;
		}

		private void DominantColorsGroupSave_Close(object sender, RoutedEventArgs e)
		{
			DominantColorsGrid.Effect = null;
			DominantColorsGrid.IsEnabled = true;
			DominantColorsGroupSaveGrid.Visibility = Visibility.Hidden;
			SaveDominantColorsGroupTB.IsChecked = false;
		}

		private void SaveDominantColors(object sender, RoutedEventArgs e)
		{
			colorHub.SaveDominantColorsGroup(DominantColorsGroupName.Text);
			DominantColorsGroupSave_Close(sender, e);
		}

		#endregion

		private void ColorWatcher_Checked(object sender, RoutedEventArgs e)
		{
			Timer.Stop();
		}

		private void ColorWatcher_Unchecked(object sender, RoutedEventArgs e)
		{
			if (Timer != null)
			{
				Timer.Start();
			}
		}

        ColorPickerMini pickermini = new ColorPickerMini();
        private void ColorPickerMini_Checked(object sender, RoutedEventArgs e)
		{
            if (!ColorHub.IsOpenColorPickerMini == false)
            {
                pickermini.Show();
            }
		}

		private void ColorPickerMini_Close(object sender, RoutedEventArgs e)
		{
            pickermini.Hide();
        }
	}
}
