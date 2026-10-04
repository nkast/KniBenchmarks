using System;

namespace Benchmarks
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Math benchmarks");
            MathBenchmarks.RunAll();
        }
    }
}
