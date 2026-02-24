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
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAl", 1, RegistryValueKind.DWord),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarAl"), 0)
                ),
                new Tweak(
                    "Taskbar: Use Small Icons",
                    "Sets the taskbar icons to a smaller size.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarSi", 0, RegistryValueKind.DWord),
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarSi", 1, RegistryValueKind.DWord),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarSi"), 0)
                ),
                new Tweak(
                    "Taskbar: Hide Search Icon",
                    "Hides the search icon from the taskbar.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "SearchboxTaskbarMode", 0, RegistryValueKind.DWord),
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "SearchboxTaskbarMode", 1, RegistryValueKind.DWord),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Search", "SearchboxTaskbarMode"), 0)
                ),
                new Tweak(
                    "Taskbar: Never Combine Buttons",
                    "Prevents grouping of taskbar buttons.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarGlomLevel", 2, RegistryValueKind.DWord),
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarGlomLevel", 0, RegistryValueKind.DWord),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarGlomLevel"), 2)
                ),
                new Tweak(
                    "Taskbar: Hide Task View Button",
                    "Hides the Task View (timeline) button from the taskbar.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowTaskViewButton", 0, RegistryValueKind.DWord),
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowTaskViewButton", 1, RegistryValueKind.DWord),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowTaskViewButton"), 0)
                ),
                new Tweak(
                    "Taskbar: Hide Widgets Icon",
                    "Hides the Widgets (News and Interests) icon from the taskbar.",
                    () => {
                        RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Feeds", "ShellFeedsTaskbarViewMode", 2, RegistryValueKind.DWord);
                        RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarDa", 0, RegistryValueKind.DWord);
                    },
                    () => {
                        RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Feeds", "ShellFeedsTaskbarViewMode", 0, RegistryValueKind.DWord);
                        RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarDa", 1, RegistryValueKind.DWord);
                    },
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Feeds", "ShellFeedsTaskbarViewMode"), 2)
                ),
                 new Tweak(
                    "Taskbar: Hide Chat (Teams) Icon",
                    "Hides the Chat (Microsoft Teams) icon from the taskbar.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarMn", 0, RegistryValueKind.DWord),
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarMn", 1, RegistryValueKind.DWord),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "TaskbarMn"), 0)
                ),

                // --------------- Start Menu ---------------
                new Tweak(
                    "Start Menu: Use Classic Layout",
                    "Enables a more classic Start Menu layout.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Start_ShowClassicMode", 1, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Start_ShowClassicMode"),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "Start_ShowClassicMode"), 1)
                ),
                new Tweak(
                    "Start Menu: Remove 'People' Icon",
                    "Removes the 'People' icon from the Start Menu.",
                    () => RegistryManager.DeleteKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\People"),
                    () => RegistryManager.CreateKey(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\People"),
                    () => !RegistryManager.KeyExists(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\People")
                ),

                // --------------- File Explorer ---------------
                new Tweak(
                    "Explorer: Enable Classic Context Menu",
                    "Restores the classic right-click context menu.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32", "", "", RegistryValueKind.String),
                    () => RegistryManager.DeleteKey(@"HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}"),
                    () => RegistryManager.KeyExists(@"HKEY_CURRENT_USER\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}")
                ),
                new Tweak(
                    "Explorer: Launch to 'This PC'",
                    "Sets File Explorer to open to 'This PC' instead of 'Quick Access'.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "LaunchTo", 1, RegistryValueKind.DWord),
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "LaunchTo", 2, RegistryValueKind.DWord),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "LaunchTo"), 1)
                ),
                 new Tweak(
                    "Explorer: Show File Extensions",
                    "Makes File Explorer show extensions for all file types.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "HideFileExt", 0, RegistryValueKind.DWord),
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "HideFileExt", 1, RegistryValueKind.DWord),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "HideFileExt"), 0)
                ),
                new Tweak(
                    "Explorer: Show Status Bar",
                    "Shows the status bar at the bottom of File Explorer.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowStatusBar", 1, RegistryValueKind.DWord),
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowStatusBar", 0, RegistryValueKind.DWord),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ShowStatusBar"), 1)
                ),

                // --------------- Visual Style ---------------
                new Tweak(
                    "Visual: Use Win10-style Borders",
                    "Changes window border width to be more like Windows 10.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics", "BorderWidth", "-15", RegistryValueKind.String),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics", "BorderWidth"),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics", "BorderWidth"), "-15")
                ),
                new Tweak(
                    "Visual: Disable Transparency",
                    "Disables transparency effects for a more solid look.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "EnableTransparency", 0, RegistryValueKind.DWord),
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "EnableTransparency", 1, RegistryValueKind.DWord),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\DWM", "EnableTransparency"), 0)
                ),
                new Tweak(
                    "Visual: Disable Selection Transparency",
                    "Disables transparency for the selection rectangle in lists.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ListviewAlphaSelect", 0, RegistryValueKind.DWord),
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ListviewAlphaSelect", 1, RegistryValueKind.DWord),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "ListviewAlphaSelect"), 0)
                ),

                // --------------- System Behaviors ---------------
                new Tweak(
                    "System: Fast Menu Show Delay",
                    "Removes the delay when hovering over menus.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "MenuShowDelay", "0", RegistryValueKind.String),
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "MenuShowDelay", "400", RegistryValueKind.String),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Control Panel\Desktop", "MenuShowDelay"), "0")
                ),
                new Tweak(
                    "System: Disable Aero Shake",
                    "Disables the 'Aero Shake' feature that minimizes other windows.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "DisallowShaking", 1, RegistryValueKind.DWord),
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "DisallowShaking", 0, RegistryValueKind.DWord),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced", "DisallowShaking"), 1)
                ),
                new Tweak(
                    "System: Disable Recent Docs History",
                    "Stops the system from tracking recently opened documents.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoRecentDocsHistory", 1, RegistryValueKind.DWord),
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoRecentDocsHistory", 0, RegistryValueKind.DWord),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer", "NoRecentDocsHistory"), 1)
                ),
                new Tweak(
                    "System: Show Seconds in Clock",
                    "Shows seconds in the taskbar clock.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer", "ShowSecondsInSystemClock", 1, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer", "ShowSecondsInSystemClock"),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer", "ShowSecondsInSystemClock"), 1)
                ),

                // --------------- New Tweaks from Batch Script ---------------
                new Tweak(
                    "System: Replace with Classic Notepad",
                    "Uses the classic notepad.exe instead of the new Windows 11 version.",
                    () => RegistryManager.SetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\notepad.exe", "Debugger", "notepad.exe", RegistryValueKind.String),
                    () => RegistryManager.DeleteValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\notepad.exe", "Debugger"),
                    () => Equals(RegistryManager.GetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\notepad.exe", "Debugger"), "notepad.exe")
                ),
                new Tweak(
                    "System: Restore Photo Viewer",
                    "Restores the classic Windows Photo Viewer.",
                    () => RegistryManager.SetValue(@"HKEY_CLASSES_ROOT\Applications\photoviewer.dll\shell\open\command", "", "rundll32.exe \"%ProgramFiles%\\Windows Photo Viewer\\PhotoViewer.dll\", ImageView_Fullscreen %1", RegistryValueKind.String),
                    () => RegistryManager.DeleteKey(@"HKEY_CLASSES_ROOT\Applications\photoviewer.dll"),
                    () => RegistryManager.KeyExists(@"HKEY_CLASSES_ROOT\Applications\photoviewer.dll")
                ),
                new Tweak(
                    "System: Disable Sticky Keys Shortcut",
                    "Disables the shortcut to enable Sticky Keys (pressing Shift 5 times).",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\StickyKeys", "Flags", "506", RegistryValueKind.String),
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\StickyKeys", "Flags", "510", RegistryValueKind.String),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Control Panel\Accessibility\StickyKeys", "Flags"), "506")
                ),
                new Tweak(
                    "System: Disable Search Box Suggestions",
                    "Disables suggestions in the taskbar search box.",
                    () => RegistryManager.SetValue(@"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\Explorer", "DisableSearchBoxSuggestions", 1, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\Explorer", "DisableSearchBoxSuggestions"),
                    () => Equals(RegistryManager.GetValue(@"HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\Explorer", "DisableSearchBoxSuggestions"), 1)
                ),
                 new Tweak(
                    "System: Disable Background Apps",
                    "Disables most apps from running in the background to save resources.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", "GlobalUserDisabled", 1, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", "GlobalUserDisabled"),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications", "GlobalUserDisabled"), 1)
                ),
                new Tweak(
                    "System: Disable Suggestions",
                    "Disables 'suggested content' and ads in Settings and elsewhere.",
                    () => RegistryManager.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338393Enabled", 0, RegistryValueKind.DWord),
                    () => RegistryManager.DeleteValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338393Enabled"),
                    () => Equals(RegistryManager.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager", "SubscribedContent-338393Enabled"), 0)
                )
            };

            // Initialize status for all tweaks
            foreach (var tweak in Tweaks)
            {
                tweak.RefreshStatus();
            }
        }
    }
}
