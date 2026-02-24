using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows;

namespace Win10_Transformer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            if (!IsRunningAsAdministrator())
            {
                RestartAsAdministrator();
            }
        }

        private bool IsRunningAsAdministrator()
        {
            try
            {
                var identity = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                return false;
            }
        }

        private void RestartAsAdministrator()
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = Environment.ProcessPath,
                UseShellExecute = true,
                Verb = "runas"
            };

            try
            {
                Process.Start(processInfo);
            }
            catch (Exception)
            {
                // The user cancelled the UAC prompt or another error occurred
                MessageBox.Show("This application requires administrator privileges to modify system settings. Please run it as an administrator.", "Administrator Privileges Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            Shutdown();
        }
    }
}
