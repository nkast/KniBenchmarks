namespace Benchmarks
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Create the game.
            string launchArguments = String.Empty;
            //_game = MonoGame.Framework.XamlGame<BenchmarksGame>.Create(launchArguments, Window.Current.CoreWindow, swapChainPanel);
        }
    }

}
