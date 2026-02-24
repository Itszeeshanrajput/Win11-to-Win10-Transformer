using System;
using System.IO;

namespace Win10_Transformer.Core
{
    public static class Logger
    {
        private static readonly string logFilePath = Path.Combine(AppContext.BaseDirectory, "log.txt");

        public static void Log(string message)
        {
            try
            {
                var directory = Path.GetDirectoryName(logFilePath);
                if (directory != null && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
                File.AppendAllText(logFilePath, logMessage);
            }
            catch (Exception ex)
            {
                // Can't log the error about logging, but we can try to output to debug
                System.Diagnostics.Debug.WriteLine($"Failed to log: {ex.Message}");
            }
        }
    }
}
