using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace PropertyGridTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Changes the CurrentCulture of the current thread to th-TH.
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU", false);
            Trace.WriteLine("Main: CurrentUICulture is " + CultureInfo.CurrentUICulture.Name);
            Trace.WriteLine("Main: CurrentCulture is " + CultureInfo.CurrentCulture.Name);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}