# 🔄 Win11→10 UI Transformer - Professional Windows Customization Tool

<div align="center">

**Transform Windows 11 Interface to Windows 10 Aesthetic | 40+ Registry Tweaks | Safe & Reversible**

[![.NET](https://img.shields.io/badge/.NET-7.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-Latest-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)](LICENSE)
[![Status](https://img.shields.io/badge/Status-Active-brightgreen?style=for-the-badge)](https://github.com/Itszeeshanrajput/Win11-to-Win10-Transformer)

**#Windows11 #Windows10 #UICustomization #Registry #SystemTweaks**

[Download](#-download) • [Features](#-features) • [Installation](#-installation) • [Usage](#-usage) • [FAQ](#-faq)

</div>

---

## 📸 Overview

**Win11→10 Transformer** is a modern C# application that lets you restore the Windows 10 look and feel on Windows 11. With 40+ carefully crafted registry tweaks, you can customize your taskbar, Start menu, File Explorer, and more—all safely and reversibly.

### Why Use This?
- ✅ **Nostalgic Look** - Bring back Windows 10's familiar interface
- ✅ **Performance** - Disable unnecessary Windows 11 features
- ✅ **Customization** - Fine-tune your experience exactly how you want it
- ✅ **Safe & Reversible** - Built-in restore points & one-click revert
- ✅ **Selective Control** - Choose exactly which tweaks to apply
- ✅ **No Admin Skills Needed** - Simple, user-friendly interface

---

## ✨ Key Features

### 🎨 Visual Transformations
- **Taskbar Customization** - Classic alignment, no search box, no widgets
- **Start Menu** - Return to Windows 10-style Start menu
- **File Explorer** - Restore classic ribbon interface
- **Context Menus** - Simplified right-click menus
- **Window Borders** - Traditional title bars and window styling

### 🛡️ Safety Features
- ✅ **Automatic Restore Points** - Backup before applying tweaks
- ✅ **One-Click Revert** - Undo any tweak instantly
- ✅ **Full Reversibility** - Revert all changes at once
- ✅ **Logging System** - Track all modifications for troubleshooting
- ✅ **Admin Validation** - Ensures safe registry modifications

### ⚙️ Advanced Capabilities
- **Profile Management** - Save & load your favorite tweak combinations
- **Batch Operations** - Apply multiple tweaks simultaneously
- **Live Preview** - See changes without restart (when possible)
- **Explorer Restart** - Quick restart Windows Explorer
- **Detailed Descriptions** - Understand what each tweak does

---

## 🚀 Getting Started

### Requirements
- **OS:** Windows 11 (any edition)
- **Admin Rights:** Required for registry modifications
- **.NET:** .NET 7 SDK (for building from source)

### Download & Install

#### Option 1: Pre-Built Executable (Recommended)
1. Go to [Releases](https://github.com/Itszeeshanrajput/Win11-to-Win10-Transformer/releases)
2. Download latest `Win11-to-Win10-Transformer.zip`
3. Extract to desired location
4. Run `Win11toWin10Transformer.exe` (requires admin rights)

#### Option 2: Build from Source
```bash
# Clone repository
git clone https://github.com/Itszeeshanrajput/Win11-to-Win10-Transformer.git
cd Win11-to-Win10-Transformer

# Build
dotnet build --configuration Release

# Run
dotnet run --configuration Release
```

---

## 📖 Usage Guide

### Step 1: Backup Your System
```
✅ IMPORTANT: Create a system restore point before applying tweaks
- Click "Create Restore Point" button
- This creates an automatic backup you can revert to
```

### Step 2: Select Your Tweaks

1. **Browse Available Tweaks**
   - Taskbar modifications
   - Start menu customizations
   - File Explorer changes
   - Context menu updates
   - Window styling adjustments

2. **Read Descriptions**
   - Each tweak has a detailed explanation
   - Understand what will change
   - Some tweaks require Explorer restart

3. **Select What You Want**
   - Check boxes for desired tweaks
   - Mix and match freely
   - Create custom combinations

### Step 3: Apply Tweaks

```
1. Click "Apply Selected" button
2. Choose restart option if needed:
   - Explorer restart (quick, most changes apply)
   - Full restart (for all changes to take effect)
   - No restart (changes take effect on next login)
3. Monitor progress in the status window
```

### Step 4: Save Your Profile (Optional)

```
1. Click "Save Profile"
2. Name your profile (e.g., "Classic Look")
3. Load it anytime to reapply the same tweaks
```

### Step 5: Revert Changes (If Needed)

```
Option A: Individual Tweak Revert
- Select tweak you want to undo
- Click "Revert Selected"
- Changes roll back instantly

Option B: Full Revert
- Click "Revert All"
- All tweaks revert to Windows 11 defaults
- Instant and complete restoration
```

---

## 📋 Available Tweaks (Sample)

### Taskbar (8 tweaks)
- [ ] Left-align taskbar
- [ ] Remove search box
- [ ] Hide widgets button
- [ ] Disable taskbar transparency
- [ ] Classic taskbar icons
- [ ] Show taskbar labels
- [ ] Disable taskbar animation
- [ ] Compact taskbar mode

### Start Menu (6 tweaks)
- [ ] Windows 10-style Start menu
- [ ] Remove recommendations
- [ ] Disable app suggestions
- [ ] Classic all apps view
- [ ] Simple search box
- [ ] Remove rounded corners

### File Explorer (8 tweaks)
- [ ] Classic File Explorer ribbon
- [ ] Traditional toolbar
- [ ] Remove modern animations
- [ ] Compact view mode
- [ ] Show file extensions by default
- [ ] Classic folder icons
- [ ] Disable fancy preview pane
- [ ] Simple status bar

### Windows & Visual (10 tweaks)
- [ ] Traditional title bars
- [ ] Remove rounded corners
- [ ] Disable transparency effects
- [ ] Classic color scheme
- [ ] Traditional window borders
- [ ] Simple shadow effects
- [ ] Disable animations
- [ ] Classic icon style
- [ ] Traditional scroll bars
- [ ] Simple menu styling

### Performance (8 tweaks)
- [ ] Disable unnecessary services
- [ ] Remove visual effects
- [ ] Disable background apps
- [ ] Reduce animation overhead
- [ ] Disable idle cleanup
- [ ] Faster shutdown
- [ ] Disable telemetry
- [ ] Reduce startup tasks

*+ 12 more tweaks available in the full version*

---

## ⚙️ Advanced Configuration

### Command Line Usage
```bash
# Apply profile from command line
Win11toWin10Transformer.exe --apply "Classic Look"

# Revert all changes
Win11toWin10Transformer.exe --revert-all

# Create restore point
Win11toWin10Transformer.exe --restore-point
```

### Registry Backup
All modifications are logged in:
```
C:\Users\[YourUsername]\AppData\Local\Win11toWin10\registry_backup.reg
```

You can manually restore by double-clicking the .reg file if needed.

---

## 🔧 Troubleshooting

### Issue: "Administrator Privileges Required"
```
✅ Solution:
1. Right-click Win11toWin10Transformer.exe
2. Select "Run as Administrator"
3. Click "Yes" in the UAC prompt
```

### Issue: Changes Don't Take Effect
```
✅ Solution:
1. Select "Restart Explorer" option
2. Or use "Restart Computer" for full effect
3. Some tweaks require full restart to apply
4. Log out/login if still not working
```

### Issue: "Cannot Create Restore Point"
```
✅ Solution:
1. Ensure System Restore is enabled
2. Settings → System → About → System protection
3. Check disk space (needs 500MB+ free)
4. Run as Administrator
```

### Issue: "Registry Access Denied"
```
✅ Solution:
1. Disable antivirus temporarily
2. Run Windows Defender scan
3. Boot in Safe Mode with Command Prompt
4. Run the application as Administrator
```

### Issue: Want to Restore Windows 11 Defaults
```
✅ Solutions (in order of preference):
1. Click "Revert All" in application
2. Use System Restore (if you created a point)
3. Settings → Reset this PC → Reset (last resort)
```

---

## 📁 Project Structure

```
Win11-to-Win10-Transformer/
├── src/
│   ├── MainWindow.xaml           # Main UI
│   ├── MainWindow.xaml.cs        # Logic
│   ├── RegistryManager.cs        # Registry operations
│   ├── TweakManager.cs           # Tweak handling
│   ├── RestorePointManager.cs    # System restore
│   ├── ProfileManager.cs         # Save/load profiles
│   └── Models/
│       ├── Tweak.cs              # Tweak data model
│       └── Profile.cs            # Profile data model
├── Resources/
│   ├── Icons/
│   └── Styles/
├── Win11toWin10.csproj          # Project file
├── App.xaml                      # Application settings
├── LICENSE                       # MIT License
└── README.md                     # This file
```

---

## ⚠️ Important Notes

### Before You Start
- ⚠️ **Backup Your Data** - Use System Restore Point feature
- ⚠️ **Admin Rights Required** - Application needs administrator privileges
- ⚠️ **Test First** - Apply a few tweaks first, then revert if unsure
- ⚠️ **Use at Your Own Risk** - Direct registry modifications can cause issues
- ⚠️ **Windows Updates** - Windows Updates may reset some tweaks

### Security
- 🔒 All registry changes are safe and documented
- 🔒 Only modifies user preferences, not system files
- 🔒 Never modifies security or boot settings
- 🔒 Automatic logging for troubleshooting

---

## 🤝 Contributing

Contributions welcome! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

### Ways to Help
- 🐛 Report bugs and issues
- ✨ Suggest new tweaks
- 📝 Improve documentation
- 🎨 UI/UX improvements
- 🧪 Test on different Windows builds
- 🔧 Help with code improvements

---

## 📄 License

This project is licensed under the MIT License - see [LICENSE](LICENSE) file for details.

---

## 📞 Support

### Get Help
- 📖 [Troubleshooting Guide](#-troubleshooting)
- 🐛 [Report a Bug](https://github.com/Itszeeshanrajput/Win11-to-Win10-Transformer/issues)
- 💡 [Request a Feature](https://github.com/Itszeeshanrajput/Win11-to-Win10-Transformer/issues)
- 📧 **Email:** itszeeshanrajput@gmail.com
- 🔗 **GitHub:** [@Itszeeshanrajput](https://github.com/Itszeeshanrajput)

---

## 🌟 FAQ

**Q: Will this break my Windows 11?**
A: No. All changes are reversible. Use the Revert function or System Restore if needed.

**Q: Does this violate Windows terms?**
A: No. You're only modifying your personal preferences through registry settings.

**Q: Will this slow down my computer?**
A: No. Some tweaks actually improve performance by disabling unnecessary features.

**Q: Can I mix tweaks from different profiles?**
A: Yes. You can select tweaks individually and create custom combinations.

**Q: What if Windows Update resets my tweaks?**
A: After major updates, reapply your saved profile using the Load Profile feature.

**Q: Is it safe to revert changes?**
A: Yes. The revert function is fully safe and reverses all modifications.

---

<div align="center">

### ⭐ If this tool helps you, please give it a star!

**Made with ❤️ for Windows enthusiasts**

[🔝 Back to Top](#-win11→10-ui-transformer---professional-windows-customization-tool)

</div>
