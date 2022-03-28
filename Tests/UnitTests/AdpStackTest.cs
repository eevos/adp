using System;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Tests.UnitTests;

public class AdpStackTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Pop_CheckIfExceptionIsThrown_OnEmptyStack<T>(T[] values)
    {
        var stack = new AdpStack<T>();
        Assert.Throws<Exception>(() => stack.Pop());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Pop_FindTopReturns_Minus1<T>(T[] values)
    {

        if (values == null || values.Length == 0 || values[0] == null)
        {
            var stack = new AdpStack<T>();
            Assert.Throws<Exception>(() => stack.FindTop());
        }
        else
        {
            var stack = new AdpStack<T>(values);
            var top = stack.FindTop();
            
            stack.Pop();
            Assert.Equal(top - 1, stack.FindTop());
        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void PushValues_ValuesCanBeFound_InArray<T>(T[] values)
    {
        if (values == null || values.Length == 0 || values[0] == null)
        {
            var stack = new AdpStack<T>();
            Assert.Throws<Exception>(() => stack.Pop());
        }
        else
        {
            var stack = new AdpStack<T>(values);
            for (int i = values.Length; i == 0; i--)
            {
                var expected = values[i];
                var result = stack.Pop();

                Assert.Equal(expected,result);
            }
        }
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void PushValues_CountSizeShouldReturn_ValuesLength<T>(T[] values)
    {
        var stack = new AdpStack<T>(values);
        Assert.Equal(values.Length, stack.CountSize());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Constructor_ShouldReturnNotNull<T>(T[] values)
    {
        var stack = new AdpStack<T>(values);
        Assert.NotNull(stack);
    }
}