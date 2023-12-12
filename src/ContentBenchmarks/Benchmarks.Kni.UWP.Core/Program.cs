using System;

namespace Benchmarks
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Windows.ApplicationModel.Core.IFrameworkViewSource viewProviderFactory = new MonoGame.Framework.GameFrameworkViewSource<BenchmarksGame>();
            Windows.ApplicationModel.Core.CoreApplication.Run(viewProviderFactory);
        }
    }
}
