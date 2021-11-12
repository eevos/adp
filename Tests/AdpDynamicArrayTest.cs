using Algorithms;
using Xunit;

namespace Tests;
public class UnitTest1
{
    [Theory]
    [InlineData(1)]
    [InlineData(1.2)]
    [InlineData('c')]
    [InlineData("test")]
    public void Push_AddItem_WhenEmpty<T>(T value)
    {
        var sut = new AdpDynamicArray<T>();
        sut.Push(value);
        Assert.Equal(value, sut[0]);
    }

    [Theory]
    [InlineData(2, 1)]
    [InlineData(4, 5, 6, 7, 8)]
    public void Push_CheckFirstItemIsCorrect_WhenMultipleItemsArePushed(params int[] values)
    {
        var sut = new AdpDynamicArray<int>();

        foreach (var value in values)
        {
            sut.Push(value);
        }

        Assert.Equal(values[0], sut[0]);
    }

    [Theory]
    [InlineData(2, 1)]
    [InlineData(4, 5, 6, 7, 8)]
    public void Push_CheckLastItemIsCorrect_WhenMultipleItemsArePushed(params int[] values)
    {
        var sut = new AdpDynamicArray<int>();

        foreach (var value in values)
        {
            sut.Push(value);
        }

        Assert.Equal(values[^1], sut[sut.Count() - 1]);
    }


    [Theory]
    [InlineData(1, 2, 3)]
    public void Pop_CheckCountMinus1_WhenLastItemIsRemoved(params int[] values)
    {
        var sut = new AdpDynamicArray<int>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        sut.Pop();

        Assert.Equal(values.Length - 1, sut.Count());
    }

    [Theory]
    [InlineData(1, 2, 3)]
    public void Pop_CheckLastItemIsReturned(params int[] values)
    {
        var sut = new AdpDynamicArray<int>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        Assert.Equal(values[^1], sut.Pop());
    }

    [Fact]
    public void Clear_ShouldBeEmpty_WhenEmpty()
    {
        var sut = new AdpDynamicArray<int>();
        sut.Clear();
        Assert.Equal(0, sut.Count());
    }
    
    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void Contains_ShouldReturnTrue_WhenItemIsInArray(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }
        
        Assert.True(sut.Contains("hello"));
    }

    [Theory]
    [InlineData("donald", "ninja", "dude", "hello", "world")]
    public void IndexOf_ShouldReturnCorrectIndex_WhenItemIsInArray(params string[] values)
    {
        var sut = new AdpDynamicArray<string>();
        foreach (var value in values)
        {
            sut.Push(value);
        }

        Assert.Equal(3, sut.IndexOf("hello"));
    }
}