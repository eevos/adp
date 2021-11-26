using System;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpDoublyLinkedList
{
    // [Theory]
    // //    [InlineData()] // Lege array?
    // //    [InlineData("test","ninja")] // String array?
    //
    // [InlineData(1)]
    // [InlineData(1, 2, 3)]
    // [InlineData(11, -222, 100)]
    // [InlineData(1, 2, 3, 11, -222, 100)]
    // public void Count_AssertShouldReturnExpected_WithNumbers(params int[] values)
    // {
    //     var expected = values.Length;
    //     var sut = new AdpDoublyLinkedList<int>(values);
    //
    //     Assert.Equal(expected, sut.Count());
    // }    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Count_AssertShouldReturnExpected_WithNumbers<T>(T[] values)
    {
        var expected = values.Length;
        var sut = new AdpDoublyLinkedList<T>(values);

        Assert.Equal(expected, sut.Count());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1, 2, 3)]
    [InlineData(1, -200, 3)]
    public void Clear_WithOneOrMultipleItems(params int[] values)
    {
        var expected = 0;
        var sut = new AdpDoublyLinkedList<int>(values);
        sut.Clear();
        Assert.Equal(expected, sut.Count());
    }

    [Theory]
    [InlineData(2)]
    [InlineData(1, 2, 3)]
    [InlineData(1, 2, -3)]
    public void Contains_ShouldReturnTrue_WhenInArray(params int[] values)
    {
        var sut = new AdpDoublyLinkedList<int>(values);
        Assert.True(sut.Contains(2));
    }

    [Theory]
    [InlineData(1, 2, 3)]
    public void Contains_ShouldReturnFalse_WhenNotInArray(params int[] values)
    {
        var sut = new AdpDoublyLinkedList<int>(values);
        Assert.False(sut.Contains(-2));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1, 2, 3)]
    [InlineData(1, 2, -3)]
    public void Push_ShouldCountItems_WhenItemsInsertedInEmptyLinkedList(params int[] values)
    {
        var expected = values.Length;
        var sut = new AdpDoublyLinkedList<int>();

        sut.Push(values);

        Assert.Equal(expected, sut.Count());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1, 2, 3)]
    [InlineData(1, 2, -3)]
    public void Push_ShouldCountItems_WhenItemsInsertedInFilledLinkedList(params int[] values)
    {
        var firstArray = new[] {4, 5, 6};
        var sut = new AdpDoublyLinkedList<int>();
        var expected = (values.Length + firstArray.Length);

        sut.Push(firstArray);
        sut.Push(values);

        Assert.Equal(expected, sut.Count());
    }

    [Theory]
    [InlineData(new [] {1 , 2, 3}, 4, 1)]
    [InlineData(new [] {1 , 2, -365}, 5, 2)]
    public void Insert_Should_WhenItemInArray(int[] values, int insertedValue, int insertOnIndex)
    {
        var actual = 999;
        var expected = insertedValue;
        var sut = new AdpDoublyLinkedList<int>(values);

        sut.Insert(insertOnIndex, insertedValue);
        if (sut.Contains(insertedValue))
        {
            actual = expected;
        }
        Assert.Equal(expected, actual);
        Assert.True(sut.Contains(insertedValue));

    }
   
    // [Theory]
    // [InlineData(1,2,3)]
    // public void IndexOf_ShouldReturnIndex_WhenItemInArray(params int[] values)
    // {
    //    
    // }
}