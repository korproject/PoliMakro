using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace Poli.Makro.Core.ClipboardManager.Monitor
{
    public class WindowClipboardMonitor : IDisposable
    {
        public event EventHandler<string> ClipboardTextChanged;
        public event EventHandler<BitmapSource> ClipboardImageChanged;

        HwndSource _win32InteropSource;
        IntPtr _windowInteropHandle;
        private bool _disposed;

        #region Initilasion and handling

        public WindowClipboardMonitor(Window clipboardWindow)
        {
            InitializeInteropSource(clipboardWindow);
            InitializeWindowInteropHandle(clipboardWindow);

            StartHandlingWin32Messages();
            AddListenerForClipboardWin32Messages();
        }

        private void InitializeInteropSource(Window clipboardWindow)
        {
            var presentationSource = PresentationSource.FromVisual(clipboardWindow);
            _win32InteropSource = presentationSource as HwndSource;

            if (_win32InteropSource == null)
            {
                throw new ArgumentException(
                    $"Window must be initialized before using the {nameof(WindowClipboardMonitor)}. Use the window's OnSourceInitialized() handler if possible, or a later point in the window lifecycle."
                    , nameof(clipboardWindow));
            }
        }

        private void InitializeWindowInteropHandle(Window clipboardWindow)
        {
            _windowInteropHandle = new WindowInteropHelper(clipboardWindow).Handle;
            if (_windowInteropHandle == null)
            {
                throw new ArgumentException(
                    $"{nameof(clipboardWindow)} must be initialized before using the {nameof(WindowClipboardMonitor)}. Use the Window's OnSourceInitialized() handler if possible, or a later point in the window lifecycle."
                    , nameof(clipboardWindow));
            }
        }

        private void StartHandlingWin32Messages()
        {
            _win32InteropSource.AddHook(Win32InteropMessageHandler);
        }

        private void StopHandlingWin32Messages()
        {
            _win32InteropSource.RemoveHook(Win32InteropMessageHandler);
        }

        private void AddListenerForClipboardWin32Messages()
        {
            NativeInterop.AddClipboardFormatListener(_windowInteropHandle);
        }

        private void RemoveListenerForClipboardWin32Messages()
        {
            NativeInterop.RemoveClipboardFormatListener(_windowInteropHandle);
        }

        #endregion

        /// <summary>
        /// Clipboard changed handler
        /// </summary>
        private IntPtr Win32InteropMessageHandler(IntPtr windowHandle, int messageCode, IntPtr wParam, IntPtr lParam, ref bool messageHandled)
        {
            if (messageCode == NativeInterop.ClipboardUpdateWindowMessageCode)
            {
                OnClipboardChanged();

                messageHandled = true;
                return NativeInterop.HandledClipboardUpdateReturnCode;
            }

            return NativeInterop.NoMessageHandledReturnCode;
        }

        /// <summary>
        /// Clipboard changed first fire
        /// </summary>
        private void OnClipboardChanged()
        {
            ProcessClipboardTextWithRetry();
            ProcessClipboardImageWithRetry();
        }

        /// <summary>
        /// Retry when gets error
        /// </summary>
        private void SleepUntilNextRetry()
        {
            const int sleepDurationMilliseconds = 50;
            var timeUntilNextRetry = TimeSpan.FromMilliseconds(sleepDurationMilliseconds);
            Thread.Sleep(timeUntilNextRetry);
        }

        /// <summary>
        /// Monitor disposer
        /// </summary>
        public void Dispose()
        {
            ReleaseResources();
            GC.SuppressFinalize(this);
        }

        protected virtual void ReleaseResources()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;

            RemoveListenerForClipboardWin32Messages();
            StopHandlingWin32Messages();

            _win32InteropSource = null;
            _windowInteropHandle = IntPtr.Zero;
        }

        ~WindowClipboardMonitor()
        {
            ReleaseResources();
        }

        #region Clipboard GetText

        private void ProcessClipboardTextWithRetry()
        {
            const int maxAttempts = 10;
            int currentAttemptNumber = 1;

            while (currentAttemptNumber <= maxAttempts)
            {
                try
                {
                    ProcessClipboardText();
                    return;
                }
                catch (COMException ex) when (ex.ErrorCode == NativeInterop.UnableToOpenClipboardComErrorCode)
                {
                    SleepUntilNextRetry();
                }

                currentAttemptNumber++;
            }
        }

        private void ProcessClipboardText()
        {
            if (System.Windows.Clipboard.ContainsText())
            {
                ClipboardTextChanged?.Invoke(this, System.Windows.Clipboard.GetText());
            }
        }

        #endregion

        #region Clipboard GetImage

        private void ProcessClipboardImageWithRetry()
        {
            const int maxAttempts = 10;
            int currentAttemptNumber = 1;

            while (currentAttemptNumber <= maxAttempts)
            {
                try
                {
                    ProcessClipboardImage();
                    return;
                }
                catch (COMException ex) when (ex.ErrorCode == NativeInterop.UnableToOpenClipboardComErrorCode)
                {
                    SleepUntilNextRetry();
                }
                currentAttemptNumber++;
            }
        }

        private void ProcessClipboardImage()
        {
            if (System.Windows.Clipboard.ContainsImage())
            {
                ClipboardImageChanged?.Invoke(this, System.Windows.Clipboard.GetImage());
            }
        }

        #endregion
    }
}
