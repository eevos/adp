using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks;

namespace Benchmarks;

class Program
{
    static void Main(string[] args)
    {
        // BenchmarkRunner.Run<AdpDynamicArrayAddBenchmarks>
        // ( ManualConfig
        //         .Create(DefaultConfig.Instance)
        //         .WithOptions(ConfigOptions.DontOverwriteResults ));
        
        BenchmarkRunner.Run<AdpDynamicArrayRemoveBenchmarks>
        ( ManualConfig
            .Create(DefaultConfig.Instance)
            .WithOptions(ConfigOptions.DontOverwriteResults ));
        
        // BenchmarkRunner.Run<AdpDynamicArrayInsertBenchmarks>
        // ( ManualConfig
        //     .Create(DefaultConfig.Instance)
        //     .WithOptions(ConfigOptions.DontOverwriteResults ));
    }
}