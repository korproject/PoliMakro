using System.Windows;

namespace Poli.Makro.States
{
	/// <summary>
	/// Interaction logic for CommandLine.xaml
	/// </summary>
	public partial class CommandLine : Window
	{
		public CommandLine(object dataContext)
		{
			InitializeComponent();

			var window = SystemParameters.WorkArea;
			Left = window.Right - Width;
			Top = window.Bottom - Height;
		}
	}
}
