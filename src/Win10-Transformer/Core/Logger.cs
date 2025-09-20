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
                var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
                File.AppendAllText(logFilePath, logMessage);
            }
            catch (Exception)
            {
                // Ignore logging errors
            }
        }
    }
}
