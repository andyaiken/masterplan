using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using MasterplanXP.MigrationTool.ViewModels;
using MasterplanXP.MigrationTool.Views;
using System.Linq;

namespace MasterplanXP.MigrationTool
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override async void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var splash = new SplashScreen();
                desktop.MainWindow = splash;
                splash.Show();

                // Wait for 3 seconds to show the logo
                await System.Threading.Tasks.Task.Delay(3000);

                var viewModel = new MainWindowViewModel();
                var mainWin = new MainWindow
                {
                    DataContext = viewModel,
                };

                desktop.MainWindow = mainWin;
                mainWin.Show();
                splash.Close();

                // Optional command-line argument: a folder to scan straight away, as if the user had
                // picked it with Browse. Masterplan M14 passes its Libraries folder (Convert button) or
                // the folder of an old file it could not open ("Convert now?"), so the old files are
                // already listed. Without an argument (or if the folder does not exist) the tool starts
                // exactly as before.
                string[]? args = desktop.Args;
                if (args != null && args.Length > 0 && System.IO.Directory.Exists(args[0]))
                    viewModel.ScanFolder(args[0]);
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}