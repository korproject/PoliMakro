using KOR.ErrorReporter;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Poli.Makro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// KOR Apis uses same credentials
        /// </summary>
        private readonly string KOR_API_KEY = "22B6EB8F159F1B209F1CC982AC8A3EA0B30C5B9E3DCCEEC167FCFCA06866BCB7";
        private readonly string KOR_API_SECRET = "e6842c6e809e4bee48d4b0a6815231b7f21042e4d119b465681541b683f8dd565214200470f8b3b46841ee7a98adae19";


        /// <summary>
        /// Default constructor
        /// </summary>
        public App()
        {
			Core.AppSettings.LoadSettings();

            SendedErrors++;
            SendFailErrors++;


            KOR.ErrorReporter.Models.Api.OutputType = KOR.ErrorReporter.Models.Api.OutputTypes.Json;
            KOR.ErrorReporter.Models.Api.API_KEY = KOR_API_KEY;
            KOR.ErrorReporter.Models.Api.API_SECRET = KOR_API_SECRET;
        }

        #region Error Handlers

        /// <summary>
        /// Error counters
        /// </summary>
        public static int SendedErrors { get; set; }
        public static int SendFailErrors { get; set; }

        /// <summary>
        /// Dispatcher Unhandled Exception Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            SendUnhandledError(args.Exception, "TaskScheduler.UnobservedTaskException");
            MessageBox.Show(args.Exception.ToString(), "Unhandled Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            args.Handled = true;
        }

        /// <summary>
        /// Unobserved Task Exception Event
        /// </summary>
        /// <param name="args"></param>
        private void TaskSchedulerOnUnobservedTaskException(UnobservedTaskExceptionEventArgs args)
        {
            SendUnhandledError(args.Exception, "TaskScheduler.UnobservedTaskException");
            MessageBox.Show(args.Exception.ToString(), "Unhandled Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// Dispatcher Unhandled Exception Event
        /// </summary>
        /// <param name="args"></param>
        private void CurrentOnDispatcherUnhandledException(DispatcherUnhandledExceptionEventArgs args)
        {
            SendUnhandledError(args.Exception, "TaskScheduler.UnobservedTaskException");
            MessageBox.Show(args.Exception.ToString(), "Unhandled Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            args.Handled = true;
        }

        #region Error Sender

        private void SendUnhandledError(Exception exp, string @event)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                KOR.ErrorReporter.Models.Error error = new KOR.ErrorReporter.Models.Error()
                {
                    Title = @event,
                    Content = exp,
                    Severity = 10,
                    Comment = "Unhandled exception",
                    Description = "Catched grom global error handlers"
                };

                MessageBox.Show(exp.Message);

                ErrorReport errorReporter = new ErrorReport()
                {
                    Error = error
                };

                var report = errorReporter.ReportError();
                if (report)
                {
                    SendedErrors++;
                }
                else
                {
                    SendFailErrors++;
                }

                Debug.WriteLine(report);
            }).Start();
        }

        #endregion

        #endregion
    }
}
