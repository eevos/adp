﻿using System;
using Algorithms.Algorithms;
using Xunit;

namespace Tests.UnitTests;

public class AdpDoublyLinkedList
{
    [Theory]
    //    [InlineData()] // Lege array?
    //    [InlineData("test","ninja")] // String array?
    [InlineData(1)]
    [InlineData(1, 2, 3)]
    [InlineData(11, -222, 100)]
    [InlineData(1, 2, 3, 11, -222, 100)]
    public void Count_AssertShouldReturnExpected_WithNumbers(params int[] values)
    {
        var expected = values.Length;
        var sut = new AdpDoublyLinkedList<int>(values);

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
    [InlineData(1, 2, 3)]
    [InlineData(1, 500, 3, 365)]
    [InlineData(1, -500, 3, -365)]
    public void Insert_Should_WhenItemInArray(params int[] values)
    {
        var actual = 999;
        var insertedInt = 4;
        var insertOnIndex = 1;
        var expected = insertedInt;
        var sut = new AdpDoublyLinkedList<int>(values);

        sut.Insert(insertOnIndex, insertedInt);
        if (sut.Contains(insertedInt))
        {
            actual = expected;
        }
        Assert.Equal(expected, actual);
    }
    // [Theory]
    // [InlineData(1,2,3)]
    // public void IndexOf_ShouldReturnIndex_WhenItemInArray(params int[] values)
    // {
    //    
    // }
}