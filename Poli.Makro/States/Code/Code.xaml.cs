using System.Windows;
using Poli.Makro.Core;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using Poli.Makro.States.JXR;

namespace Poli.Makro.States.Code
{
	/// <summary>
	/// Interaction logic for Code.xaml
	/// </summary>
	public partial class Code : UserControl
	{
		public Core.ViewModel.Code.Code code = new Core.ViewModel.Code.Code();

		public Code()
		{
			InitializeComponent();

			DataContext = code;
		}

		private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Configs.SelectedSubTabHeader = (string)((TabItem)TabControl.SelectedItem).Header;
		}

		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			#region Folding

			// set highlighting theme
			foreach (var item in HighlightingComboBox.Items)
			{
				// get highlightings
				var hitem = (IHighlightingDefinition)item;
				// if there is json dark
				switch (hitem.Name)
				{
					case "CSharpDark":
						AvalonCodeEditor.SyntaxHighlighting = hitem;
						break;
				}
			}

			Folding();
			UpdateFoldings();

			#endregion
		}

		#region Avalon Folding

		FoldingManager _foldingManager;
		object _foldingStrategy;

		/// <summary>
		/// Folding method
		/// </summary>
		private void Folding()
		{
			if (AvalonCodeEditor.SyntaxHighlighting == null)
			{
				_foldingStrategy = null;
			}
			else
			{
				AvalonCodeEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
				_foldingStrategy = null;
			}
			if (_foldingStrategy != null)
			{
				if (_foldingManager == null)
					_foldingManager = FoldingManager.Install(AvalonCodeEditor.TextArea);
				UpdateFoldings();
			}
			else
			{
				if (_foldingManager == null) return;
				FoldingManager.Uninstall(_foldingManager);
				_foldingManager = null;
			}
		}

		/// <summary>
		/// Folding updater
		/// </summary>
		private void UpdateFoldings()
		{
			switch (_foldingStrategy)
			{
				case BraceFoldingStrategy _:
					((BraceFoldingStrategy)_foldingStrategy).UpdateFoldings(_foldingManager, AvalonCodeEditor.Document);
					break;
				case XmlFoldingStrategy _:
					((XmlFoldingStrategy)_foldingStrategy).UpdateFoldings(_foldingManager, AvalonCodeEditor.Document);
					break;
			}
		}

		#endregion

		#region Add New Language UI Dialog

		private void AddNewLanguage_Checked(object sender, RoutedEventArgs e)
		{
			var blurEffect = new BlurEffect
			{
				Radius = 7
			};

			CodeLibGrid.Effect = blurEffect;
			CodeLibGrid.IsEnabled = false;
			AddNewLanguageGrid.Visibility = Visibility.Visible;
		}

		private void AddNewLanguage_Unchecked(object sender, RoutedEventArgs e)
		{
			CodeLibGrid.Effect = null;
			CodeLibGrid.IsEnabled = true;
			AddNewLanguageGrid.Visibility = Visibility.Hidden;
			AddLanguageTB.IsChecked = false;
		}

		private async void AddLanguage(object sender, RoutedEventArgs e)
		{
			await code.AddLang(LanguageName.Text);
			AddNewLanguage_Unchecked(sender, e);
		}

		#endregion

		#region Add New Group UI Dialog

		private void AddNewGroup_Checked(object sender, RoutedEventArgs e)
		{
			var blurEffect = new BlurEffect
			{
				Radius = 7
			};

			CodeLibGrid.Effect = blurEffect;
			CodeLibGrid.IsEnabled = false;
			AddNewGroupGrid.Visibility = Visibility.Visible;
		}

		private void AddNewGroup_Unchecked(object sender, RoutedEventArgs e)
		{
			CodeLibGrid.Effect = null;
			CodeLibGrid.IsEnabled = true;
			AddNewGroupGrid.Visibility = Visibility.Hidden;
			AddGroupTB.IsChecked = false;
		}

		private async void AddGroup(object sender, RoutedEventArgs e)
		{
			await code.AddGroup(GroupName.Text);
			AddNewGroup_Unchecked(sender, e);
		}

		#endregion

		#region Add New Code UI Dialog

		private void AddNewCode_Checked(object sender, RoutedEventArgs e)
		{
			var blurEffect = new BlurEffect
			{
				Radius = 7
			};

			CodeLibGrid.Effect = blurEffect;
			CodeLibGrid.IsEnabled = false;
			AddNewCodeGrid.Visibility = Visibility.Visible;
		}

		private void AddNewCode_Unchecked(object sender, RoutedEventArgs e)
		{
			CodeLibGrid.Effect = null;
			CodeLibGrid.IsEnabled = true;
			AddNewCodeGrid.Visibility = Visibility.Hidden;
		}

		private async void AddCode(object sender, RoutedEventArgs e)
		{
			await code.AddCode(CodeName.Text);
			AddNewCode_Unchecked(sender, e);
		}

		#endregion

	}
}
