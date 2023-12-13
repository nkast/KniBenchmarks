using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Benchmarks
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        readonly BenchmarksGame _game;

        public MainPage()
        {
            this.InitializeComponent();

            // Create the game.
            string launchArguments = String.Empty;
            _game = MonoGame.Framework.XamlGame<BenchmarksGame>.Create(launchArguments, App.Window.CoreWindow, swapChainPanel);
        }
    }
}
