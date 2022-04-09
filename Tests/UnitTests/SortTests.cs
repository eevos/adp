using System.Linq;

namespace Tests.UnitTests;

using System;
using System.Collections.Generic;
using Algorithms.Algorithms;
using DataSets;
using Xunit;

public class SortTests : TestHelper
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void MergeSort_ShouldReturnSortedList_WithIntList<T>(T[] values)
    {
        var sut = new MergeSortStrategy<T>();
        var expected = new List<T>(values);
        var actual = new List<T>(values);

        if (typeof(T).Name == "Object")
        {
            Assert.Throws<InvalidOperationException>(() => Array.Sort(values));
            return;
        }

        expected.Sort();

        Assert.Equal(expected, sut.MergeSort(actual));
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void QuickSort_ShouldReturnSortedList<T>(T[] values)
    {
        var sut = new QuickSortStrategy<T>();
        var expected = new List<T>(values);


        if (typeof(T).Name == "Object")
        {
            Assert.Throws<InvalidOperationException>(() => Array.Sort(expected.ToArray()));
            return;
        }

        if (values.Length < 1)
        {
            Assert.Throws<InvalidOperationException>(() => sut.QuickSort(values, 0, values.Length - 1));
            return;
        }

        if (typeof(T).Name == "Float8001" && !typeof(IComparable).IsAssignableFrom(typeof(T)))
        {
            return;
            // Assert.Throws<InvalidOperationException>(() => sut.QuickSort(values, 0, values.Length - 1));
        }

        Array.Sort(expected.ToArray());
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

        if (typeof(T).Name == "Object")
        {
            Assert.Throws<InvalidOperationException>(() => expected.Sort());
            return;
        }

        if (values == null || values.Length == 0 || values[0] == null)
        {
            Assert.Throws<Exception>(() =>
                insertionSortStrategy.RecursiveSortForLoop(values, values.Length));
        }
        else
        {
            var actual = insertionSortStrategy.RecursiveSortForLoop(values, values.Length);
            expected.Sort();
            
            Assert.Equal(expected, actual);
        }
    }
}