using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using Hardcodet.Wpf.TaskbarNotification;
using Poli.Makro.Core;
using Poli.Makro.Core.ClipboardManager.Clipboard;
using Poli.Makro.Core.ClipboardManager.Monitor;
using Poli.Makro.Core.ViewModel.MainWindow;
using Poli.Makro.NotifyIcon;
using Poli.Makro.Properties;
using Poli.Makro.States.Color;

namespace Poli.Makro.Main
{
    /// <summary>
    /// Interaction logic for Base.xaml
    /// </summary>
    public partial class Base : Window
    {
		private MainWindow mainwindow = new MainWindow();
		public static WindowClipboardMonitor _clipboardMonitor;
		private DispatcherTimer Timer;
        private DispatcherTimer TimerHooker;
        private DispatcherTimer BuildCounter;

        public ClipboardEnviroment clipboardenv = new ClipboardEnviroment();

		public Base()
        {
            InitializeComponent();
			DataContext = mainwindow;

			var balloon = new WelcomeBalloon();
			MyNotifyIcon.ShowCustomBalloon(balloon, PopupAnimation.Scroll, 15000);

			MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
			MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
		}

		#region Window Move

		#region Events

		/// <summary>
		/// Install hook when window source initalized
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_SourceInitialized(object sender, EventArgs e)
		{
			IntPtr intPtr = (new WindowInteropHelper(this)).Handle;
			HwndSource.FromHwnd(intPtr)?.AddHook(new HwndSourceHook(WindowProc));
		}

		/// <summary>
		/// Moving state
		/// </summary>
		private bool Move = false;

		/// <summary>
		/// Hanging mouse button down for move action
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MoveLayer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
			try
			{
				if (e.LeftButton == MouseButtonState.Pressed)
				{
					DragMove();
				}
			}
			catch { }
        }

