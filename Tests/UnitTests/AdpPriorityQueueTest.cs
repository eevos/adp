using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpPriorityQueueTest : TestHelper
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void RemoveLeftRight_FirstAndLast_AreNotFound<T>(T[] values)
    {
        if (values == null || values.Length == 0 || values[0] == null || values.Length > 2500)
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
    public void Sort_Peek_ThenShowsSmallest<T>(T[] values)
    {
        if (values == null || values.Length == 0 || values[0] == null)
        {
            var queue = new AdpPriorityQueue<T>(values);

            Assert.Throws<Exception>(() => queue.Peek());
        }
        else if (typeof(T).Name == "Object")
        {
            Assert.Throws<InvalidOperationException>(() => Array.Sort(values));
        }
        else
        {
            var queue = new AdpPriorityQueue<T>(values);

            var expected = values.Min();
            var actual = queue.Peek();
            
            if (actual == null)
            {
                return;
                // Assert.Null(actual);
            }
            Assert.Equal(expected, actual);
        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Dequeue_ReturnsCount_MinusOne<T>(T[] values)
    {
        if (values == null || values.Length == 0 || values[0] == null)
        {
            var queue = new AdpPriorityQueue<T>(values);

            Assert.Throws<Exception>(() => queue.Dequeue());
        }
        else if (typeof(T).Name == "Object")
        {
            Assert.Throws<InvalidOperationException>(() => Array.Sort(values));
        }
        else
        {
            var queue = new AdpPriorityQueue<T>(values);

            var expected = values.Length - 1;
            queue.Dequeue();

            Assert.Equal(expected, queue.Count());
        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Enqueue_ReturnsCount_PlusOne<T>(T[] values)
    {
        var queue = new AdpPriorityQueue<T>(values);
        if (typeof(T).Name == "Object")
        {
            Assert.Throws<InvalidOperationException>(() => Array.Sort(values));
            return;
        }
        var expected = values.Length + 1;
        queue.Enqueue(GetValueForType<T>());

        Assert.Equal(expected, queue.Count());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Count_ReturnsCorrectNumber<T>(T[] values)
    {
        var queue = new AdpPriorityQueue<T>(values);

        var expected = values.Length;

        Assert.Equal(expected, queue.Count());
    }
}