using FolderBackupTool.gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderBackupTool
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainMenu());
            }
            else
            {
                AttachConsole(-1);
                CommandLineExecution.Execute(args);
            }
        }


        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);
    }
}
