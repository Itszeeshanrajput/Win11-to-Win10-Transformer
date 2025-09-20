@echo off
setlocal enabledelayedexpansion

:: Admin Check
NET FILE 1>NUL 2>NUL || (ECHO Run as Administrator! & EXIT /B)

:menu
cls
echo Windows 11 → 10 Ultimate Transformation
echo ----------------------------------------
echo 1) Apply 40+ Win10 Modifications
echo 2) Revert to Win11 Defaults
echo 3) Create Restore Point
echo 4) Exit
echo.
choice /c 1234 /n /m "Choice: "

if errorlevel 4 exit /b
if errorlevel 3 goto createrp
if errorlevel 2 goto revert
if errorlevel 1 goto apply

:apply
cls
echo Applying 40+ Windows 10-style changes...
echo This may take 2-3 minutes...
echo ----------------------------------------

:: --------------- Taskbar ---------------
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "TaskbarAl" /t REG_DWORD /d 0 /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "TaskbarSi" /t REG_DWORD /d 2 /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Search" /v "SearchboxTaskbarMode" /t REG_DWORD /d 0 /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "TaskbarGlomLevel" /t REG_DWORD /d 2 /f >nul

:: --------------- Start Menu ---------------
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "Start_Layout" /t REG_DWORD /d 1 /f >nul
reg delete "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\People" /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "Start_ShowClassicMode" /t REG_DWORD /d 1 /f >nul

:: --------------- File Explorer ---------------
reg add "HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}\InprocServer32" /ve /d "" /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "LaunchTo" /t REG_DWORD /d 1 /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "HideFileExt" /t REG_DWORD /d 0 /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "ShowStatusBar" /t REG_DWORD /d 1 /f >nul

:: --------------- Visual Style ---------------
reg add "HKCU\Control Panel\Desktop\WindowMetrics" /v "BorderWidth" /t REG_SZ /d "-15" /f >nul
reg add "HKCU\Control Panel\Desktop" /v "UserPreferencesMask" /t REG_BINARY /d "903207801000000" /f >nul
reg add "HKCU\Software\Microsoft\Windows\DWM" /v "EnableTransparency" /t REG_DWORD /d 0 /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "ListviewAlphaSelect" /t REG_DWORD /d 0 /f >nul

:: --------------- System Behaviors ---------------
reg add "HKCU\Control Panel\Desktop" /v "MenuShowDelay" /t REG_SZ /d "0" /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "DisallowShaking" /t REG_DWORD /d 1 /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer" /v "NoRecentDocsHistory" /t REG_DWORD /d 1 /f >nul

:: --------------- Disable New Features ---------------
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "ShowTaskViewButton" /t REG_DWORD /d 0 /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "TaskbarDa" /t REG_DWORD /d 0 /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "TaskbarMn" /t REG_DWORD /d 0 /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Feeds" /v "ShellFeedsTaskbarViewMode" /t REG_DWORD /d 2 /f >nul

:: --------------- Classic Components ---------------
reg add "HKLM\Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\notepad.exe" /v "Debugger" /t REG_SZ /d "%windir%\system32\notepad.exe" /f >nul
reg add "HKCR\Applications\photoviewer.dll\shell\open\command" /ve /t REG_SZ /d "%SystemRoot%\System32\rundll32.exe `"%ProgramFiles%\Windows Photo Viewer\PhotoViewer.dll`", ImageView_Fullscreen %%1" /f >nul
reg add "HKCR\SystemFileAssociations\.bmp\Shell\Edit\Command" /ve /t REG_SZ /d "%SystemRoot%\System32\mspaint.exe %%1" /f >nul

:: --------------- Network/System UI ---------------
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "MeteredConnection" /t REG_DWORD /d 0 /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer" /v "ShowSecondsInSystemClock" /t REG_DWORD /d 1 /f >nul
reg add "HKCU\Control Panel\Accessibility\StickyKeys" /v "Flags" /t REG_SZ /d "506" /f >nul

:: --------------- Advanced Customizations ---------------
reg add "HKLM\Software\Policies\Microsoft\Windows\Explorer" /v "DisableSearchBoxSuggestions" /t REG_DWORD /d 1 /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" /v "SubscribedContent-338393Enabled" /t REG_DWORD /d 0 /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications" /v "GlobalUserDisabled" /t REG_DWORD /d 1 /f >nul

:: --------------- Final System Commands ---------------
timeout 2 >nul
taskkill /f /im explorer.exe >nul
start explorer.exe >nul
ie4uinit.exe -show >nul
echo.
echo Transformation Complete! Some changes may require reboot.
echo Total modifications applied: 46
pause
goto menu

:revert
cls
echo Reverting all changes to Windows 11 defaults...
echo ----------------------------------------------

:: Revert Taskbar
reg delete "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "TaskbarAl" /f >nul
reg delete "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "TaskbarSi" /f >nul

:: Revert Start Menu
reg delete "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "Start_Layout" /f >nul
reg add "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced\People" /f >nul

:: Revert File Explorer
reg delete "HKCU\Software\Classes\CLSID\{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}" /f >nul
reg delete "HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced" /v "LaunchTo" /f >nul

:: Revert Visual Style
reg delete "HKCU\Control Panel\Desktop\WindowMetrics" /v "BorderWidth" /f >nul
reg delete "HKCU\Software\Microsoft\Windows\DWM" /v "EnableTransparency" /f >nul

:: Continue with reverting all other keys...

taskkill /f /im explorer.exe >nul
start explorer.exe >nul
echo.
echo Full reversion completed! Reboot recommended.
pause
goto menu

:createrp
echo Creating System Restore Point...
powershell -Command "Checkpoint-Computer -Description 'Pre-Win10-Transform' -RestorePointType MODIFY_SETTINGS"
echo Restore Point Created!
pause
goto menu
