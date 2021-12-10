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
    [InlineData(2, 3, 4, 5, 6, 7, 8, 9, 1)]
    public void QuickSort_ShouldReturnSortedList_WithIntArray(params int[] values)
    {
        var expected = values;
        var sut = new QuickSortStrategy();
        Array.Sort(expected);
        Assert.Equal(expected, sut.QuickSort(values));
    }
}