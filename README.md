# Win10-Transformer: The Ultimate Windows 11 Customization Tool

![App Screenshot](https://i.imgur.com/your-screenshot.png) <!-- Placeholder -->

**Win10-Transformer** is a modern, user-friendly application for customizing the Windows 11 user interface to look and feel more like Windows 10. Built with WPF, it provides a simple and powerful way to apply and manage over 40 different tweaks to your system.

## ✨ Features

- **Modern GUI:** An intuitive and easy-to-use interface built with WPF.
- **Selective Tweaks:** Choose exactly which tweaks you want to apply from a categorized list.
- **Detailed Descriptions:** Each tweak comes with a clear explanation of what it does.
- **Profiles:** Save your favorite sets of tweaks as profiles and load them at any time.
- **Safety First:** Easily create a system restore point before making any changes.
- **Full Reversibility:** Revert any applied tweak, either individually or all at once.
- **Logging:** All actions are logged to a file for easy troubleshooting.
- **Explorer Restart:** A dedicated button to restart Windows Explorer and apply changes that require it.

## 🚀 Getting Started

1.  Go to the [Releases page](https://github.com/your-username/your-repo/releases).
2.  Download the latest `Win10-Transformer.zip` file.
3.  Extract the archive to a folder of your choice.
4.  Run `Win10-Transformer.exe`.

**Note:** The application requires administrator privileges to modify registry settings and create restore points.

## 📖 How to Use

1.  **Select Tweaks:** Check the boxes next to the tweaks you want to apply.
2.  **Apply:** Click the "Apply Selected" button to apply the chosen tweaks.
3.  **Revert:** To undo a tweak, select it and click "Revert Selected".
4.  **Profiles:**
    -   **Save:** Click "Save Profile" to save your current selection of tweaks.
    -   **Load:** Click "Load Profile" to load a previously saved profile.
5.  **Restore Point:** It is highly recommended to click "Create Restore Point" before applying tweaks for the first time.

## 🛠️ Building from Source

To build the application from source, you will need:

-   [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
-   Visual Studio 2022 (or another IDE that supports .NET 7)

```bash
# Clone the repository
git clone https://github.com/Itszeeshanrajput/Win11-to-Win10-Transformer.git
cd Win11-to-Win10-Transformer/src

# Build the project
dotnet build --configuration Release

# The executable will be in ./Win10-Transformer/bin/Release/net7.0-windows/
```

##🤝 Contributing

Contributions are welcome! Please see the [CONTRIBUTING.md](CONTRIBUTING.md) file for guidelines.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
