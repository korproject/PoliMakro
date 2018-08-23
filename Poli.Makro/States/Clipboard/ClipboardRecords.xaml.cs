using System.Windows;
using Poli.Makro.Core.ClipboardManager.Clipboard;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using Poli.Makro.Core;
using System;
using System.Diagnostics;
using System.Windows.Threading;

namespace Poli.Makro.States.Clipboard
{
    /// <summary>
    /// Interaction logic for ClipboardRecords.xaml
    /// </summary>
    public partial class ClipboardRecords : UserControl
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ClipboardRecords()
        {
            InitializeComponent();

            var clipb = new Core.ViewModel.ClipboardManager.Clipboard();

            DataContext = clipb;
        }

        private void Records_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
        }

        #region Save Records

        private void SaveRecordsChecked(object sender, RoutedEventArgs e)
        {
            var blurEffect = new BlurEffect();
            blurEffect.Radius = 7;
            Records.Effect = blurEffect;
            Records.IsEnabled = false;
            SaveGrid.Visibility = Visibility.Visible;
        }

        private void SaveRecordsClose(object sender, RoutedEventArgs e)
        {
            SaveRecordsCloser();
        }

        void SaveRecordsCloser()
        {
            Records.Effect = null;
            Records.IsEnabled = true;
            SaveGrid.Visibility = Visibility.Hidden;
            SaveRecordsTB.IsChecked = false;
        }

        private void SaveAsNewTitleAndClean(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SaveRecordsTitle.Text) || string.IsNullOrWhiteSpace(SaveRecordsTitle.Text))
            {
                return;
            }

            ClipboardEnviroment.RenameSessionTitle(SaveRecordsTitle.Text);
            ClipboardEnviroment.ClipboardRecordsL.Clear();
            SaveRecordsCloser();
        }

        private void SaveAsAndClose(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SaveRecordsTitle.Text) || string.IsNullOrWhiteSpace(SaveRecordsTitle.Text))
            {
                return;
            }

            ClipboardEnviroment.RenameSessionTitle(SaveRecordsTitle.Text);
            SaveRecordsCloser();
        }

        #endregion

        private void ClearRecords(object sender, RoutedEventArgs e)
        {
            ClipboardEnviroment.ClipboardRecordsL.Clear();
        }

        private void HistoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ClipboardHistory)HistoryComboBox.SelectedItem ?? null;

            if (item != null)
            {
                ClipboardEnviroment.GetHistory(item.SessionKey);
            }
        }

        #region Save Pettern

        private void SavePetternChecked(object sender, RoutedEventArgs e)
        {
            var blurEffect = new BlurEffect();
            blurEffect.Radius = 7;
            PetternsListGrid.Effect = blurEffect;
            PetternsListGrid.IsEnabled = false;
            AddPetternGrid.Visibility = Visibility.Visible;
        }

        private void SavePetternClose(object sender, RoutedEventArgs e)
        {
            SavePetternCloser();
        }

        void SavePetternCloser()
        {
            PetternsListGrid.Effect = null;
            PetternsListGrid.IsEnabled = true;
            AddPetternGrid.Visibility = Visibility.Hidden;
            SavePetternTB.IsChecked = false;
        }

        private void SaveGroupCancel(object sender, RoutedEventArgs e)
        {
            AddPetternGroupGrid.Visibility = Visibility.Hidden;
            AddPetternn.Effect = null;
            AddPetternn.IsEnabled = true;
        }

        private void SaveGroup(object sender, RoutedEventArgs e)
        {
            if (ClipboardEnviroment.CreatePetternGroup(AddPetternGroupTitle.Text))
            {
                AddPetternGroupGrid.Visibility = Visibility.Hidden;
                AddPetternn.Effect = null;
                AddPetternn.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Girilen grup ismi geçersiz veya aynı isim zaten kayıtlı.", "Grup eklenemedi", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AddNewPetternGroup(object sender, RoutedEventArgs e)
        {
            var blurEffect = new BlurEffect();
            blurEffect.Radius = 7;
            AddPetternn.Effect = blurEffect;
            AddPetternn.IsEnabled = false;
            AddPetternGroupGrid.Visibility = Visibility.Visible;
        }

        private void SavePettern(object sender, RoutedEventArgs e)
        {
            if (PetternGroupsComboBox.HasItems)
            {
                if (PetternGroupsComboBox.SelectedItem != null)
                {
                    var petternGroup = (ClipboardPetternGroup)PetternGroupsComboBox.SelectedItem;

                    if (ClipboardEnviroment.CreatePettern(AddPetternTitle.Text, AddPettern.Text, petternGroup.RowId))
                    {
                        SavePetternCloser();
                    }
                    else
                    {
                        MessageBox.Show("Bu deesen zaten kayıtlı.", "Desen Eklenemedi", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Deseni eklemek için önce bir grup seçin.", "Desen Eklenemez", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Deseni eklemek için önce bir grup ekleyin.", "Desen Eklenemez", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void PetternGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			try
			{
				Petterns.ItemsSource = ((ClipboardPetternGroup)PetternGroups.SelectedItem).ClipboardPetterns;

			}
			catch (Exception exp)
			{
				Debug.WriteLine(exp);
			}
        }

        #endregion

        private void MagnetEngine(object sender, RoutedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Configs.SelectedSubTabHeader = (string)((TabItem)TabControl.SelectedItem).Header;
        }

        private void DeleteRecord(object sender, RoutedEventArgs e)
        {
            var item = (Button)sender;

            if (item.Tag != null && item.Tag != "0")
            {
                ClipboardEnviroment.DeleteItem(Convert.ToInt64(item.Tag));
            }
        }

        private void CopyRecord(object sender, RoutedEventArgs e)
        {
            var item = (Button)sender;

            if (item != null && item.Tag != "0")
            {
                ClipboardEnviroment.CopyItem(Convert.ToInt64(item.Tag), true);
            }
        }

        private void SaveAsRecord(object sender, RoutedEventArgs e)
        {
            var item = (Button)sender;

            if (item.Tag != null && item.Tag != "0")
            {
                ClipboardEnviroment.SaveAsItem(Convert.ToInt64(item.Tag), true);
            }
        }


        private DispatcherTimer Timer;

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (ClipboardEnviroment.SessionCreated)
            {
                Records.ItemsSource = ClipboardEnviroment.ClipboardRecordsL;

                HistoryComboBox.ItemsSource = ClipboardEnviroment.ClipboardRecordHistories;
                HistoryComboBox.SelectedIndex = (ClipboardEnviroment.ClipboardRecordHistories.Count - 1);
                HistoryRecords.ItemsSource = ClipboardEnviroment.ClipboardRecordHistoryL;

                PetternGroups.ItemsSource = ClipboardEnviroment.ClipboardPetternGroupL;
                PetternGroupsComboBox.ItemsSource = ClipboardEnviroment.ClipboardPetternGroupL;
            }
            else
            {
                int attempts = 0;
                const int maxAttempts = 10;

                Timer = new DispatcherTimer(TimeSpan.FromMilliseconds(500), DispatcherPriority.Normal, delegate
                {
                    if (attempts <= maxAttempts)
                    {
                        if (ClipboardEnviroment.SessionCreated)
                        {
                            Records.ItemsSource = ClipboardEnviroment.ClipboardRecordsL;

                            HistoryComboBox.ItemsSource = ClipboardEnviroment.ClipboardRecordHistories;
                            HistoryRecords.ItemsSource = ClipboardEnviroment.ClipboardRecordHistoryL;

                            PetternGroups.ItemsSource = ClipboardEnviroment.ClipboardPetternGroupL;
                            PetternGroupsComboBox.ItemsSource = ClipboardEnviroment.ClipboardPetternGroupL;
                        }
                    } else
                    {
                        Timer.Stop();

                        MessageBoxResult result = MessageBox.Show(Application.Current.MainWindow, "Şuanki oturum bilgisi oluşturulamadığı için eski oturum geçmişleri alınamadı ve tekrar almak için 10 başarısız deneme yapıldı. Tekrar deneme istiyor musunuz?", "Oturum Geçmişi Alınamadı", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            attempts = 0;
                            Timer.Start();
                        }
                    }
                }, Application.Current.Dispatcher);
                Timer.Start();
            }
        }

        private void SaveAsHistoryRecord(object sender, RoutedEventArgs e)
        {
            var item = (Button)sender;

            if (item.Tag != null && item.Tag != "0")
            {
                ClipboardEnviroment.SaveAsItem(Convert.ToInt64(item.Tag), false);
            }
        }

        private void CopyHistoryRecord(object sender, RoutedEventArgs e)
        {
            var item = (Button)sender;

            if (item != null && item.Tag != "0")
            {
                ClipboardEnviroment.CopyItem(Convert.ToInt64(item.Tag), false);
            }
        }

        private void DeleteHistoryRecord(object sender, RoutedEventArgs e)
        {
            var item = (Button)sender;

            if (item.Tag != null && item.Tag != "0")
            {
                ClipboardEnviroment.DeleteItem(Convert.ToInt64(item.Tag));
            }
        }
    }
}
