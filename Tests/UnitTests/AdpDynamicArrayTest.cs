using System;
using System.Data;
using Algorithms;
using Algorithms.Interfaces;
using Tests.DataSets;
using Xunit;
using Xunit.Abstractions;

namespace Tests.UnitTests;

public class AdpDynamicArrayTest : IClassFixture<DataSetLoader<DsSortDto>>
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly DsSortDto _dataSet;

    public AdpDynamicArrayTest(ITestOutputHelper testOutputHelper, DataSetLoader<DsSortDto> dataSetLoader)
    {
        _testOutputHelper = testOutputHelper;
        _dataSet = dataSetLoader.DataSet;
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Push_CheckIfItemsAreEqual_WhenMultipleItemsArePushed<T>(T[] values)
    {
        var sut = new AdpDynamicArray<T>();

        foreach (var value in values)
        {
            sut.Push(value);
        }

        Assert.Equal(values, sut.ToArray());
    }


    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Pop_CheckCountMinus1_WhenLastItemIsRemoved<T>(T[] values)
    {
        var sut = new AdpDynamicArray<T>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        if (values.Length == 0)
        {
            Assert.Throws<IndexOutOfRangeException>(() => sut.Pop());
            return;
        }

        sut.Pop();
        Assert.Equal(values.Length - 1, sut.Count());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Pop_CheckLastItemIsReturned(params object[] values)
    {
        var sut = new AdpDynamicArray<object>();
        foreach (var value in values)
        {
            sut.Push(value);
        }
        
        if (values.Length == 0)
        {
            Assert.Throws<IndexOutOfRangeException>(() => sut.Pop());
            return;
        }
    
        Assert.Equal(values[^1], sut.Pop());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Clear_ShouldBeEmpty_WhenCleared<T>(T[] values)
    {
        var sut = new AdpDynamicArray<T>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        sut.Clear();
        Assert.Equal(0, sut.Count());
    }

    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Contains_ShouldReturnTrue_WhenItemIsInArray(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        Assert.True(sut.Contains("hello"));
    }

    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Contains_ShouldReturnFalse_WhenItemIsNotInArray(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        Assert.False(sut.Contains("hello2"));
    }

    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Insert_ShouldInsertItem_WhenItemIsInserted(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        sut.Insert(2, "hello2");
        Assert.Equal("hello2", sut[2]);
    }

    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Insert_ShouldNotAffectOtherItems_WhenItemIsInserted(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        sut.Insert(2, "hello2");
        Assert.True(sut.Contains(values[0]) && sut.Contains(values[^1]));
    }


    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Remove_ShouldReturnTrue_WhenItemIsInArray(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        Assert.True(sut.Remove("hello"));
    }

    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Remove_ShouldRemoveItem_WhenItemIsInArray(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        sut.Remove("hello");
        Assert.False(sut.Contains("hello"));
    }

    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Remove_CheckCountMinus1_WhenItemIsRemoved(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        sut.Remove("hello");
        Assert.Equal(values.Length - 1, sut.Count());
    }

    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Remove_ShouldNotEffectOtherItems_WhenItemIsRemoved(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        sut.Remove(values[^2]);
        Assert.True(sut.Contains(values[0]) && sut.Contains(values[^1]));
    }

    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void RemoveAt_ShouldReturnTrue_WhenIndexIsInArray(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        Assert.True(sut.RemoveAt(2));
    }

    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void RemoveAt_ShouldRemoveItem_WhenIndexIsInArray(params string[] values)
    {
        Int64 index = 2;
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        sut.RemoveAt(2);
        Assert.False(sut.Contains(values[2]));
    }
}