using Algorithms.Algorithms;
using Xunit;

namespace Tests.UnitTests;

public class AdpDoublyLinkedList
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(11, -222, 100)]
    [InlineData(1, 2, 3, 11, -222, 100)]
    public void Count_AssertShouldReturnExpected_WithNumbers(params int[] values)
    {
        var expected = values.Length;
        var sut = new AdpDoublyLinkedList<int>(values);
        
        Assert.Equal(expected, sut.Count());
    }

    // [Theory]
    // [InlineData(1, 2, 3),3]
    // public void Count_ShouldReturnExpected(params int[] values, int expected)
    // {
    //     var sut = new AdpDoublyLinkedList<int>(values);
    //     
    //     Assert.Equal(expected,sut.Count());
    // }

    
    
}