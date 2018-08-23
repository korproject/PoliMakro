using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Effects;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Win32;
using Poli.Makro.Core;
using Poli.Makro.Core.Helpers.Xml;

namespace Poli.Makro.States.JXR
{
	/// <summary>
	/// Interaction logic for JXR_Editor.xaml
	/// </summary>
	public partial class JXR_Editor : UserControl
	{
		private bool _jsonTreeCollapsed;
		private bool _xmlTreeCollapsed;
		private DispatcherTimer Timer;
		private string XmlWebError = string.Empty;
		private const GeneratorStatus Üretici = GeneratorStatus.ContainersGenerated;

		private readonly Core.ViewModel.JXR.JXR _jxr = new Core.ViewModel.JXR.JXR();

		/// <summary>
		/// Defaul constructor
		/// </summary>
		public JXR_Editor()
		{
			InitializeComponent();

			DataContext = _jxr;
		}


		#region JSON Area

		/// <summary>
		/// Json tree view item double click copy value to clipboard
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void JValue_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount != 2)
				return;

			if (sender is TextBlock tb)
			{
				System.Windows.Clipboard.SetText(tb.Text.TrimStart('"').TrimEnd('"'));
			}
		}

		/// <summary>
		/// Json Tree Viewer Expander - Collapser
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void JsonTreeExpandCollapse(object sender, RoutedEventArgs e)
		{
			// is it collapsed
			if (_jsonTreeCollapsed)
			{
				// expand items
				TreeExpCollapser(JsonTree, true);
				_jsonTreeCollapsed = false;
			}
			else
			{
				// collapse items
				TreeExpCollapser(JsonTree, false);
				_jsonTreeCollapsed = true;
			}
		}

		#region Json Get From Web UI Dialog

		private void GetFromWebChecked(object sender, RoutedEventArgs e)
		{
			var blurEffect = new BlurEffect();
			blurEffect.Radius = 7;
			JsonEditorGrid.Effect = blurEffect;
			JsonEditorGrid.IsEnabled = false;
			GetFromWebGrid.Visibility = Visibility.Visible;
		}

		private void GetJsonFromWebClose(object sender, RoutedEventArgs e)
		{
			JsonEditorGrid.Effect = null;
			JsonEditorGrid.IsEnabled = true;
			GetFromWebGrid.Visibility = Visibility.Hidden;
		}

		private void JsonGetFromWeb(object sender, RoutedEventArgs e)
		{
			if (_jxr.LoadJsonFromWeb(GetJsonURL.Text))
			{
				GetJsonFromWebClose(sender, e);
			}
			else if (_jxr.JsonWebError != null)
			{
				MessageBox.Show(_jxr.JsonWebError ?? "Geçersiz İçerik", "İşlem Başarısız oldu", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		#endregion

		/// <summary>
		/// Json editor open file on drag and dropping
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void JsonEditorGrid_OnDrop(object sender, DragEventArgs e)
		{
			// handle it
			if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

			// get dropped file/s
			var files = (string[])e.Data.GetData(DataFormats.FileDrop);

			// send to function
			if (files != null) _jxr.LoadJsonFromFile(files[0]);
		}

		/// <summary>
		/// Json to Xml converter
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void JsontoXmlConvert(object sender, RoutedEventArgs e)
		{
			// null check
			if (string.IsNullOrEmpty(AvalonJsonEditor.Text))
			{
				MessageBox.Show("Json verisi boş olmamalıdır", "Boş JSON İçeriği", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			// validate json data
			if (!Core.Helpers.Json.Json.IsValidJson(AvalonJsonEditor.Text))
			{
				MessageBox.Show(Core.Helpers.Json.Json.JsonValidationError, "Geçersiz JSON Verisi", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			try
			{
				// convert json to xml
				var newXmlData = Core.Helpers.Json.Json.Json2Xml(AvalonJsonEditor.Text);

				// if not null
				if (string.IsNullOrWhiteSpace(newXmlData)) return;

				// create xml document
				var xmldoc = new XmlDocument();
				// parse xml data
				var xdoc = XDocument.Parse(newXmlData).ToString().Trim();
				// load parsed xml data to xml doc
				xmldoc.LoadXml(xdoc);

				// insert to editor
				AvalonXmlEditor.Text = xdoc;

				// bind to xml tree
				XmlTree.SetBinding(ItemsControl.ItemsSourceProperty, Xml.BindXmlDocument(xmldoc));

				// switch xml tab
				TabControl.SelectedIndex = 1;
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.ToString(), "İşlem Başarısız", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		#endregion

		#region XML Area

		/// <summary>
		/// Xml Tree Viewer Expander - Collapser
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void XmlTreeExpandCollapse(object sender, RoutedEventArgs e)
		{
			// is it collapsed
			if (_xmlTreeCollapsed)
			{
				// expand items
				TreeExpCollapser(XmlTree, true);
				_xmlTreeCollapsed = false;
			}
			else
			{
				// collapse items
				TreeExpCollapser(XmlTree, false);
				_xmlTreeCollapsed = true;
			}
		}


		#region Methods

		/// <summary>
		/// Xml loader
		/// </summary>
		/// <param name="xmlData"></param>
		public void LoadXml(string xmlData)
		{
			// if not null
			if (string.IsNullOrWhiteSpace(xmlData))
			{
				MessageBox.Show("XML içeriği boş", "Geçersiz XML Verisi", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			// create xml document
			var xmldoc = new XmlDocument();
			// parse xml data
			var xdoc = XDocument.Parse(xmlData);

			var sw = new Utf8StringWriter();
			xdoc.Save(sw);
			var xdocSb = sw.ToString();
			// load parsed xml data to xml doc
			xmldoc.LoadXml(xdocSb);

			// insert to editor
			AvalonXmlEditor.Text = xdocSb;

			// bind to xml tree
			XmlTree.SetBinding(ItemsControl.ItemsSourceProperty, Xml.BindXmlDocument(xmldoc));
		}

		/// <summary>
		/// Load xmldata from file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void XmlLoadFromFile(object sender, RoutedEventArgs e)
		{
			XmlLoadFile();
		}

		/// <summary>
		/// XML loader method
		/// </summary>
		/// <param name="path"></param>
		public void XmlLoadFile(string path = null)
		{
			try
			{
				// xml data
				string xmlData;

				// open dialog
				if (path == null)
				{
					// prepare open file dialog
					var opfiledialog = new OpenFileDialog
					{
						DefaultExt = ".xml",
						Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*",
						Title = "Bir XML dosyası seçin."
					};

					// show open file dialog
					var result = opfiledialog.ShowDialog();

					// if tehre is selected file
					if (result != true) return;

					// get file contains
					xmlData = File.ReadAllText(opfiledialog.FileName, Encoding.UTF8).Trim();
				}
				else
				{
					// get file contains from drag and drop
					xmlData = File.ReadAllText(path, Encoding.UTF8).Trim();
				}

				LoadXml(xmlData);
			}
			catch (Exception exp)
			{
				Debug.WriteLine(exp);
			}
		}

		/// <summary>
		/// Load XML data from clipboard
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoadXmlFromClipboard(object sender, RoutedEventArgs e)
		{
			try
			{
				// get data from clipboard
				var xmlData = System.Windows.Clipboard.GetText();

				LoadXml(xmlData);
			}
			catch (Exception exp)
			{
				Debug.WriteLine(exp);
			}
		}

		/// <summary>
		/// Loader of XML data from web
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		private bool LoadXmlFromWeb(string url)
		{
			try
			{
				// clear previous error messages
				XmlWebError = string.Empty;

				// create new web client
				var webClient = new WebClient();
				// download content
				var raw = webClient.DownloadData(url);
				// encoding
				var webData = Encoding.UTF8.GetString(raw);

				LoadXml(webData);
				return true;
			}
			catch (Exception exp)
			{
				XmlWebError = exp.Message;
			}

			return false;
		}

		/// <summary>
		/// Saves XML data to file
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SaveAsXmlString(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrEmpty(AvalonXmlEditor.Text))
			{
				var opfiledialog = new SaveFileDialog
				{
					FileName = $"Xml File.xml",
					DefaultExt = ".xml",
					Filter = "TXT Files (*.txt)|*.txt|XML Files (*.xml)|*.xml",
					AddExtension = true,
					Title = "XML verisini kaydedeceğiniz yeri seçin"
				};
				var result = opfiledialog.ShowDialog();

				if (result == true)
				{
					File.WriteAllText(opfiledialog.FileName, AvalonXmlEditor.Text);
				}
			}
			else
			{
				MessageBox.Show("Kaydedilecek bir XML verisi bulunamadı", "Kaydedilemez", MessageBoxButton.OK, MessageBoxImage.Warning);
			}

		}

		/// <summary>
		/// Copies XML data to clipboard
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CopyToClipboardXml(object sender, RoutedEventArgs e)
		{
			// if is no xml text
			if (!string.IsNullOrEmpty(AvalonXmlEditor.Text))
			{
				// copy to clipboard
				System.Windows.Clipboard.SetText(AvalonXmlEditor.Text);
			}
		}

		/// <summary>
		/// Xml tree binding from xml data
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BindXmlTree(object sender, RoutedEventArgs e)
		{
			// if not null
			if (string.IsNullOrWhiteSpace(AvalonXmlEditor.Text)) return;

			// create xml document
			var xmldoc = new XmlDocument();
			// parse xml data
			var xdoc = XDocument.Parse(AvalonXmlEditor.Text).ToString().Trim();
			// load parsed xml data to xml doc
			xmldoc.LoadXml(xdoc);

			// insert to editor
			AvalonXmlEditor.Text = xdoc;

			// bind to xml tree
			XmlTree.SetBinding(ItemsControl.ItemsSourceProperty, Xml.BindXmlDocument(xmldoc));
		}

		/// <summary>
		/// XML data reformatter
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ReFormatXmlString(object sender, RoutedEventArgs e)
		{
			// get data from editor
			var xmlData = AvalonXmlEditor.Text;

			// if not null
			if (string.IsNullOrWhiteSpace(xmlData)) return;

			// create xml document
			var xmldoc = new XmlDocument();
			// parse xml data
			var xdoc = XDocument.Parse(xmlData).ToString().Trim();
			// load parsed xml data to xml doc
			xmldoc.LoadXml(xdoc);

			// insert to editor
			AvalonXmlEditor.Text = xdoc;

			// bind to xml tree
			XmlTree.SetBinding(ItemsControl.ItemsSourceProperty, Xml.BindXmlDocument(xmldoc));
		}

		/// <summary>
		/// Clear XML data
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ClearXmlData(object sender, RoutedEventArgs e)
		{
			XmlTree.ItemsSource = null;
			AvalonXmlEditor.Text = string.Empty;
		}

		#region Xml Get From WebUI Dialog

		private void GetFromWebXmlChecked(object sender, RoutedEventArgs e)
		{
			var blurEffect = new BlurEffect();
			blurEffect.Radius = 7;
			XmlEditorGrid.Effect = blurEffect;
			XmlEditorGrid.IsEnabled = false;
			GetFromWebGridXml.Visibility = Visibility.Visible;
		}

		private void GetXmlFromWebClose(object sender, RoutedEventArgs e)
		{
			XmlEditorGrid.Effect = null;
			XmlEditorGrid.IsEnabled = true;
			GetFromWebGridXml.Visibility = Visibility.Hidden;
		}

		private void GetXmlFromWeb(object sender, RoutedEventArgs e)
		{
			if (LoadXmlFromWeb(GetXmlURL.Text))
			{
				GetXmlFromWebClose(sender, e);
			}
			else if (XmlWebError != null)
			{
				MessageBox.Show(_jxr.JsonWebError ?? "Geçersiz İçerik", "İşlem Başarısız oldu", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		#endregion

		/// <summary>
		/// Xml editor open file on drag and dropping
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void XmlEditorGrid_OnDrop(object sender, DragEventArgs e)
		{
			// handle it
			if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

			// get dropped file/s
			var files = (string[])e.Data.GetData(DataFormats.FileDrop);

			// send to function
			if (files != null) XmlLoadFile(files[0]);
		}

		#endregion

		#endregion


		/// <summary>
		/// On load event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void JXR_Editor_OnLoaded(object sender, RoutedEventArgs e)
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
					case "JsonDark":
						// set json dark syntaxhighlighting theme
						AvalonJsonEditor.SyntaxHighlighting = hitem;
						break;
					case "XMLDark":
						// set xml dark syntaxhighlighting theme
						AvalonXmlEditor.SyntaxHighlighting = hitem;
						break;
				}
			}

			Folding();
			UpdateFoldings();

			#endregion

			// example xml data
			var xmlData = "<?xml version=\"1.0\" encoding=\"UTF-8\"?> <Example_List> <Example_Item> <Example_Key>example Value</Example_Key> </Example_Item> <Example_Item> <Example_Key>example Value</Example_Key> </Example_Item> </Example_List>";
			// create xml document
			var xmldoc = new XmlDocument();
			// parse xml data
			var xdoc = XDocument.Parse(xmlData).ToString().Trim();
			// load parsed xml data to xml doc
			xmldoc.LoadXml(xdoc);

			// insert to editor
			AvalonXmlEditor.Text = xdoc;

			// bind to xml tree
			XmlTree.SetBinding(ItemsControl.ItemsSourceProperty, Xml.BindXmlDocument(xmldoc));
		}

		/// <summary>
		/// TabControl selection changed event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Configs.SelectedSubTabHeader = (string)((TabItem)TabControl.SelectedItem).Header;
		}

		#region Methods

		#region Avalon Folding

		FoldingManager _foldingManager;
		object _foldingStrategy;

		/// <summary>
		/// Folding method
		/// </summary>
		private void Folding()
		{
			if (AvalonJsonEditor.SyntaxHighlighting == null)
			{
				_foldingStrategy = null;
			}
			else
			{
				AvalonJsonEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.DefaultIndentationStrategy();
				_foldingStrategy = null;
			}
			if (_foldingStrategy != null)
			{
				if (_foldingManager == null)
					_foldingManager = FoldingManager.Install(AvalonJsonEditor.TextArea);
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
					((BraceFoldingStrategy)_foldingStrategy).UpdateFoldings(_foldingManager, AvalonJsonEditor.Document);
					break;
				case XmlFoldingStrategy _:
					((XmlFoldingStrategy)_foldingStrategy).UpdateFoldings(_foldingManager, AvalonJsonEditor.Document);
					break;
			}
		}

		#endregion


		#region TreeView Expander - Collapser

		private void TreeExpCollapser(TreeView treeview, bool expandstate)
		{
			if (treeview.Items.IsEmpty)
				return;

			var cursor = Cursor;
			Cursor = Cursors.Wait;
			Timer = new DispatcherTimer(TimeSpan.FromMilliseconds(100), DispatcherPriority.Normal, delegate
			{
				TreeExpCollapser(treeview, treeview.Items, expandstate);
				Timer.Stop();
				Cursor = cursor;
			}, Application.Current.Dispatcher);
			Timer.Start();
		}

		private void TreeExpCollapser(ItemsControl mainitems, ItemCollection items, bool expandstate)
		{
			var öğeüretici = mainitems.ItemContainerGenerator;
			if (öğeüretici.Status == Üretici)
			{
				Act(items, expandstate, öğeüretici);
			}
			else
			{
				öğeüretici.StatusChanged += delegate
				{
					Act(items, expandstate, öğeüretici);
				};
			}
		}

		private void Act(ItemCollection items, bool expandstate, ItemContainerGenerator contgenerator)
		{
			if (contgenerator.Status != Üretici)
				return;

			foreach (var item in items)
			{
				if (contgenerator.ContainerFromItem(item) is TreeViewItem treeview)
				{
					treeview.IsExpanded = expandstate;
					TreeExpCollapser(treeview, treeview.Items, expandstate);
				}
			}
		}





		#endregion

		#endregion

	}
	public class Utf8StringWriter : StringWriter
	{
		public override Encoding Encoding => Encoding.UTF8;
	}
}
