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
                    "Taskbar: Align to Left",
                    "Sets the taskbar alignment to the left, like in Windows 10.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAl", 0, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAl")
                ),
                new Tweak(
                    "Taskbar: Use Small Icons",
                    "Sets the taskbar icons to a smaller size. (Note: In Win11 this is often called 'Large' in the registry).",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarSi", 0, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarSi")
                ),
                new Tweak(
                    "Taskbar: Hide Search Icon",
                    "Hides the search icon from the taskbar.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "SearchboxTaskbarMode", 0, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "SearchboxTaskbarMode")
                ),
                new Tweak(
                    "Taskbar: Never Combine Buttons",
                    "Prevents grouping of taskbar buttons.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarGlomLevel", 2, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarGlomLevel")
                ),
                new Tweak(
                    "Taskbar: Hide Task View Button",
                    "Hides the Task View (timeline) button from the taskbar.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowTaskViewButton", 0, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowTaskViewButton")
                ),
                new Tweak(
                    "Taskbar: Hide Widgets Icon",
                    "Hides the Widgets (News and Interests) icon from the taskbar.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Feeds", "ShellFeedsTaskbarViewMode", 2, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Feeds", "ShellFeedsTaskbarViewMode")
                ),
                 new Tweak(
                    "Taskbar: Hide Chat (Teams) Icon",
                    "Hides the Chat (Microsoft Teams) icon from the taskbar.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarMn", 0, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarMn")
                ),

                // --------------- Start Menu ---------------
                new Tweak(
                    "Start Menu: Use Classic Layout",
                    "Enables a more classic Start Menu layout.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Start_ShowClassicMode", 1, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Start_ShowClassicMode")
                ),
                new Tweak(
                    "Start Menu: Remove 'People' Icon",
                    "Removes the 'People' icon from the Start Menu.",
                    () => RegistryManager.DeleteKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\People"),
                    () => { /* No direct revert, would require recreating the key with defaults */ }
                ),

                // --------------- File Explorer ---------------
                new Tweak(
                    "Explorer: Enable Classic Context Menu",
                    "Restores the classic right-click context menu.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32", "", "", RegistryValueKind.String),
                    () => RegistryManager.DeleteKey(@"HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}")
                ),
                new Tweak(
                    "Explorer: Launch to 'This PC'",
                    "Sets File Explorer to open to 'This PC' instead of 'Quick Access'.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "LaunchTo", 1, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "LaunchTo")
                ),
                 new Tweak(
                    "Explorer: Show File Extensions",
                    "Makes File Explorer show extensions for all file types.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "HideFileExt", 0, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "HideFileExt")
                ),
                new Tweak(
                    "Explorer: Show Status Bar",
                    "Shows the status bar at the bottom of File Explorer.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowStatusBar", 1, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowStatusBar")
                ),

                // --------------- Visual Style ---------------
                new Tweak(
                    "Visual: Use Win10-style Borders",
                    "Changes window border width to be more like Windows 10.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics", "BorderWidth", "-15", RegistryValueKind.String),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics", "BorderWidth")
                ),
                new Tweak(
                    "Visual: Disable Transparency",
                    "Disables transparency effects for a more solid look.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "EnableTransparency", 0, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "EnableTransparency")
                ),
                new Tweak(
                    "Visual: Disable Selection Transparency",
                    "Disables transparency for the selection rectangle in lists.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ListviewAlphaSelect", 0, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ListviewAlphaSelect")
                ),

                // --------------- System Behaviors ---------------
                new Tweak(
                    "System: Fast Menu Show Delay",
                    "Removes the delay when hovering over menus.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "MenuShowDelay", "0", RegistryValueKind.String),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "MenuShowDelay")
                ),
                new Tweak(
                    "System: Disable Aero Shake",
                    "Disables the 'Aero Shake' feature that minimizes other windows.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "DisallowShaking", 1, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "DisallowShaking")
                ),
                new Tweak(
                    "System: Disable Recent Docs History",
                    "Stops the system from tracking recently opened documents.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoRecentDocsHistory", 1, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoRecentDocsHistory")
                ),
                new Tweak(
                    "System: Show Seconds in Clock",
                    "Shows seconds in the taskbar clock.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer", "ShowSecondsInSystemClock", 1, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer", "ShowSecondsInSystemClock")
                ),
            };
        }
    }
}
