using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FolderBackupTool
{
    class BackupRestorationCommand
    {
        public static void Execute(string[] args)
        {
            if (args.Length < 4)
            {
                Console.Error.WriteLine("Usage: restore <backups_directory> <backup_name> <destination>");
                return;
            }

            string backupsDirectory = args[1];
            string backupName = args[2];
            string destination = args[3];

            var parameterError = GetParameterError(backupsDirectory, backupName, destination);
            if (parameterError != null)
            {
                Console.Error.WriteLine(parameterError);
                return;
            }

            RestoreBackup(backupsDirectory, backupName, destination);
        }

        private static string GetParameterError(string backupsDirectory, string backupName, string destination)
        {
            if (string.IsNullOrEmpty(backupsDirectory))
                return "Must provide a backups directory";

            if (string.IsNullOrEmpty(destination))
                return "Must provide a valid output directory";

            if (string.IsNullOrEmpty(backupName))
                return "Must provide a backup to restore";

            if (!Directory.Exists(backupsDirectory))
                return $"Directory does not exist: {backupsDirectory}";

            if (!Directory.Exists(destination))
                return $"Directory does not exist: {destination}";

            var backupDataFilePath = Path.Combine(backupsDirectory, backupName, BackupProcess.BackupDataFilename);
            if (!File.Exists(backupDataFilePath))
                return $"Backup does not exist: {backupName}";

            return null;
        }

        private static void RestoreBackup(string backupsDirectory, string restoredBackupName, string restorationDirectory)
        {
            var restorationProcess = new BackupRestorationProcess(backupsDirectory, restoredBackupName, restorationDirectory);
            var restorationMonitor = new RestorationProgressMonitor();

            var errors = new Queue<string>();
            restorationMonitor.ErrorReceived += (inputPath, outputPath, error, directory) =>
                errors.Enqueue($"Could not copy \"{inputPath}\" to \"{outputPath}\": {error.GetType()}");

            Console.WriteLine($"Restoring backup \"{restoredBackupName}\" to {restorationDirectory}");
            Console.WriteLine("Loading backup data...");

            try
            {
                restorationProcess.LoadBackupData();

                Console.WriteLine($"Restoring {restorationProcess.FilesToRestore} files, {restorationProcess.DirectoriesToRestore} directories");
                Console.WriteLine("Restoring files...");

                bool finishedRestoringFiles = false;
                var loggerTask = new Task(() =>
                {
                    while (!finishedRestoringFiles)
                    {
                        CommandLineExecution.RewindConsole();

                        while (errors.Count > 0)
                            Console.Error.WriteLine(errors.Dequeue());

                        Console.Write($"({restorationMonitor.FilesRestored} / {restorationProcess.FilesToRestore}) {restorationMonitor.LastRestored}");

                        Thread.Sleep(20);
                    }

                    CommandLineExecution.RewindConsole();
                    Console.WriteLine($"{restorationMonitor.FilesRestored} files restored");
                    Console.WriteLine($"Restored backup {restoredBackupName}");
                });
                loggerTask.Start();

                restorationProcess.RestoreBackup(restorationMonitor);
                finishedRestoringFiles = true;

                loggerTask.Wait();
            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                Environment.Exit(1);
            }
        }
    }
}
