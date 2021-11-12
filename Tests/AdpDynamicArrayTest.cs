using System.Collections.Generic;
using Algorithms;
using Xunit;

namespace Tests;

public class UnitTest1
{
    [Theory]
    [InlineData(1)]
    [InlineData("test")]
    public void AddItem_WhenIsEmpty<T>(T value)
    {
        var sut = new AdpDynamicArray<T>();
        sut.Add(value);
        Assert.Equal(value, sut[0]);
    }
    
    [Theory]
    [InlineData(2,1)]
    [InlineData(4,"test")]
    public void AddItem_WhenNotEmpty<T>(int capacity, T value)
    {
        var sut = new AdpDynamicArray<T>(capacity);
        sut.Add(value);
        Assert.Equal(value, sut[capacity]);
    }
}