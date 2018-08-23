using Poli.Makro.Core.Database;
using Poli.Makro.Main;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Poli.Makro.States.Settings
{
	/// <summary>
	/// Interaction logic for Settings.xaml
	/// </summary>
	public partial class Settings : UserControl
	{
		Core.ViewModel.Settings.Settings settings = new Core.ViewModel.Settings.Settings();

		public Settings()
		{
			InitializeComponent();

			DataContext = settings;
		}

		private void LogOutUserTGB_Click(object sender, RoutedEventArgs e)
		{
			LogOutUserTGB.IsEnabled = false;

			if (User.LogOutUser())
			{
				Process.Start(Application.ResourceAssembly.Location);
				Environment.Exit(Environment.ExitCode);
			}
			else
			{
				LogOutUserTGB.IsEnabled = true;
			}
		}
	}
}
