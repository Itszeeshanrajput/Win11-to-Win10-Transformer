using System.Windows;
using Win10_Transformer.Core;
using System.Linq;
using Microsoft.Win32;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

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
            TweaksListView.ItemsSource = _tweakManager.Tweaks;

            ApplyButton.Click += ApplyButton_Click;
            RevertButton.Click += RevertButton_Click;
            CreateRestorePointButton.Click += CreateRestorePointButton_Click;
            RestartExplorerButton.Click += RestartExplorerButton_Click;
            SaveProfileButton.Click += SaveProfileButton_Click;
            LoadProfileButton.Click += LoadProfileButton_Click;

            Logger.Log("Application started.");
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
                Logger.Log($"Applied tweak: {tweak.Name}");
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
                Logger.Log($"Reverted tweak: {tweak.Name}");
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
                    TweaksListView.Items.Refresh();
                    Logger.Log($"Profile loaded from {dialog.FileName}");
                    MessageBox.Show("Profile loaded successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
