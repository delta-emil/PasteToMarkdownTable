using System;
using System.Windows.Forms;

namespace PasteToMarkdownTable
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if NET7_0_OR_GREATER
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
#endif
            Application.Run(new FormMain());
        }
    }
}