namespace Tests.UnitTests;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

public class InsertionSortTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void InsertionSort_ShouldReturnSortedList_WithIntArray<T>(T[] values)
    {
        var sut = new InsertionSortStrategy<T>();
    
        var expected = values;
        Array.Sort(expected);
        var actual = sut.InsertionSort(values);
        Assert.Equal(expected, actual);
    }
}
