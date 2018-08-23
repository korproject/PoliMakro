using KOR.Updater.Core;
using Poli.Makro.Core.Database;
using Poli.Makro.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Poli.Makro.Core.ViewModel.Settings
{
	public class Settings : BaseViewModel
	{
		public Settings()
		{
			FeedbackContent = "Mesaj içeriği girin.";
			// get last updates
			Updates = dbprocs.GetLastUpdates();


			SettingsList = new ObservableCollection<Setting>();

			var myResourceDictionary = new ResourceDictionary
			{
				Source = new Uri("pack://application:,,,/Poli.Makro;component/UICollection/Icons.xaml", UriKind.RelativeOrAbsolute)
			};

			// account - session
			Setting settingSession = new Setting()
			{
				Title = "Oturum",
				Descp = "Oturum açmış olduğunuz kor.onl hesabı hakkında bilgiler ve temel ayarlar bu bölümde yer alıyor.",
				PathData = ((Path)myResourceDictionary["Happy"]).Data
			};
			SettingsList.Add(settingSession);

			// feedback
			Setting settingFeedback = new Setting()
			{
				Title = "Geri Bildirim",
				Descp = "İstek, öneri ve şikayetlerinizi hızlı bir şekilde iletebilirsiniz.",
				PathData = ((Path)myResourceDictionary["Feedback"]).Data
			};
			SettingsList.Add(settingFeedback);

			// updates
			Setting settingUpdate = new Setting()
			{
				Title = "Güncelleme",
				Descp = "Güncelleme kontrollerini ve ayarlarını buradan yönetebilirsiniz.",
				PathData = ((Path)myResourceDictionary["Registry"]).Data
			};
			SettingsList.Add(settingUpdate);

			Setting settingLicense = new Setting()
			{
				Title = "Lisans",
				Descp = "Bu oturuma ait lisans bilgileri yer alıyor.",
				PathData = ((Path)myResourceDictionary["License"]).Data
			};
			SettingsList.Add(settingLicense);

			Setting settingAbout = new Setting()
			{
				Title = "Hakkında",
				Descp = "Uygulama hakkında detaylı bilgiler içerir.",
				PathData = ((Path)myResourceDictionary["About"]).Data
			};
			SettingsList.Add(settingAbout);

			Setting settingThirtyParty = new Setting()
			{
				Title = "3. Parti",
				Descp = "3. parti kullanımlar ve lisansları bu kısımda listeleniyor.",
				PathData = ((Path)myResourceDictionary["Term"]).Data
			};
			SettingsList.Add(settingThirtyParty);

			UserInfo = User.GetUserInfo();

			#region Error Reporter

			KOR.ErrorReporter.Models.Api.OutputType = KOR.ErrorReporter.Models.Api.OutputTypes.Json;
			KOR.ErrorReporter.Models.Api.API_KEY = Configs.API_KEY;
			KOR.ErrorReporter.Models.Api.API_SECRET = Configs.API_SECRET;

			#endregion

			#region Updater

			SendFeedbackComm = new RelayParameterizedCommand(parameter => SendFeedback());

			CheckUpdateVisibility = Visibility.Visible;
			GetUpdateVisibility = Visibility.Collapsed;
			CheckUpdateIsEnabled = true;

			CheckUpdateComm = new RelayParameterizedCommand(parameter => CheckUpdate());
			GetUpdateComm = new RelayParameterizedCommand(paremeter => GetUpdate());

			KOR.Updater.Core.Api.OutputType = Api.OutputTypes.Json;
			KOR.Updater.Core.Api.API_KEY = Configs.API_KEY;
			KOR.Updater.Core.Api.API_SECRET = Configs.API_SECRET;

			#endregion
		}


		public ObservableCollection<Setting> SettingsList { get; set; }
		public UserInfo UserInfo { get; set; }


		#region Send Feedback

		public string FeedbackTitle { get; set; }
		public string FeedbackContent { get; set; }
		public ICommand SendFeedbackComm { get; set; }

		public void SendFeedback()
		{
			if (string.IsNullOrEmpty(FeedbackTitle))
			{
				MessageBox.Show("Başlık boş olmamalı", "Başarısız", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			else if (string.IsNullOrEmpty(FeedbackContent))
			{
				MessageBox.Show("Mesaj boş olmamalı", "Başarısız", MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}

			KOR.ErrorReporter.Models.Feedback feedback = new KOR.ErrorReporter.Models.Feedback()
			{
				Title = FeedbackTitle,
				Content = FeedbackContent
			};

			KOR.ErrorReporter.FeedbackReport errorReporter = new KOR.ErrorReporter.FeedbackReport()
			{
				Feedback = feedback
			};

			var report = errorReporter.ReportFeedback();

			if (report)
			{
				MessageBox.Show("Geri bildirim gönderildi", "Başrılı", MessageBoxButton.OK, MessageBoxImage.Information);
				FeedbackTitle = "";
				FeedbackContent = "";
			}
			else
			{
				MessageBox.Show("Geri bildirim gönderilemedi.", "Başarısız", MessageBoxButton.OK, MessageBoxImage.Hand);
			}
		}

		#endregion

		#region Updates

		private Database.Updater dbprocs = new Database.Updater();

		public Visibility CheckUpdateVisibility { get; set; }
		public Visibility GetUpdateVisibility { get; set; }

		public bool CheckUpdateIsEnabled { get; set; }

		public ICommand CheckUpdateComm { get; set; }
		public ICommand GetUpdateComm { get; set; }

		public string UpdateStatus { get; set; }

		public List<Update> Updates { get; set; }

		/// <summary>
		/// Check update
		/// </summary>
		public void CheckUpdate()
		{
			// define Updater class and set credentials
			KOR.Updater.Core.Updater updater = new KOR.Updater.Core.Updater
			{
				// app versions stores sqlite database
				AppVersion = dbprocs.GetAppVersion(),
				// listing multi results off
				MultiResult = false
			};

			// check update
			var checkresult = updater.CheckUpdate();

			// if there is update
			if ((bool)checkresult == true)
			{
				GetUpdateVisibility = Visibility.Visible;
				CheckUpdateVisibility = Visibility.Collapsed;

				// show new version
				UpdateStatus = "Yeni Sürüm: " + updater.Updates[0].AppVersion;
			}
			else
			{
				UpdateStatus = "Uygulama Güncel";

				if (!string.IsNullOrEmpty(updater.UpdaterResponse.ResponseAPIErrorMessage))
				{
					MessageBox.Show(updater.UpdaterResponse.ResponseAPIErrorMessage, "Error:", MessageBoxButton.OK, MessageBoxImage.Error);
				}
				else if (!string.IsNullOrEmpty(updater.UpdaterResponse.ResponseAPIWarningMessage))
				{
					MessageBox.Show(updater.UpdaterResponse.ResponseAPIWarningMessage, "Warning:", MessageBoxButton.OK, MessageBoxImage.Warning);
				}
			}

			CheckUpdateIsEnabled = false;
		}

		/// <summary>
		/// Get update action
		/// </summary>
		public void GetUpdate()
		{
			if (MessageBox.Show("Güncelleme işlemi için bu uygulama kapatılacak, devam etmek istiyor musunuz?", "Güncelleme İçin", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				Process.Start(AppDomain.CurrentDomain.BaseDirectory + "Poli.Makro.Updater");
				Environment.Exit(Environment.ExitCode);
			}
		}

		#endregion
	}

	public class Setting
	{
		public string Title { get; set; }
		public string Descp { get; set; }
		public Geometry PathData { get; set; }
	}
}
