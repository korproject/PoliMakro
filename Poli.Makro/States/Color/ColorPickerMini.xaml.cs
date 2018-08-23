using Poli.Makro.Core.ViewModel.Color;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Poli.Makro.States.Color
{
	/// <summary>
	/// Interaction logic for ColorPickerMini.xaml
	/// </summary>
	public partial class ColorPickerMini : Window
	{
		// Timer object
		private DispatcherTimer Timer;
		public static string MousePosition = string.Empty;
		public static System.Windows.Media.Color mouseOvercolor;
		public static bool WatchMousePosition;

		/// <summary>
		/// Default constructor
		/// </summary>
		public ColorPickerMini()
		{
			InitializeComponent();

            ColorHub.IsOpenColorPickerMini = true;

            Timer = new DispatcherTimer
			{
				Interval = TimeSpan.FromMilliseconds(100)
			};
			Timer.Tick += Timer_Tick;
			Timer.Start();

			var window = SystemParameters.WorkArea;
			Left = window.Right - Width;
			Top = window.Bottom - Height;
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

		private void Timer_Tick(object sender, EventArgs e)
		{
			mouseOvercolor = PikselRenginiGetir(Convert.ToInt32(GetMousePosition().X), Convert.ToInt32(GetMousePosition().Y));
			Brush brush = new SolidColorBrush(mouseOvercolor);
			Ellipse.Fill = brush;
		}

		private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (e.ClickCount == 2)
				{
					if (WatchMousePosition)
					{
						Timer.Stop();
					}
					else if(!WatchMousePosition)
					{
						Timer.Start();
					}
				}

				if (e.LeftButton == MouseButtonState.Pressed)
				{
					DragMove();
				}
			}
			catch (Exception exp)
			{
				Debug.WriteLine(exp);
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

		private void CopyHexCode_Click(object sender, RoutedEventArgs e)
		{
			if (Core.ViewModel.Color.ColorHub.PickedColors != null)
			{
				if (Core.ViewModel.Color.ColorHub.PickedColors.Count > 0)
				{
					System.Windows.Clipboard.SetText(Core.ViewModel.Color.ColorHub.PickedColors[Core.ViewModel.Color.ColorHub.PickedColors.Count - 1].HexCode);
				}
			}
		}

		private void CopyRgbCode_Click(object sender, RoutedEventArgs e)
		{
			if (Core.ViewModel.Color.ColorHub.PickedColors != null)
			{
				if (Core.ViewModel.Color.ColorHub.PickedColors.Count > 0)
				{
					System.Windows.Clipboard.SetText(Core.ViewModel.Color.ColorHub.PickedColors[Core.ViewModel.Color.ColorHub.PickedColors.Count - 1].RgbCode);
				}
			}
		}

		private void CopyArgbCode_Click(object sender, RoutedEventArgs e)
		{
			if (Core.ViewModel.Color.ColorHub.PickedColors != null)
			{
				if (Core.ViewModel.Color.ColorHub.PickedColors.Count > 0)
				{
					System.Windows.Clipboard.SetText(Core.ViewModel.Color.ColorHub.PickedColors[Core.ViewModel.Color.ColorHub.PickedColors.Count - 1].ArgbCode);
				}
			}
		}

		private void CopyInverted1HexCode_Click(object sender, RoutedEventArgs e)
		{
			if (Core.ViewModel.Color.ColorHub.PickedColors != null)
			{
				if (Core.ViewModel.Color.ColorHub.PickedColors.Count > 0)
				{
					System.Windows.Clipboard.SetText(Core.ViewModel.Color.ColorHub.PickedColors[Core.ViewModel.Color.ColorHub.PickedColors.Count - 1].InverseColorHex_1);
				}
			}
		}

		private void CopyInverted2HexCode_Click(object sender, RoutedEventArgs e)
		{
			if (Core.ViewModel.Color.ColorHub.PickedColors != null)
			{
				if (Core.ViewModel.Color.ColorHub.PickedColors.Count > 0)
				{
					System.Windows.Clipboard.SetText(Core.ViewModel.Color.ColorHub.PickedColors[Core.ViewModel.Color.ColorHub.PickedColors.Count - 1].InverseColorHex_2);
				}
			}
		}

        private void Close(object sender, RoutedEventArgs e)
        {
            ColorHub.IsOpenColorPickerMini = false;
            Hide();
        }
    }
}
