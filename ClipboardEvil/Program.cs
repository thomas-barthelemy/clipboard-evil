using System;
using System.Windows.Forms;

namespace ClipboardEvil
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var clipboardEvil = new ClipboardEvil();
            Application.Run(clipboardEvil);
        }
    }
}
