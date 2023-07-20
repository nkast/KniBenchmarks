using System;

namespace Benchmarks
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (BenchmarksGame game = new BenchmarksGame())
            {
                game.Run();
            }
        }
    }
}

