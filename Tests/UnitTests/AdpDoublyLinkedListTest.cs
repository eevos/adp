using System;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpDoublyLinkedList
{
    // test get

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void RemoveAt_ItemShouldNotBeFoundAtIndex<T>(T[] values)
    {
        if (values == null || values.Length == 0 || values[0] == null || values.Length > 2500)
        {
            var sut = new AdpDoublyLinkedList<T>(values);

            Assert.Throws<Exception>(() => sut.RemoveAt(5000));
        }
        else
        {
            var sut = new AdpDoublyLinkedList<T>(values);
            var expected = sut.Get(1);

            sut.RemoveAt(1);

            Assert.False(sut.Contains(expected));
        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Remove_ItemShouldNotBeFound<T>(T[] values)
    {
        if (values == null || values.Length == 0 || values[0] == null || values.Length > 2500)
        {
            var sut = new AdpDoublyLinkedList<T>(values);
            var item = GetValueForType<T>();

            Assert.Throws<Exception>(() => sut.Remove(item));
        }
        else if (typeof(T).Name == "Object")
        {
            Assert.Throws<InvalidOperationException>(() => Array.Sort(values));
        }
        else
        {
            var sut = new AdpDoublyLinkedList<T>(values);
            var item = sut.Get(0);

            sut.Remove(item);

            Assert.False(sut.Contains(item));
        }
    }

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
        if (values == null || values.Length == 0 || values[0] == null)
        {
            // return;
            var sut = new AdpDoublyLinkedList<T>(values);
            Assert.Throws<Exception>(() => sut.Get(1));
        }

        else //if (values.Length > 0 || values[0] != null)
        {
            var sut = new AdpDoublyLinkedList<T>(values);
            var expected = sut.Get(1); // just take an item
            Assert.True(sut.Contains(expected));
        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Contains_ShouldReturnFalse_WhenNotInArray<T>(T[] values)
    {
        var sut = new AdpDoublyLinkedList<T>(values);
        var item = GetValueForType<T>();
        Assert.False(sut.Contains(item));
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Push_ReturnsCorrectCount<T>(T[] values)
    {
        var expected = values.Length;
        var sut = new AdpDoublyLinkedList<T>();

        sut.Push(values);

        Assert.Equal(expected, sut.Count());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void AddLeft_AddRight_ReturnsCorrectCount<T>(T[] values)
    {
        var sut = new AdpDoublyLinkedList<T>();
        sut.Push(values);

        var item = GetValueForType<T>();

        var addLeft = 3;
        var addRight = 3;
        for (var i = 0; i < addLeft; i++) sut.AddLeft(item);
        for (var i = 0; i < addRight; i++) sut.AddRight(item);
        var expected = values.Length + addLeft + addRight;

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
            "Int32" => (T) Convert.ChangeType(992147, typeof(T)),
            "String" => (T) Convert.ChangeType("notInArray", typeof(T)),
            "Boolean" => (T) Convert.ChangeType(true, typeof(T)),
            "Single" => (T) Convert.ChangeType(913133139, typeof(T)),
            "Object" => (T) Convert.ChangeType("notInArray", typeof(T)),
            "Nullable`1" => (T) Convert.ChangeType(93131434, Nullable.GetUnderlyingType(typeof(T))),
            _ => throw new Exception("Type not supported")
        };
    }
}