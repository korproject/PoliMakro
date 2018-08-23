using Poli.Makro.Core.Database;
using Poli.Makro.Core.ViewModel.Base;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Poli.Makro.Core.ViewModel.MainWindow
{
	public class MainWindow : BaseViewModel
    {
		public MainWindow()
        {
			// window state setting loader
			LoadWindowState();
			// window top most setting loader
			LoadWindowTopMost();
			// windowlocation setting laoder
			LoadWindowLocation();

			#region Default Settings

			WindowMinWidth = 750;
			WindowMinHeight = 600;

			#endregion
			UserInfo = User.GetUserInfo();

			WindowStateComm = new RelayParameterizedCommand(parameter => ResetWindowState());
			RestartAppComm = new RelayParameterizedCommand(parameter => RestartApp());
			CloseAppComm = new RelayParameterizedCommand(parameter => CloseApp());
			MinimizeComm = new RelayParameterizedCommand(parameter => Minimize());
			WindowTopMostComm = new RelayParameterizedCommand(parameter => ResetWindowTopMost());
		}

		public UserInfo UserInfo { get; set; }

		#region Window Top Side Actions

		/// <summary>
		/// Window top most toggle button is checked
		/// </summary>
		public bool WindowTopMostIsChecked { get; set; }

		/// <summary>
		/// Window top most state
		/// </summary>
		public bool WindowTopMost { get; set; }

		/// <summary>
		/// Window top most command
		/// </summary>
		public ICommand WindowTopMostComm { get; set; }

		/// <summary>
		/// Window top most method
		/// </summary>
		public void ResetWindowTopMost()
		{
			Color.ColorHub.ColorGroups.Add(new Color.ColorGroups() { Title = "AAAAAAAAA" });

			WindowTopMost = !WindowTopMost;
			WindowTopMostIsChecked = WindowTopMost;
			AppSettings.WindowTopMost = WindowTopMost ? 1 : 0;
		}

		/// <summary>
		/// Loads window top most setting
		/// </summary>
		public void LoadWindowTopMost()
		{
			WindowTopMost = AppSettings.WindowTopMost == 1 ? true : false;
			WindowTopMostIsChecked = WindowTopMost;
		}

		/// <summary>
		/// Minimize window command
		/// </summary>
		public ICommand MinimizeComm { get; set; }

		/// <summary>
		/// Minimize window method
		/// </summary>
		public void Minimize()
		{
			if (WindowState != WindowState.Minimized)
			{
				WindowState = WindowState.Minimized;
				AppSettings.WindowState = 0;
			}
		}

		/// <summary>
		/// Maximize-Minimize toggle button is checked
		/// </summary>
		public bool MaximinimizeIsChecked { get; set; }

		/// <summary>
		/// WindowState property
		/// </summary>
		public WindowState WindowState { get; set; }

		/// <summary>
		/// WindowState reset command
		/// </summary>
		public ICommand WindowStateComm { get; set; }

		/// <summary>
		/// Window reset WindowState to maximize or normal
		/// </summary>
		public void ResetWindowState()
		{
			if (WindowState != WindowState.Maximized)
			{
				WindowState = WindowState.Maximized;
				AppSettings.WindowState = 2;
			}
			else if (WindowState == WindowState.Maximized)
			{
				WindowState = WindowState.Normal;
				AppSettings.WindowState = 1;
			}
		}

		/// <summary>
		/// Get and set WindowState setting when loaded
		/// </summary>
		public void LoadWindowState()
		{
			if (AppSettings.WindowState == 0)
			{
				WindowState = WindowState.Minimized;
			} else if (AppSettings.WindowState == 1)
			{
				WindowState = WindowState.Normal;
			} else if (AppSettings.WindowState == 2)
			{
				WindowState = WindowState.Maximized;
			}
		}

		/// <summary>
		/// App resart command
		/// </summary>
		public ICommand RestartAppComm { get; set; }
		
		/// <summary>
		/// App restart method
		/// </summary>
		public void RestartApp()
		{
			AppSettings.SaveWindowState();
			AppSettings.SaveWindowTopMost();
			AppSettings.SaveWindowLocation();

			Process.Start(Application.ResourceAssembly.Location);
			Environment.Exit(Environment.ExitCode);
		}

		/// <summary>
		/// App close command
		/// </summary>
		public ICommand CloseAppComm { get; set; }

		/// <summary>
		/// App close method
		/// </summary>
		public void CloseApp()
		{
			AppSettings.SaveWindowState();
			AppSettings.SaveWindowTopMost();
			AppSettings.SaveWindowLocation();

			Environment.Exit(Environment.ExitCode);
		}

		#endregion

		#region Window Location

		public double WindowMinWidth { get; set; }
		public double WindowMinHeight { get; set; }

		public double WindowTop { get; set; }
		public double WindowLeft { get; set; }
		public double WindowHeight { get; set; }
		public double WindowWidth { get; set; }

		/// <summary>
		/// load window location
		/// </summary>
		public void LoadWindowLocation()
		{
			WindowTop = AppSettings.WindowTop;
			WindowLeft = AppSettings.WindowLeft;
			WindowWidth = AppSettings.WindowWidth;
			WindowHeight = AppSettings.WindowHeight;
		}

		#endregion
	}
}
