using System;
using System.Collections.Generic;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class MergeSortTest
{
    [Theory]
    [InlineData(2, 3, 4, 5, 6, 7, 8, 9, 1)]
    public void MergeSort_ShouldReturnSortedList_WithIntArray(params int[] values)
    {
        var expected = new int[]{1,2,3,4,5,6,7,8,9};
        var sut = new MergeSortStrategy();
        Assert.Equal(expected, sut.MergeSort(values));
    }
    // [Theory]
    // [MemberData(nameof(List<int>),2, 3, 4, 5, 6, 7, 8, 9, 1)]
    // // [InlineData(1, 2, 3, 4, 5, 6, 7, 8, 9)]
    // public void MergeSort_ShouldReturnSortedList_WithIntList(List<int> values)
    // {   
    //     var valuesList = new List<int> {2, 3, 4, 5, 6, 7, 8, 9, 1};
    //     var expected = new List<int>{1,2,3,4,5,6,7,8,9};
    //     var sut = new MergeSortStrategy();
    //     Assert.Equal(expected, sut.MergeSort(valuesList));
    // }
    
}