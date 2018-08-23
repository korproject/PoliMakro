using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using Poli.Makro.Core.ViewModel.Base;

namespace Poli.Makro.Core.ViewModel.JXR
{
	public class JXR : BaseViewModel
	{
		/// <summary>
		/// Main constructor
		/// </summary>
		public JXR()
		{
			#region JSON

			// example json data
			JsonText = "{\"example_key\" : \"example_value\"}";
			// set reformatted json data
			JsonText = Helpers.Json.Json.ReFormatJsonString(JsonText);
			// build json tree
			JsonTreeBinding();

			// json function commands
			JsonLoadFromFile = new RelayParameterizedCommand(parameter => LoadJsonFromFile());
			JsonLoadFromClipboard = new RelayParameterizedCommand(parameter => LoadJsonString());
			SaveAsJsonString = new RelayParameterizedCommand(parameter => SaveAsJson());
			CopyToClipboardJsonString = new RelayParameterizedCommand(parameter => CopyToClipboardJson());
			BindJsonTree = new RelayParameterizedCommand(parameter => JsonTreeBinding());
			ReFormatJsonString = new RelayParameterizedCommand(parameter => ReFormatJson());
			ClearJsonData = new RelayParameterizedCommand(parameter => JsonDataCleaner());

			#endregion

			#region XML


			#endregion
		}


		#region JSON

		#region Constructors

		/// <summary>
		/// Json data instead TreeView
		/// </summary>
		public List<JToken> JsonTreeView { get; set; }

		/// <summary>
		/// Json string data
		/// </summary>
		public string JsonText { get; set; }

		/// <summary>
		/// Json web client error
		/// </summary>
		public string JsonWebError { get; set; }
		#endregion

		#region Commands

		/// <summary>
		/// Load json data from file command
		/// </summary>
		public ICommand JsonLoadFromFile { get; set; }

		/// <summary>
		/// Load json data from clipboard command
		/// </summary>
		public ICommand JsonLoadFromClipboard { get; set; }

		/// <summary>
		/// Save as json data command
		/// </summary>
		public ICommand SaveAsJsonString { get; set; }

		/// <summary>
		/// Copy to clipboard JSON string command
		/// </summary>
		public ICommand CopyToClipboardJsonString { get; set; }

		/// <summary>
		/// Json tree binding command
		/// </summary>
		public ICommand BindJsonTree { get; set; }

		/// <summary>
		/// ReFormat JSON string command
		/// </summary>
		public ICommand ReFormatJsonString { get; set; }

		/// <summary>
		/// Clear JSON data
		/// </summary>
		public ICommand ClearJsonData { get; set; }

		#endregion

		#region Json Methods

