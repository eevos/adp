using System.Diagnostics.CodeAnalysis;
using Algorithms;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarks.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class AdpDynamicArrayRemoveBenchmarks
{
    private readonly int[] _baseArray;
    public AdpDynamicArrayRemoveBenchmarks()
    {
        var baseArray = new int[100];
        for (int i = 0; i < baseArray.Length; i++)
        {
            baseArray[i] = i;
        }

        _baseArray = baseArray;
    }
    
    
    [Benchmark]
    public void RemoveFromAdpDynamicArray()
    {
        var array = new AdpDynamicArray<int>(_baseArray);
        for (int i = 0; i < 100; i++)
        {
            array.Remove(i);
        }
    }
    
    [Benchmark]
    public void RemoveFromAdpDynamicArrayStepSize1()
    {
        var array = new AdpDynamicArrayStepSize1<int>(_baseArray);
        for (int i = 0; i < 100; i++)
        {
            array.Remove(i);
        }
    }
    
    [Benchmark]
    public void RemoveFromList()
    {
        var array = new List<int>(_baseArray);
        for (int i = 0; i < 100; i++)
        {
            array.Remove(i);
        }
    }
}