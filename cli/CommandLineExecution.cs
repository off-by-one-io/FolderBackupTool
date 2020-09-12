using FolderBackupTool;
using FolderBackupTool.gui;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace FolderBackupTool
{
    class CommandLineExecution
    {
        public static void Execute(string[] args)
        {
            Console.WriteLine();

            switch(args[0])
            {
                case "backup":
                    BackupCreationCommand.Execute(args);
                    break;
                case "restore":
                    BackupRestorationCommand.Execute(args);
                    break;
                default:
                    Console.Error.WriteLine($"Unknown command \"{args[0]}\"");
                    break;
            }
        }

        public static void RewindConsole()
        {
            int cursorPosition = Console.CursorLeft;
            Console.CursorLeft = 0;
            Console.Write(new string(' ', cursorPosition));
            Console.CursorLeft = 0;
        }
    }
}
