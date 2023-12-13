using Windows.UI.Xaml.Controls;

namespace Benchmarks
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //
            //var swapChainPanel = new Microsoft.UI.Xaml.Controls.SwapChainPanel();
            Microsoft.UI
            var swapChainPanel = new SwapChainPanel();

            MainPage = new AppShell();
        }
    }
}
