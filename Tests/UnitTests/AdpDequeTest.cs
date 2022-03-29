using System;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpDequeTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void RemoveLeftRight_FirstAndLast_AreNotFound<T>(T[] values)
    {
        if (values == null || values.Length == 0 || values[0] == null|| values.Length > 2500)
        {
            var deque = new AdpDeque<T>(values);

            Assert.Throws<Exception>(() => deque.RemoveLeft());
        }
        else
        {
            var deque = new AdpDeque<T>(values);
            var valueToAdd = GetValueForType<T>();
            
            deque.AddLeft(valueToAdd);
            deque.AddRight(valueToAdd);
            var leftValue = deque.GetLeft();
            var rightValue = deque.GetRight();
            deque.RemoveLeft();
            deque.RemoveRight();
            
            Assert.NotEqual(leftValue, deque.GetLeft());
            Assert.NotEqual(rightValue, deque.GetRight());
        }
    }
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void AddLeftRight_FirstAndLast_AreFound<T>(T[] values)
    {
        if (values == null || values.Length == 0 || values[0] == null|| values.Length > 2500)
        {
            var deque = new AdpDeque<T>(values);

            Assert.Throws<Exception>(() => deque.GetLeft());
        }
        else
        {
            var deque = new AdpDeque<T>(values);
            
            var valueToAdd = GetValueForType<T>();
            deque.AddLeft(valueToAdd);
            deque.AddRight(valueToAdd);

            Assert.Equal(valueToAdd, deque.GetLeft());
            Assert.Equal(valueToAdd, deque.GetRight());
        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void GetLeft_ReturnsFirst<T>(T[] values)
    {
        if (values == null || values.Length == 0 || values[0] == null || values.Length > 2500)
        {
            var deque = new AdpDeque<T>(values);

            Assert.Throws<Exception>(() => deque.GetLeft());
        }
        else
        {
            var deque = new AdpDeque<T>(values);

            Assert.Equal(values[0], deque.GetLeft());
        }
    }

[Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Clear_ReturnsCorrectNumber<T>(T[] values)
    {
        var deque = new AdpDeque<T>(values);
        deque.Clear();
        Assert.Equal(0, deque.Count());
    }
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Count_ReturnsCorrectNumber<T>(T[] values)
    {
        var deque = new AdpDeque<T>(values);
        var count = deque.Count();
        Assert.Equal(values.Length, count);
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