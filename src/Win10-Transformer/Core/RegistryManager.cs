using Microsoft.Win32;
using System.Diagnostics;
using System.Linq;

namespace Win10_Transformer.Core
{
    /// <summary>
    /// Provides low-level methods for interacting with the Windows Registry and system processes.
    /// </summary>
    public static class RegistryManager
    {
        /// <summary>
        /// Sets a value in the Windows Registry. The hive (e.g., HKEY_CURRENT_USER) is parsed from the key name.
        /// </summary>
        public static void SetValue(string keyName, string valueName, object value, RegistryValueKind kind)
        {
            try
            {
                Registry.SetValue(keyName, valueName, value, kind);
                Logger.Log($"Set registry value '{valueName}' in '{keyName}'.");
            }
            catch (System.Exception ex)
            {
                Logger.Log($"Error setting registry value: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a value from the Windows Registry.
        /// </summary>
        public static void DeleteValue(string keyName, string valueName)
        {
            try
            {
                var (hive, subKeyPath) = ParseKeyName(keyName);
                if (hive == null) return;

                using (var key = hive.OpenSubKey(subKeyPath, true))
                {
                    if (key != null && key.GetValue(valueName) != null)
                    {
                        key.DeleteValue(valueName, false);
                        Logger.Log($"Deleted registry value '{valueName}' from '{keyName}'.");
                    }
                }
            }
            catch (System.Exception ex)
            {
                Logger.Log($"Error deleting registry value: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a key and all its subkeys from the Windows Registry.
        /// </summary>
        public static void DeleteKey(string keyName)
        {
            try
            {
                var (parentHive, parentKeyPath, subKeyName) = ParseKeyForDeletion(keyName);
                if (parentHive == null) return;

                using (var parentKey = parentHive.OpenSubKey(parentKeyPath, true))
                {
                    if (parentKey != null && parentKey.GetSubKeyNames().Contains(subKeyName))
                    {
                        parentKey.DeleteSubKeyTree(subKeyName);
                        Logger.Log($"Deleted registry key '{keyName}'.");
                    }
                }
            }
            catch (System.Exception ex)
            {
                Logger.Log($"Error deleting registry key: {ex.Message}");
            }
        }

        /// <summary>
        /// Restarts the Windows Explorer process.
        /// </summary>
        public static void RestartExplorer()
        {
            Logger.Log("Attempting to restart explorer.exe.");
            foreach (var process in Process.GetProcessesByName("explorer"))
            {
                process.Kill();
            }
        }

        /// <summary>
        /// Creates a system restore point by invoking PowerShell.
        /// </summary>
        public static void CreateRestorePoint()
        {
            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = "-Command \"Checkpoint-Computer -Description 'Pre-Win10-Transform' -RestorePointType MODIFY_SETTINGS\"",
                    Verb = "runas"
                };
                Process.Start(startInfo)?.WaitForExit();
            }
            catch (System.ComponentModel.Win32Exception)
            {
                Logger.Log("UAC prompt for restore point was cancelled.");
            }
            catch (System.Exception ex)
            {
                Logger.Log($"Error creating restore point: {ex.Message}");
            }
        }

        private static (RegistryKey?, string) ParseKeyName(string keyName)
        {
            var parts = keyName.Split('\\');
            var hiveName = parts[0];
            var subKeyPath = string.Join("\\", parts.Skip(1));

            RegistryKey? hive = hiveName.ToUpperInvariant() switch
            {
                "HKEY_CURRENT_USER" or "HKCU" => Registry.CurrentUser,
                "HKEY_LOCAL_MACHINE" or "HKLM" => Registry.LocalMachine,
                "HKEY_CLASSES_ROOT" or "HKCR" => Registry.ClassesRoot,
                "HKEY_USERS" => Registry.Users,
                "HKEY_CURRENT_CONFIG" => Registry.CurrentConfig,
                _ => null
            };

            return (hive, subKeyPath);
        }

        private static (RegistryKey?, string, string) ParseKeyForDeletion(string keyName)
        {
            var lastBackslash = keyName.LastIndexOf('\\');
            var parentPath = keyName.Substring(0, lastBackslash);
            var subKeyName = keyName.Substring(lastBackslash + 1);

            var (hive, actualParentPath) = ParseKeyName(parentPath);

            return (hive, actualParentPath, subKeyName);
        }
    }
}
