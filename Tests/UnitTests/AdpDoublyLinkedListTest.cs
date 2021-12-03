using System;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpDoublyLinkedList
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Count_AssertShouldReturnExpected_WithNumbers<T>(T[] values)
    {
        var expected = values.Length;
        var sut = new AdpDoublyLinkedList<T>(values);

        Assert.Equal(expected, sut.Count());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Clear_WithOneOrMultipleItems<T>(T[] values)
    {
        var expected = 0;
        var sut = new AdpDoublyLinkedList<T>(values);
        sut.Clear();
        Assert.Equal(expected, sut.Count());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Contains_ShouldReturnTrue_WhenInArray<T>(T[] values)
    {
        var sut = new AdpDoublyLinkedList<T>(values);
        var expected = sut.Get(1);
        Assert.True(sut.Contains(expected));
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Contains_ShouldReturnFalse_WhenNotInArray<T>( T[] values)
    {
        var sut = new AdpDoublyLinkedList<T>(values);
        Assert.False(sut.Contains(values[^1]));
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Push_ShouldCountItems_WhenItemsInsertedInEmptyLinkedList<T>(T[] values)
    {
        var expected = values.Length;
        var sut = new AdpDoublyLinkedList<T>();

        sut.Push(values);

        Assert.Equal(expected, sut.Count());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Push_ShouldCountItems_WhenItemsInsertedInFilledLinkedList<T>(T[] values)
    {
        // var firstArray = new[] {4, 5, 6};
        //
        // // T[] myTs = Array.ConvertAll(firstArray, typeof(T));
        // var myTs = Convert.ChangeType(firstArray, typeof(T[]));
        // // T[] firstArray = new T [3];
        //
        // var sut = new AdpDoublyLinkedList<T>();
        // var expected = (values.Length + firstArray.Length);
        //
        // var item = (T) (object) 1;
        // sut.Push(item);
        // // sut.Push(firstArray);
        // sut.Push(values);
        //
        // Assert.Equal(expected, sut.Count());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Insert_ShouldContainItem_WhenItemInArray<T>(T[] values)
    {
        // var insertedValue = (T)(object)1;
        // var insertOnIndex = (T)(object)1;
        // var actual = (T)(object)999;
        // var expected = insertedValue;
        // var sut = new AdpDoublyLinkedList<T>(values);
        //
        // sut.Insert(insertOnIndex, insertedValue);
        // if (sut.Contains(insertedValue))
        // {
        //     actual = expected;
        // }
        // Assert.Equal(expected, actual);
        // Assert.True(sut.Contains(insertedValue));
    }
   
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void IndexOf_ShouldReturnIndex_WhenItemInArray<T>(T[] values)
    {
       
    }
}