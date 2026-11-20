using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using Avalonia.Input;
using MasterplanXP.MigrationTool.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace MasterplanXP.MigrationTool.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Add the version to the title (set here rather than in MainWindow.axaml, where it would
            // have to be typed in by hand and could go out of date). See Program.VersionText.
            Title = $"MasterplanXP Migration Tool {Program.VersionText}";
        }

        /// <summary>
        /// Handles the click event for the Browse button.
        /// Opens a folder picker dialog and updates the ViewModel.
        /// </summary>
        private async void OnBrowseClick(object sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel == null) return;

            // Open folder picker
            var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                Title = "Select Folder containing Masterplan files",
                AllowMultiple = false
            });

            if (folders.Count > 0)
            {
                var folderPath = folders[0].Path.LocalPath;
                if (DataContext is MainWindowViewModel vm)
                {
                    vm.ScanFolder(folderPath);
                }
            }
        }

        /// <summary>
        /// Handles double-click in the Available list.
        /// </summary>
        private void OnAvailableDoubleTapped(object sender, TappedEventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem is string selectedItem)
            {
                if (DataContext is MainWindowViewModel vm)
                {
                    vm.AddFileCommand.Execute(new List<string> { selectedItem });
                }
            }
        }

        /// <summary>
        /// Handles double-click in the Staged list.
        /// </summary>
        private void OnStagedDoubleTapped(object sender, TappedEventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem is string selectedItem)
            {
                if (DataContext is MainWindowViewModel vm)
                {
                    vm.RemoveFileCommand.Execute(new List<string> { selectedItem });
                }
            }
        }
    }
}