		/// <summary>
		/// Json loader
		/// </summary>
		/// <param name="jsonData"></param>
		private void LoadJson(string jsonData)
		{
			// if not null
			if (string.IsNullOrWhiteSpace(jsonData))
			{
				MessageBox.Show("JSON içeriği boş", "Geçersiz JSON Verisi", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			// validate json data
			if (!Helpers.Json.Json.IsValidJson(jsonData))
			{
				MessageBox.Show(Helpers.Json.Json.JsonValidationError ?? "???", "Geçersiz JSON Verisi", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			// re format and set
			JsonText = Helpers.Json.Json.ReFormatJsonString(jsonData);

			// create json treeview
			JsonTreeView = null;
			JsonTreeView = Helpers.Json.Json.JsonStringToList(jsonData);

		}

		/// <summary>
		/// Loader of json data from file
		/// </summary>
		public void LoadJsonFromFile(string path = null)
		{
			// json data
			string jsonData;

			// open dialog
			if (path == null)
			{
				// prepare open file dialog
				var opfiledialog = new OpenFileDialog
				{
					DefaultExt = ".json",
					Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*",
					Title = "Bir JSON dosyası seçin."
				};

				// show open file dialog
				var result = opfiledialog.ShowDialog();

				// if tehre is selected file
				if (result != true) return;

				// get file contains
				jsonData = File.ReadAllText(opfiledialog.FileName, Encoding.UTF8).Trim();
			}
			else
			{
				// get file contains from drag and drop
				jsonData = File.ReadAllText(path, Encoding.UTF8).Trim();
			}

			LoadJson(jsonData);
		}

		/// <summary>
		/// Loader of json data from clipboard
		/// </summary>
		private void LoadJsonString()
		{
			// get data from clipboard
			var jsonData = Clipboard.GetText();

			LoadJson(jsonData);
		}

		/// <summary>
		/// Downloads and loads json data ffrom web
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		public bool LoadJsonFromWeb(string url)
		{
			try
			{
				// clear previous error messages
				JsonWebError = string.Empty;

				// create new web client
				var webClient = new WebClient();
				// download content
				var raw = webClient.DownloadData(url);
				// encoding
				var webData = Encoding.UTF8.GetString(raw);

				LoadJson(webData);

				return true;
			}
			catch (Exception exp)
			{
				JsonWebError = exp.Message;
			}

			return false;
		}

		/// <summary>
		/// Saves JSON data to file
		/// </summary>
		private void SaveAsJson()
		{
			if (!string.IsNullOrEmpty(JsonText))
			{
				// validate json data
				if (!Helpers.Json.Json.IsValidJson(JsonText))
				{
					MessageBox.Show(Helpers.Json.Json.JsonValidationError, "Geçersiz JSON Verisi", MessageBoxButton.OK, MessageBoxImage.Warning);
					return;
				}

				var opfiledialog = new SaveFileDialog
				{
					FileName = $"Json File.json",
					DefaultExt = ".json",
					Filter = "TXT Files (*.txt)|*.txt|JSON Files (*.json)|*.json",
					AddExtension = true,
					Title = "JSON verisini kaydedeceğiniz yeri seçin"
				};
				var result = opfiledialog.ShowDialog();

				if (result == true)
				{
					File.WriteAllText(opfiledialog.FileName, JsonText);
				}
			}
			else
			{
				MessageBox.Show("Kaydedilecek bir JSON verisi bulunamadı", "Kaydedilemez", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		/// <summary>
		/// Copies JSON data to clipboard
		/// </summary>
		private void CopyToClipboardJson()
		{
			// if is no json text
			if (!string.IsNullOrEmpty(JsonText))
			{
				// copy to clipboard
				Clipboard.SetText(JsonText);
			}
		}

		/// <summary>
		/// JSON tree binder
		/// </summary>
		private void JsonTreeBinding()
		{
			// is not null
			if (string.IsNullOrEmpty(JsonText))
			{
				MessageBox.Show("JSON Editörü Boş", "Geçersiz İşlem", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			// validate json data
			if (!Helpers.Json.Json.IsValidJson(JsonText))
			{
				MessageBox.Show(Helpers.Json.Json.JsonValidationError, "Geçersiz JSON Verisi", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			// re format and set
			JsonText = Helpers.Json.Json.ReFormatJsonString(JsonText);

			// create json treeview
			JsonTreeView = null;
			JsonTreeView = Helpers.Json.Json.JsonStringToList(JsonText);
		}

		/// <summary>
		/// JSON string re formatter
		/// </summary>
		private void ReFormatJson()
		{
			// is not null
			if (string.IsNullOrEmpty(JsonText))
			{
				MessageBox.Show("JSON Editörü Boş", "Geçersiz İşlem", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			// validate json data
			if (!Helpers.Json.Json.IsValidJson(JsonText))
			{
				MessageBox.Show(Helpers.Json.Json.JsonValidationError, "Geçersiz JSON Verisi", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			// re format and set
			JsonText = Helpers.Json.Json.ReFormatJsonString(JsonText);
		}

		/// <summary>
		/// Json data cleaner
		/// </summary>
		private void JsonDataCleaner()
		{
			JsonText = string.Empty;
			JsonTreeView = null;
		}

		#endregion

		#endregion


		#region XML

		#region Constructors

		/// <summary>
		/// Json data instead TreeView
		/// </summary>
		public List<JToken> XmlTreeView { get; set; }

		/// <summary>
		/// Json string data
		/// </summary>
		public string XmlText { get; set; }

		/// <summary>
		/// Json web client error
		/// </summary>
		public string XmlWebError { get; set; }

		#endregion


		#endregion
	}
}
 