using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algorithms.DataStructures;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpStackTest : BaseListTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Push_CheckIfItemIsAdded<T>(T[] values)
    {
        var stack = new AdpStack<T>(values.Length);
        foreach (var value in values)
            stack.Push(value);

        Assert.Equal(values, stack.ToArray());
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Push_CheckIfCountIsIncreased<T>(T[] values)
    {
        var stack = new AdpStack<T>(values.Length);
        foreach (var value in values)
            stack.Push(value);

        Assert.Equal(values.Length, stack.Count);
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Push_CheckIfStackOverflowExceptionIsThrown<T>(T[] values)
    {
        var stack = new AdpStack<T>(values.Length);
        foreach (var value in values)
            stack.Push(value);
        
        var valueToAdd = GetValueForType<T>();

        Assert.Throws<StackOverflowException>(() => stack.Push(valueToAdd));
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Pop_CheckIfLastItemIsReturned<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var stack = new AdpStack<T>(values.Length);
        foreach (var value in values)
            stack.Push(value);

        var lastItem = stack.Pop();
        Assert.Equal(values.Last(), lastItem);
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Pop_CheckIfItemIsRemoved<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var stack = new AdpStack<T>(values.Length);
        foreach (var value in values)
            stack.Push(value);

        var valueToRemove = stack.Pop();
        Assert.Equal(values.Last(), valueToRemove);
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Pop_CheckIfCountIsDecreased<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var stack = new AdpStack<T>(values.Length);
        foreach (var value in values)
            stack.Push(value);

        stack.Pop();
        Assert.Equal(values.Length - 1, stack.Count);
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Pop_CheckIfInvalidOperationExceptionIsThrown<T>(T[] values)
    {
        var stack = new AdpStack<T>(values.Length);
        Assert.Throws<InvalidOperationException>(() => stack.Pop());
    }
}