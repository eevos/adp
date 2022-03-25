using System;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;
using Xunit.Sdk;

namespace Tests.UnitTests;

public class AdpStackTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Pop1_TopLowerThen_Size<T>(T[] values)
    {        
        var stack = new AdpStack<T>(values);
        var top = stack.FindTop();

        var thing = stack.Pop();
        if (stack.FindTop() == 0)
        {
            
            var excStack = new AdpStack<T>();
            var text = "Stack is empty";
            // var ex = Assert.Throws<Exception>(() => (Exception)excStack.FindTop());
            // Assert.Throws<Exception>(()=>excStack.FindTop());
        }
        Assert.Equal(top - 1,stack.FindTop());
    }    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void PushValues_CountSizeShouldReturn_Size<T>(T[] values)
    {
        var stack = new AdpStack<T>(values);
        Assert.Equal(values.Length,stack.CountSize());
    }
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Constructor_ShouldReturnNotNull<T>(T[] values)
    {
        var stack = new AdpStack<T>(values);
        Assert.NotNull(stack);
    }
}