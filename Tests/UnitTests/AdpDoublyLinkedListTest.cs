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
        var sut = new AdpDoublyLinkedList<T>();
        var item = GetValueForType<T>();
        for (var i = 0; i < 3; i++) sut.Push(item);
        sut.Push(values);
        var expected = values.Length + 3;
        
        Assert.Equal(expected, sut.Count());
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
    
     private static T GetValueForType<T>()
        {
            // switch with type
            return typeof(T).Name switch
            {
                "Int32" => (T)Convert.ChangeType(9999999, typeof(T)),
                "String" => (T)Convert.ChangeType("notInArray", typeof(T)),
                "Boolean" => (T)Convert.ChangeType(true, typeof(T)),
                "Single" => (T)Convert.ChangeType(99999999, typeof(T)),
                "Object" => (T)Convert.ChangeType("notInArray", typeof(T)),
                "Nullable`1" => (T)Convert.ChangeType(99993434, Nullable.GetUnderlyingType(typeof(T))),
                _ => throw new Exception("Type not supported")
            };
        }

}