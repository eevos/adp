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
    public void RecursiveInsertionSort_ShouldReturnSortedList<T>(T[] values)
    {
        var expected = values;
        if (typeof(T).Name == "Object")
        {
            Assert.Throws<InvalidOperationException>(() => Array.Sort(expected));
            return;
        }
        Array.Sort(expected);
        
        var insertionSortStrategy = new InsertionSortStrategy<T>();
        var actual = insertionSortStrategy.RecursiveSort(values, values.Length);

        Assert.Equal(expected, actual);
    }
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void RecursiveInsertionSortForLoop_ShouldReturnSortedList<T>(T[] values)
    {
        var expected = values;
        var actual = values;
        var insertionSortStrategy = new InsertionSortStrategy<T>();
        actual = insertionSortStrategy.RecursiveSortForLoop(actual, actual.Length);

        
        if (typeof(T).Name == "Object")
        {
            Assert.Throws<InvalidOperationException>(() => Array.Sort(expected));
            return;
        }
        Array.Sort(expected);
        
        // var insertionSortStrategy = new InsertionSortStrategy<T>();
        // actual = insertionSortStrategy.RecursiveSortForLoop(actual, actual.Length);

        Assert.Equal(expected, actual);
    }
}
