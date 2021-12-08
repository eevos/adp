using Algorithms.DataStructures;
using Algorithms.DataStructures.Deprecated;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Benchmarks.Benchmarks;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class AdpDynamicArrayInsertBenchmarks
{
    private readonly int[] _baseArray;
    public AdpDynamicArrayInsertBenchmarks()
    {
        var baseArray = new int[100];
        for (int i = 0; i < baseArray.Length; i++)
        {
            baseArray[i] = i;
        }

        _baseArray = baseArray;
    }
    
    [Benchmark]
    public void InsertAdpDynamicArray()
    {
        var array = new AdpDynamicArray<int>(_baseArray);
        for (int i = 0; i < 100; i+=5)
        {
            array.Insert(i, i);
        }
    }
    
    [Benchmark]
    public void InsertAdpDynamicArrayStepSize1()
    {
        var array = new AdpDynamicArrayStepSize1<int>(_baseArray);
        for (int i = 0; i < 100; i+=5)
        {
            array.Insert(i, i);
        }
    }
    
    [Benchmark]
    public void InsertList()
    {
        var list = new List<int>(_baseArray);
        for (int i = 0; i < 100; i+=5)
        {
            list.Insert(i, i);
        }
    }
}