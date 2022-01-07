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
        var expected = values;
        
        if (typeof(T).Name == "Object")
        {
            Assert.Throws<InvalidOperationException>(() => Array.Sort(expected));
            return;
        }
        var sut = new InsertionSortStrategy<T>();
        
        Array.Sort(expected);
        var actual = sut.InsertionSort(values, values.Length);
        Assert.Equal(expected, actual);
    }
}