		/// <summary>
		/// Double click to window maximize
		/// Single click to move
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void MoveLayer_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
			try
			{
				if (e.ClickCount == 2)
				{
					if ((ResizeMode == ResizeMode.CanResize) || (ResizeMode == ResizeMode.CanResizeWithGrip))
					{
						ChangeWindowState();
					}

					return;
				}
				else if (WindowState == WindowState.Maximized)
				{
					Move = true;

					return;
				}

				DragMove();
			}
			catch { }
        }

		/// <summary>
		/// Finish moving
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void MoveLayer_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Move = false;
        }

		/// <summary>
		/// Move window with layer
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void MoveLayer_PreviewMouseMove(object sender, MouseEventArgs e)
        {
			try
			{
				if (Move == true)
				{
					Move = false;

					double horizonalPercent = e.GetPosition(this).X / ActualWidth;
					double horizonalValue = RestoreBounds.Width * horizonalPercent;

					double verticalPercent = e.GetPosition(this).Y / ActualHeight;
					double verticalValue = RestoreBounds.Height * verticalPercent;

					if (WindowState != WindowState.Normal)
					{
						WindowState = WindowState.Normal;
					}

					// Farenin konumu alınır
					PointCoordinate FareninKonumu;
					GetCursorPos(out FareninKonumu);

					Left = FareninKonumu.X - horizonalValue;
					Top = FareninKonumu.Y - verticalValue;

					DragMove();
				}
			}
			finally
			{
				AppSettings.WindowTop = Top;
				AppSettings.WindowLeft = Left;
				AppSettings.WindowWidth = Width;
				AppSettings.WindowHeight = Height;
			}
		}

		#endregion

		#region WinAPI

		[DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out PointCoordinate lpPoint);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr MonitorFromPoint(PointCoordinate pt, MonitorOptions dwFlags);

        public enum MonitorOptions : uint
        {
            MONITOR_DEFAULTTONULL = 0x00000000,
            MONITOR_DEFAULTTOPRIMARY = 0x00000001,
            MONITOR_DEFAULTTONEAREST = 0x00000002
        }

        [DllImport("user32.dll")]
        static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [StructLayout(LayoutKind.Sequential)]
        public struct PointCoordinate
        {
            // X apsis için
            public int X;
            // Y ordinat için
            public int Y;

            public PointCoordinate(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public PointCoordinate ptReserved;
            public PointCoordinate ptMaxSize;
            public PointCoordinate ptMaxPosition;
            public PointCoordinate ptMinTrackSize;
            public PointCoordinate ptMaxTrackSize;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
            public RECT rcMonitor = new RECT();
            public RECT rcWork = new RECT();
            public int dwFlags = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left, Top, Right, Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }
        }

        private static IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    WmGetMinMaxInfo(hwnd, lParam);
                    break;
            }

            return IntPtr.Zero;
        }

        private static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            PointCoordinate lMousePosition;
            GetCursorPos(out lMousePosition);

            IntPtr lPrimaryScreen = MonitorFromPoint(new PointCoordinate(0, 0), MonitorOptions.MONITOR_DEFAULTTOPRIMARY);
            MONITORINFO lPrimaryScreenInfo = new MONITORINFO();
            if (GetMonitorInfo(lPrimaryScreen, lPrimaryScreenInfo) == false)
            {
                return;
            }

            IntPtr lCurrentScreen = MonitorFromPoint(lMousePosition, MonitorOptions.MONITOR_DEFAULTTONEAREST);

            MINMAXINFO lMmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            if (lPrimaryScreen.Equals(lCurrentScreen) == true)
            {
                lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcWork.Left;
                lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcWork.Top;
                lMmi.ptMaxSize.X = lPrimaryScreenInfo.rcWork.Right - lPrimaryScreenInfo.rcWork.Left;
                lMmi.ptMaxSize.Y = lPrimaryScreenInfo.rcWork.Bottom - lPrimaryScreenInfo.rcWork.Top;
            }
            else
            {
                lMmi.ptMaxPosition.X = lPrimaryScreenInfo.rcMonitor.Left;
                lMmi.ptMaxPosition.Y = lPrimaryScreenInfo.rcMonitor.Top;
                lMmi.ptMaxSize.X = lPrimaryScreenInfo.rcMonitor.Right - lPrimaryScreenInfo.rcMonitor.Left;
                lMmi.ptMaxSize.Y = lPrimaryScreenInfo.rcMonitor.Bottom - lPrimaryScreenInfo.rcMonitor.Top;
            }

            Marshal.StructureToPtr(lMmi, lParam, true);
        }

		#endregion

		#region Methods

		/// <summary>
		/// Window state changed
		/// </summary>
		private void ChangeWindowState()
        {
            switch (WindowState)
            {
                case WindowState.Normal:
					WindowState = WindowState.Maximized;
					break;
				case WindowState.Maximized:
					WindowState = WindowState.Normal;
					break;
            }
        }

		#endregion

		#endregion

		/// <summary>
		/// Main Windows on loaded event
		/// </summary>
		public void Window_OnLoaded(object sender, RoutedEventArgs e)
		{
            Timer = new DispatcherTimer(TimeSpan.FromMilliseconds(100), DispatcherPriority.Normal, delegate
            {
                Title.Text = $"Poli Makro - {Configs.SelectedTabHeader} > {Configs.SelectedSubTabHeader} ({Settings.Default.Build})";
            }, Application.Current.Dispatcher);
            Timer.Start();

            #if DEBUG
            BuildCounter = new DispatcherTimer(TimeSpan.FromSeconds(30), DispatcherPriority.Normal, delegate
            {
                #region Build Counter

                Settings.Default.Build = (Settings.Default.Build + 1);
                Settings.Default.Save();

                #endregion

                BuildCounter.Stop();

            }, Application.Current.Dispatcher);
            BuildCounter.Start();
            #endif

            TimerHooker = new DispatcherTimer(TimeSpan.FromSeconds(3), DispatcherPriority.Normal, delegate
            {
                // set monitor window
                _clipboardMonitor = new WindowClipboardMonitor(this);
                // set clipboard text changed event handler
                _clipboardMonitor.ClipboardTextChanged += ClipboardEnviroment.ClipboardTextChanged;
                // set clipboard image changed event handler
                _clipboardMonitor.ClipboardImageChanged += ClipboardEnviroment.ClipboardImageChanged;
                // install hooker
                ClipboardEnviroment.Hooker();

                TimerHooker.Stop();
            }, Application.Current.Dispatcher);
            TimerHooker.Start();
        }

		private void SideBarTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Configs.SelectedTabHeader = (string)((TabItem)SideBarTabControl.SelectedItem).Header;
            Configs.SelectedSubTabHeader = "^^";
        }

		/// <summary>
		/// Window size changede event
		/// </summary>
		private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (WindowState == WindowState.Maximized)
			{
				mainwindow.WindowState = WindowState.Maximized;
				mainwindow.MaximinimizeIsChecked = true;
				AppSettings.WindowState = 2;
			}
			else if (WindowState == WindowState.Normal)
			{
				mainwindow.WindowState = WindowState.Normal;
				mainwindow.MaximinimizeIsChecked = false;
				AppSettings.WindowState = 1;
			}

			if (WindowState != WindowState.Maximized)
			{
				AppSettings.WindowTop = Top;
				AppSettings.WindowLeft = Left;
				AppSettings.WindowWidth = Width;
				AppSettings.WindowHeight = Height;
			}
		}

		/// <summary>
		/// Dispose clipboard monitor, notify icon and other things
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DisposeSomethings(object sender, RoutedEventArgs e)
		{
			try
			{
				// unset clipboard text changed event handler
				_clipboardMonitor.ClipboardTextChanged -= ClipboardEnviroment.ClipboardTextChanged;
				// unset clipboard image changed event handler
				_clipboardMonitor.ClipboardImageChanged -= ClipboardEnviroment.ClipboardImageChanged;
				// diposing monitor
				_clipboardMonitor.Dispose();
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.ToString(), "Klavye - Fare Dinleyici Hata", MessageBoxButton.OK, MessageBoxImage.Error);
			}
			finally
			{
				MyNotifyIcon.Dispose();
			}
		}

		private void ColorPickerMini_Click(object sender, RoutedEventArgs e)
		{
			ColorPickerMini cpMini = new ColorPickerMini();
			cpMini.Show();
		}

		private void OpenCommandConsole(object sender, RoutedEventArgs e)
		{
			States.CommandLine commLine = new States.CommandLine(DataContext);
			commLine.Show();
		}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
