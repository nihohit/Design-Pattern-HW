using System;
using System.Windows.Forms;

namespace FacebookAppGUI
{
    using System.Threading;

    using FacebookApplication;

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // Catch all unhandled exceptions
            Application.ThreadException += ThreadExceptionHandler;

            // Catch all unhandled exceptions in all threads.
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }

        private static void ThreadExceptionHandler(object sender, ThreadExceptionEventArgs args)
        {
            args.Exception.ShowErrorMessageBox();
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            ((Exception)args.ExceptionObject).ShowErrorMessageBox("Unhandled error. Application will crash.");
        }
    }
}
