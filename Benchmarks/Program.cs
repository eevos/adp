using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks;

namespace Benchmarks;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<AdpDynamicArrayBenchmarks>( ManualConfig
                .Create(DefaultConfig.Instance)
                .WithOptions(ConfigOptions.DontOverwriteResults ));
    }
}