using Algorithms.DataStructures;
using Algorithms.DataStructures.Deprecated;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarks.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class AdpDynamicArrayAddBenchmarks
{
    [Benchmark]
    public void AddToAdpDynamicArray()
    {
        var array = new AdpDynamicArray<int>();
        for (int i = 0; i < 100; i++)
        {
            array.Add(i);
        }
    }
    
    [Benchmark]
    public void AddToAdpDynamicArrayStepSize1()
    {
        var array = new AdpDynamicArrayStepSize1<int>();
        for (int i = 0; i < 100; i++)
        {
            array.Add(i);
        }
    }

    [Benchmark]
    public void AddToList()
    {
        var array = new List<int>();
        for (int i = 0; i < 100; i++)
        {
            array.Add(i);
        }
    }
}