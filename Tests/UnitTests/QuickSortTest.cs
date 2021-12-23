using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class QuickSortTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void QuickSort_ShouldReturnSortedList_WithIntArray<T>(T[] values)
    {
        var sut = new QuickSortStrategy<T>();

        var expected = values;
        Array.Sort(expected);
        var actual = sut.QuickSort(values, 0, values.Length - 1);
        Assert.Equal(expected, actual);
    }
}



