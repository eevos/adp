using Algorithms;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarks.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class AdpDynamicArrayBenchmarks
{
    [Benchmark]
    public void Add()
    {
        var array = new AdpDynamicArray<int>();
        for (int i = 0; i < 1000; i++)
        {
            array.Add(i);
        }
    }
    
}