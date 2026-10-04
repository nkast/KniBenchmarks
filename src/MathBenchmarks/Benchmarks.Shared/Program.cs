using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace Benchmarks
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            // In-process toolchain: the projects use a shared project and a local FNA.dll,
            // which BenchmarkDotNet's generated child project cannot reference.
            var config = DefaultConfig.Instance
                .AddJob(Job.Default.WithToolchain(InProcessNoEmitToolchain.Instance))
                .WithOptions(ConfigOptions.DisableOptimizationsValidator);

            BenchmarkSwitcher.FromAssembly(typeof(MathBenchmarks).Assembly).Run(args, config);
        }
    }
}
