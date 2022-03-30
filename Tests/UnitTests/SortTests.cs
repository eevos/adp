namespace Tests.UnitTests;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

public class SortTests
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void QuickSort_ShouldReturnSortedList<T>(T[] values)
    {
        var sut = new QuickSortStrategy<T>();

        var expected = values;
        if (typeof(T).Name == "Object")
        {
            Assert.Throws<InvalidOperationException>(() => Array.Sort(expected));
            return;
        }

        if (values.Length < 1)
        {
            Assert.Throws<InvalidOperationException>(() => sut.QuickSort(values, 0, values.Length - 1));
            return;
        }

        Array.Sort(expected);
        var actual = sut.QuickSort(values, 0, values.Length - 1);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void SelectionSort_ShouldReturnEqual<T>(T[] values)
    {
        var sut = new AdpSelectionSort<T>();
        if (typeof(T).Name == "Object")
        {
            Assert.Throws<InvalidOperationException>(() => Array.Sort(values));
            return;
        }

        var expected = new List<T>(values);
        expected.Sort();

        Assert.Equal(expected, sut.Sort(values));
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void InsertionSortRecursive_ShouldReturnSortedList<T>(T[] values)
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
    public void InsertionSortRecursiveForLoop_ShouldReturnSortedList<T>(T[] values)
    {
        var expected = new List<T>(values);

        var insertionSortStrategy = new InsertionSortStrategy<T>();
        var actual = insertionSortStrategy.RecursiveSortForLoop(values, values.Length);

        if (typeof(T).Name == "Object")
        {
            Assert.Throws<InvalidOperationException>(() => expected.Sort());
            return;
        }

        expected.Sort();

        Assert.Equal(expected, actual);
    }
}