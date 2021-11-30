using Algorithms.Algorithms;
using Xunit;

namespace Tests.UnitTests;

public class AdpBinarySearchStrategyTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(1,2,3,4)]
    public void ReturnItem(params int[] values) //int -> T, opgelost door mischa
    {
        var item = 1; 
        var expected = values.Length; 
        var sut = new BinarySearchStrategy<int>();
        Assert.Equal(expected, sut.search(values, item));
    }
}