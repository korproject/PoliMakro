using System;
using System.Runtime.InteropServices;
using System.Threading;
using Poli.Makro.Core.ClipboardManager.Monitor;

namespace Poli.Makro.Core.ClipboardManager.Helpers
{
    public class ClipboardHelper
    {
        public static object GetContentFromClipboardWithRetry(ContentType contenttype)
        {
            const int maxAttempts = 10;
            int currentAttemptNumber = 1;

            while (currentAttemptNumber <= maxAttempts)
            {
                try
                {
                    if (contenttype == ContentType.Text)
                    {
                        if (System.Windows.Clipboard.ContainsText())
                        {
                            return System.Windows.Clipboard.GetText();
                        }
                    }
                    else if (contenttype == ContentType.Image)
                    {
                        if (System.Windows.Clipboard.ContainsImage())
                        {
                            return System.Windows.Clipboard.GetImage();
                        }
                    }
                }
                catch (COMException ex) when (ex.ErrorCode == NativeInterop.UnableToOpenClipboardComErrorCode)
                {
                    const int sleepDurationMilliseconds = 50;
                    var timeUntilNextRetry = TimeSpan.FromMilliseconds(sleepDurationMilliseconds);
                    Thread.Sleep(timeUntilNextRetry);
                }

                currentAttemptNumber++;
            }

            return null;
        }
    }

    public enum ContentType
    {
        Text,
        Image
    }
}
