using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Benchmarks
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        readonly BenchmarksGame _game;

        public MainWindow() : base()
        {
            this.InitializeComponent();

            // Create the game.
            string launchArguments = String.Empty;
            AppWindow appWindow = AppWindow.Create();
            var window = this;
            //var coreWindow = Window.Current.CoreWindow;
           _game = MonoGame.Framework.XamlGame<BenchmarksGame>.Create(launchArguments, appWindow, window, this.swapChainPanel);

        }
    }
}
