using System.Collections.Generic;
using System.Linq;
using Implementations.DataSets;
using Implementations.DataStructures;
using Tests.DataSets;
using Xunit;
using Xunit.Abstractions;

namespace Tests.UnitTests;

public class AdpDynamicArrayTest : BaseListTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public AdpDynamicArrayTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Push_CheckIfItemsAreEqual_WhenMultipleItemsArePushed<T>(T[] values)
    {
        var sut = new AdpDynamicArray<T>();

        foreach (var value in values) sut.Add(value);

        Assert.Equal(values, sut.ToArray());
    }


    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Pop_CheckCountMinus1_WhenLastItemIsRemoved<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDynamicArray<T> { values.ToArray() };

        sut.Pop();
        Assert.Equal(values.Length - 1, sut.Count());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Pop_CheckLastItemIsReturned<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDynamicArray<T> { values.ToArray() };
        Assert.Equal(values[^1], sut.Pop());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Clear_ShouldBeEmpty_WhenCleared<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDynamicArray<T> { values.ToArray() };

        sut.Clear();
        Assert.Equal(0, sut.Count());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Contains_ShouldReturnTrue_WhenItemIsInArray<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDynamicArray<T> { values.ToArray() };

        Assert.True(sut.Contains(values[^1]));
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Contains_ShouldReturnFalse_WhenItemIsNotInArray<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDynamicArray<T> { values.ToArray() };
        Assert.False(sut.Contains(GetValueForType<T>()));
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Insert_ShouldInsertItem_WhenItemIsInserted<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDynamicArray<T> { values.ToArray() };

        var value = GetValueForType<T>();
        sut.Insert(1, value);
        Assert.Equal(value, sut[1]);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Insert_ShouldNotAffectOtherItems_WhenItemIsInserted<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDynamicArray<T> { values.ToArray() };

        var value = GetValueForType<T>();
        sut.Insert(1, value);
        Assert.True(sut.Contains(values[0]) && sut.Contains(values[^1]));
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Insert_ShouldAdd1ToCount_WhenItemIsInserted<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDynamicArray<T> { values.ToArray() };

        var value = GetValueForType<T>();
        sut.Insert(1, value);
        Assert.Equal(values.Length + 1, sut.Count());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Remove_ShouldReturnTrue_WhenItemIsInArray<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDynamicArray<T> { values.ToArray() };

        Assert.True(sut.Remove(values[^1]));
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Remove_ShouldRemoveItem_WhenItemIsInArray<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDynamicArray<T> { values.ToArray() };

        var value = GetValueForType<T>();
        sut.Insert(0, value);

        sut.Remove(value);
        Assert.False(sut.Contains(value));
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Remove_CheckCountMinus1_WhenItemIsRemoved<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDynamicArray<T> { values.ToArray() };

        sut.Remove(values[^1]);
        Assert.Equal(values.Length - 1, sut.Count());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Remove_ShouldNotEffectOtherItems_WhenItemIsRemoved<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDynamicArray<T> { values.ToArray() };

        var value = GetValueForType<T>();
        sut.Insert(1, value);
        sut.Remove(value);

        Assert.Equal(sut.ToArray(), values);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void RemoveAt_ShouldReturnTrue_WhenIndexIsInArray<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDynamicArray<T> { values.ToArray() };

        Assert.True(sut.RemoveAt(0));
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void RemoveAt_ShouldRemoveItem_WhenIndexIsInArray<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDynamicArray<T> { values.ToArray() };

        var value = GetValueForType<T>();
        sut.Insert(0, value);

        sut.RemoveAt(0);
        Assert.False(sut.Contains(value));
    }
}