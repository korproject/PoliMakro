using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using Poli.Makro.Properties;
using Application = System.Windows.Application;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace Poli.Makro.Main
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        /// <summary>
        /// Login View Model
        /// </summary>
        Core.ViewModel.LogRegRem.Login login = new Core.ViewModel.LogRegRem.Login();

        /// <summary>
        /// Default constructor
        /// </summary>
        public Login()
        {
            InitializeComponent();

            DataContext = login;
        }

        /// <summary>
        /// Main Windows on loaded event
        /// </summary>
        public void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            #region Build Counter

            Debug.WriteLine(Settings.Default.Build);

            #endregion
        }

        /// <summary>
        /// Main Window on closing event
        /// </summary>
        public void Login_OnClosing(object sender, CancelEventArgs e)
        {
            var wm = new Base();
            wm.Show();
        }

        #region TAŞIMA VE SAİR EKRAN İŞLEMLERİ

        #region Border'a ve Pencere'ye Ait Olaylar
        // Taşıma görevi verilen nesneye ait fare sol tık basılması ve taşıma işlemi
        // Border_FareSolTıkBasıldığında olayı tam ekran dışındaki durumlarda taşıma işlevini üstlenir
        private void Border_FareSolTıkBasıldığında(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Taşıma işlemi için varsılan birincil fare tuşu göz önüne alınarak taşıma işlemi yapılır
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragMove();
                }
            }
            catch/* (Exception Hata)*/
            {
                //MessageBox.Show(Hata.Message, "Taşınamadı", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("Taşıma İşlevi Yerine Getirilemedi", "Taşınamadı", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool Taşıma = false;
        // Önizleme fare tıklaması normal tıklama ile ayırt etmek için kullanıldı, taşıma işleminde bazen aksamalar meydana gelebiliyor
        // Bu hataları genelde cath bloğunda yakalabileceğiz am ciddi bir önemi yok şuan için
        private void Border_ÖnizlemeFareSolTıkBastığında(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Çift tıklanırsa
                if (e.ClickCount == 2)
                {
                    // Eğer ki ResizeMode CanResize ya da CanResizeWithGrip (Kenar Tutamacı İle Yeniden Şekillendirme) modu açıksa
                    if ((ResizeMode == ResizeMode.CanResize) || (ResizeMode == ResizeMode.CanResizeWithGrip))
                    {
                        PencereDurumunuDeğiştir();
                    }
                    return;
                }
                // Çift tıklanmazsa ve tam ekrandaysa
                else if (WindowState == WindowState.Maximized)
                {
                    Taşıma = true;
                    return;
                }
                // Taşır
                DragMove();
            }
            catch/* (Exception Hata)*/
            {
                //MessageBox.Show(Hata.Message, "Taşınamadı", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("Taşıma İşlevi Yerine Getirilemedi", "Taşınamadı", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Taşıma işlemini gerçekleştirdikten sonra farenin sol tıkı kalktığında Taşıma'ya false değer verilir
        private void Border_ÖnizlemeFareSolTıkKalktığında(object sender, MouseButtonEventArgs e)
        {
            Taşıma = false;
        }

        // Fare ile taşıma esnasında kullandığımız Taşıma değişkeni tam ekranda olan bir pencereyi sürüklerken kullandık
        private void Border_ÖnizlemeFareyleTaşıma(object sender, MouseEventArgs e)
        {
            try
            {
                // Taşıma true ise taşındığı bilgisini aldık ve
                if (Taşıma == true)
                {
                    // Sonraki taşıma için taşıma esnasında false değerini verdik
                    Taşıma = false;

                    // Yatay konum için değerler hesaplanır
                    double YatayYüzdelikDeğer = e.GetPosition(this).X / ActualWidth;
                    double HedefYatayDeğer = RestoreBounds.Width * YatayYüzdelikDeğer;
                    // Dikey konum için değerler hesaplanır
                    double YüzdelikDikeyDeğer = e.GetPosition(this).Y / ActualHeight;
                    double HedefDikeyDeğer = RestoreBounds.Height * YüzdelikDikeyDeğer;
                    // Bu taşıma işlemi farenin bulunduğu konuma göre yüzdelik değerler alınıp yeniden şekillendirme ile her ekrana uyumlu olacaktır


                    // Taşıma işleminin gerçekeleşebilmesi için tam ekran modundan çıkıyoruz
                    WindowState = WindowState.Normal;

                    // Farenin konumu alınır
                    Base.PointCoordinate FareninKonumu;
                    GetCursorPos(out FareninKonumu);

                    Left = FareninKonumu.X - HedefYatayDeğer;
                    Top = FareninKonumu.Y - HedefDikeyDeğer;

                    DragMove();
                }
            }
            catch/* (Exception Hata)*/
            {
                //MessageBox.Show(Hata.Message, "Taşınamadı", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("Taşıma İşlevi Yerine Getirilemedi", "Taşınamadı", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Pencere yüklendiğinde kaynkları kancalanır, bu işlem tamm ekran sırasında görev çubuğunu kaplamaya veya dikey sarkmalara sebebiyet vermemesi içindir
        private void Pencere_SourceInitialized(object sender, EventArgs e)
        {
            IntPtr Pencereİşleme = (new WindowInteropHelper(this)).Handle;
            HwndSource.FromHwnd(Pencereİşleme)?.AddHook(new HwndSourceHook(WindowProc));
        }
        #endregion

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out Base.PointCoordinate lpPoint);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr MonitorFromPoint(Base.PointCoordinate pt, Base.MonitorOptions dwFlags);

        enum MonitorOptions : uint
        {
            MONITOR_DEFAULTTONULL = 0x00000000,
            MONITOR_DEFAULTTOPRIMARY = 0x00000001,
            MONITOR_DEFAULTTONEAREST = 0x00000002
        }

        [DllImport("user32.dll")]
        static extern bool GetMonitorInfo(IntPtr hMonitor, Base.MONITORINFO lpmi);

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
            public Base.PointCoordinate ptReserved;
            public Base.PointCoordinate ptMaxSize;
            public Base.PointCoordinate ptMaxPosition;
            public Base.PointCoordinate ptMinTrackSize;
            public Base.PointCoordinate ptMaxTrackSize;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            public int cbSize = Marshal.SizeOf(typeof(Base.MONITORINFO));
            public Base.RECT rcMonitor = new Base.RECT();
            public Base.RECT rcWork = new Base.RECT();
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
            Base.PointCoordinate lMousePosition;
            GetCursorPos(out lMousePosition);

            IntPtr lPrimaryScreen = MonitorFromPoint(new Base.PointCoordinate(0, 0), Base.MonitorOptions.MONITOR_DEFAULTTOPRIMARY);
            Base.MONITORINFO lPrimaryScreenInfo = new Base.MONITORINFO();
            if (GetMonitorInfo(lPrimaryScreen, lPrimaryScreenInfo) == false)
            {
                return;
            }

            IntPtr lCurrentScreen = MonitorFromPoint(lMousePosition, Base.MonitorOptions.MONITOR_DEFAULTTONEAREST);

            Base.MINMAXINFO lMmi = (Base.MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(Base.MINMAXINFO));

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

        private void PencereDurumunuDeğiştir()
        {
            switch (WindowState)
            {
                // Pencere durumu normal ise tam ekran yapar
                case WindowState.Normal: { WindowState = WindowState.Maximized; break; }
                // Pencere durumu tam ekran ise normal (önceki hali) yapar
                case WindowState.Maximized: { WindowState = WindowState.Normal; break; }
            }
        }
        #endregion TAŞIMA VE SAİR EKRAN İŞLEMLERİ

        #region PENCERE İŞLEVLERİ
        private void Kapat_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void YenidenYükle_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void EkranıKapla_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
            {
                WindowState = WindowState.Maximized;
            }
            else if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.Minimized)
            {
                WindowState = WindowState.Minimized;
            }
        }

        void MaksimizNormaliz()
        {
        }
        #endregion

        private void AnaPencere1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MaksimizNormaliz();
        }

        private void Password_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password.Tag = Password.Password.Length > 0 ? "" : "Şifre";
        }

        private void CheckUserName()
        {
        }

        private void Username_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CheckUserName();
            }
        }
    }
}
