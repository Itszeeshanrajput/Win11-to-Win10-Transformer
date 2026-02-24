using System;
using System.Windows;
using Win10_Transformer.Core;
using System.Linq;
using System.Reflection;
using Microsoft.Win32;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Data;
using System.ComponentModel;

namespace Win10_Transformer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TweakManager _tweakManager;

        public MainWindow()
        {
            InitializeComponent();
            _tweakManager = new TweakManager();

            // Set up the grouped view
            var view = new ListCollectionView(_tweakManager.Tweaks);
            view.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            TweaksListView.ItemsSource = view;

            Loaded += MainWindow_Loaded;

            ApplyButton.Click += ApplyButton_Click;
            RevertButton.Click += RevertButton_Click;
            CreateRestorePointButton.Click += CreateRestorePointButton_Click;
            RestartExplorerButton.Click += RestartExplorerButton_Click;
            SaveProfileButton.Click += SaveProfileButton_Click;
            LoadProfileButton.Click += LoadProfileButton_Click;
            SelectAllButton.Click += SelectAllButton_Click;
            DeselectAllButton.Click += DeselectAllButton_Click;

            Logger.Log("Application started.");
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await CheckForUpdates();
        }

        private async Task CheckForUpdates()
        {
            Logger.Log("Checking for updates.");
            var updateResult = await UpdateChecker.CheckForUpdatesAsync();
            if (updateResult.IsUpdateAvailable)
            {
                var message = $"A new version ({updateResult.LatestVersion}) is available! Would you like to go to the download page?";
                var result = MessageBox.Show(message, "Update Available", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (result == MessageBoxResult.Yes)
                {
                    var metadata = System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes<System.Reflection.AssemblyMetadataAttribute>();
                    var repoUrl = metadata.FirstOrDefault(m => m.Key == "RepositoryUrl")?.Value ?? "https://github.com/your-username/your-repo";

                    try
                    {
                        Process.Start(new ProcessStartInfo($"{repoUrl}/releases/latest") { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($"Error opening update URL: {ex.Message}");
                    }
                }
            }
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedTweaks = _tweakManager.Tweaks.Where(t => t.IsApplied).ToList();
            if (selectedTweaks.Count == 0)
            {
                MessageBox.Show("Please select at least one tweak to apply.", "No Tweaks Selected", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            foreach (var tweak in selectedTweaks)
            {
                tweak.Apply();
                tweak.RefreshStatus();
            }

            MessageBox.Show($"{selectedTweaks.Count} tweak(s) applied successfully. A restart of Explorer or the system may be required.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RevertButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedTweaks = _tweakManager.Tweaks.Where(t => t.IsApplied).ToList();
             if (selectedTweaks.Count == 0)
            {
                MessageBox.Show("Please select at least one tweak to revert.", "No Tweaks Selected", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            foreach (var tweak in selectedTweaks)
            {
                tweak.Revert();
                tweak.RefreshStatus();
            }

            MessageBox.Show($"{selectedTweaks.Count} tweak(s) reverted successfully. A restart of Explorer or the system may be required.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CreateRestorePointButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("This will create a system restore point. This requires administrator privileges. Continue?", "Create Restore Point", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Logger.Log("Creating restore point.");
                RegistryManager.CreateRestorePoint();
                MessageBox.Show("Restore point created successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Logger.Log("Restore point created.");
            }
        }

        private void RestartExplorerButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("This will restart Windows Explorer. Unsaved work in Explorer windows may be lost. Continue?", "Restart Explorer", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Logger.Log("Restarting Explorer.");
                RegistryManager.RestartExplorer();
            }
        }

        private void SaveProfileButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                Title = "Save Tweak Profile"
            };

            if (dialog.ShowDialog() == true)
            {
                var selectedTweakNames = _tweakManager.Tweaks.Where(t => t.IsApplied).Select(t => t.Name).ToList();
                var json = JsonSerializer.Serialize(selectedTweakNames, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(dialog.FileName, json);
                Logger.Log($"Profile saved to {dialog.FileName}");
                MessageBox.Show("Profile saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void LoadProfileButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                Title = "Load Tweak Profile"
            };

            if (dialog.ShowDialog() == true)
            {
                var json = File.ReadAllText(dialog.FileName);
                var selectedTweakNames = JsonSerializer.Deserialize<List<string>>(json);

                if (selectedTweakNames != null)
                {
                    foreach (var tweak in _tweakManager.Tweaks)
                    {
                        tweak.IsApplied = selectedTweakNames.Contains(tweak.Name);
                    }
                    (TweaksListView.ItemsSource as ICollectionView)?.Refresh();
                    Logger.Log($"Profile loaded from {dialog.FileName}");
                    MessageBox.Show("Profile loaded successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void SelectAllButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var tweak in _tweakManager.Tweaks)
            {
                tweak.IsApplied = true;
            }
        }

        private void DeselectAllButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var tweak in _tweakManager.Tweaks)
            {
                tweak.IsApplied = false;
            }
        }
    }
}
