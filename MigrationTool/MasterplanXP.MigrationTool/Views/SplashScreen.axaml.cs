using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MasterplanXP.MigrationTool.Views
{
    public partial class SplashScreen : Window
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
