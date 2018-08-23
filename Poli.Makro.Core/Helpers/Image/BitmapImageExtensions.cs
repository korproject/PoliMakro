using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Poli.Makro.Core.Helpers.Image
{
    public static class BitmapImageExtensions
    {
        public static bool IsEqual(this BitmapImage image1, BitmapImage image2)
        {
            if (image1 == null || image2 == null)
            {
                Debug.WriteLine("null");
                return false;
            }
            Debug.WriteLine("---Z>"+image1.ToBytes().SequenceEqual(image2.ToBytes()));
            return image1.ToBytes().SequenceEqual(image2.ToBytes());
        }

        public static byte[] ToBytes(this BitmapImage image)
        {
            byte[] data = { };
            if (image != null)
            {
                try
                {
                    var encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(image));

                    using (MemoryStream ms = new MemoryStream())
                    {
                        encoder.Save(ms);
                        data = ms.ToArray();
                    }

                    return data;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
            return data;
        }

        public static BitmapImage BmpSource2BmpImage(BitmapSource bmpsource)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            MemoryStream memorystream = new MemoryStream();
            BitmapImage tmpImage = new BitmapImage();
            encoder.Frames.Add(BitmapFrame.Create(bmpsource));
            encoder.Save(memorystream);

            tmpImage.BeginInit();
            tmpImage.StreamSource = new MemoryStream(memorystream.ToArray());
            tmpImage.EndInit();

            memorystream.Close();
            return tmpImage;
        }

        public static void SaveBitmapSource2File(BitmapSource bmpsource, string savepath)
        {
            Thread thread = new Thread(async () =>
            {
                await Task.Factory.StartNew(() =>
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        using (var fileStream = new FileStream(savepath, FileMode.Create))
                        {
                            BitmapEncoder encoder = new PngBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(bmpsource));
                            encoder.Save(fileStream);
                        }
                    }));
                });
            });
            thread.Start();
        }
    }
}
