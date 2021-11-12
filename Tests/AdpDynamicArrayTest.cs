using System.Collections.Generic;
using Algorithms;
using Xunit;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void AddingItem()
    {
        var sut = new AdpDynamicArray<int>();
        
        sut.Add(1);
        
        Assert.Equal(1, sut[0]);
        
        var items = new List<int> { 1, 2, 3 };
        var item = items[2];
    }
}