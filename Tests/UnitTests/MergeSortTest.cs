using System;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class MergeSortTest
{
    [Theory]
    [InlineData(2, 3, 4, 5, 6, 7, 8, 9, 1)]
    // [InlineData(1, 2, 3, 4, 5, 6, 7, 8, 9)]
    public void MergeSort_ShouldReturnSortedList_WithNumbers(params int[] values)
    {
        var expected = new int[]{1,2,3,4,5,6,7,8,9};
        var sut = new MergeSortStrategy();
        Assert.Equal(expected, sut.MergeSort(values));
    }
    
    
}