using System.Collections.Generic;
using Microsoft.Win32;

namespace Win10_Transformer.Core
{
    /// <summary>
    /// Manages the list of available tweaks.
    /// </summary>
    public class TweakManager
    {
        public List<Tweak> Tweaks { get; }

        public TweakManager()
        {
            Tweaks = new List<Tweak>
            {
                // --------------- Taskbar ---------------
                new Tweak(
                    "Align Taskbar to Left",
                    "Sets the taskbar alignment to the left, like in Windows 10.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAl", 0, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAl")
                ),
                new Tweak(
                    "Use Large Taskbar Icons",
                    "Sets the taskbar icons to a larger size.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarSi", 2, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarSi")
                ),
                new Tweak(
                    "Hide Search Box",
                    "Hides the search box from the taskbar.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "SearchboxTaskbarMode", 0, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "SearchboxTaskbarMode")
                ),
                new Tweak(
                    "Never Combine Taskbar Buttons",
                    "Prevents grouping of taskbar buttons.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarGlomLevel", 2, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarGlomLevel")
                ),

                // --------------- Start Menu ---------------
                new Tweak(
                    "Use Classic Start Menu",
                    "Enables a more classic Start Menu layout.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Start_ShowClassicMode", 1, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Start_ShowClassicMode")
                ),

                // --------------- File Explorer ---------------
                new Tweak(
                    "Enable Classic Context Menu",
                    "Restores the classic right-click context menu.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32", "", "", RegistryValueKind.String),
                    () => RegistryManager.DeleteKey(@"HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}")
                ),
                new Tweak(
                    "Launch to 'This PC'",
                    "Sets File Explorer to open to 'This PC' instead of 'Quick Access'.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "LaunchTo", 1, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "LaunchTo")
                ),
                 new Tweak(
                    "Show File Extensions",
                    "Makes File Explorer show extensions for all file types.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "HideFileExt", 0, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "HideFileExt")
                ),

                // --------------- Visual Style ---------------
                new Tweak(
                    "Disable Transparency",
                    "Disables transparency effects for a more solid look.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "EnableTransparency", 0, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "EnableTransparency")
                ),
            };
        }
    }
}
