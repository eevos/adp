using System;
using System.Collections.Generic;
using Implementations.Algorithms;
using Implementations.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpSortTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Sort_AdpInsertionSort_Test<T>(T[] values)
    {
        var list = new List<T>(values);
        
        // check if T is object
        if (typeof(T).Name == "Object" && !typeof(IComparable).IsAssignableFrom(typeof(T)))
        {
            Assert.Throws<InvalidOperationException>(() => AdpInsertionSort<T>.Sort(values));
            return;
        }
        
        list.Sort();

        AdpInsertionSort<T>.Sort(values);
        Assert.Equal(list.ToArray(), values);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Sort_AdpSelectionSort_Test<T>(T[] values)
    {
        var list = new List<T>(values);

        if (typeof(T).Name == "Object" && !typeof(IComparable).IsAssignableFrom(typeof(T)))
        {
            Assert.Throws<InvalidOperationException>(() => AdpSelectionSort<T>.Sort(values));
            return;
        }

        list.Sort();

        AdpSelectionSort<T>.Sort(values);
        Assert.Equal(list.ToArray(), values);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Sort_AdpQuickSort_Test<T>(T[] values)
    {
        var list = new List<T>(values);

        if (CanDataBeCompared<T>())
        {
            Assert.Throws<InvalidOperationException>(() => AdpQuickSort<T>.Sort(values, 0, values.Length - 1));
            return;
        }

        list.Sort();

        AdpQuickSort<T>.Sort(values, 0, values.Length - 1);
        Assert.Equal(list.ToArray(), values);
    }

    

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Sort_AdpMergeSort_Test<T>(T[] values)
    {
        var list = new List<T>(values);

        if (CanDataBeCompared<T>())        {
            Assert.Throws<InvalidOperationException>(() => AdpMergeSort<T>.Sort(values, 0, values.Length - 1));
            return;
        }

        list.Sort();

        AdpMergeSort<T>.Sort(values, 0, values.Length - 1);
        Assert.Equal(list.ToArray(), values);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Sort_AdpParallelMergeSort_Test<T>(T[] values)
    {
        var list = new List<T>(values);

        if (CanDataBeCompared<T>())        {
            Assert.Throws<InvalidOperationException>(() => AdpParallelMergeSort<T>.Sort(values, 0, values.Length - 1));
            return;
        }

        list.Sort();

        AdpParallelMergeSort<T>.Sort(values, 0, values.Length - 1);
        Assert.Equal(list.ToArray(), values);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsIntSortDto>))]
    public void Sort_AdpRadixSort_Test(int[] values)
    {
        var list = new List<int>(values);

        list.Sort();

        AdpRadixSort<int>.Sort(values);
        Assert.Equal(list.ToArray(), values);
    }
    
    private static bool CanDataBeCompared<T>()
    {
        return typeof(T).Name == "Object" && !typeof(IComparable).IsAssignableFrom(typeof(T));
    }
}