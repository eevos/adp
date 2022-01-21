using System;
using System.Collections.Generic;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpAVLTreeTest
{
    [Theory]
    [InlineData(1,2,3)]
    [InlineData(1, 2, 3, 5, 9, 7, -2)]
    public void InsertMultipleNodes_ShouldReturnValueOfRightChild<T>(params int[] values)
    {
        var expected = new List<int>(values);
        var tree = InsertTestNodes(values);
        var dataRightChild = tree.ListRoot._childRight._childRight._data;
        
        Assert.Equal(expected[2], dataRightChild);
    }
    [Theory]
    [InlineData(1,2,2)]
    public void InsertDuplicateNode_ShouldReturnException<T>(params int[] values)
    {
        Assert.Throws<Exception>(() => InsertTestNodes(values));
    }
    
    [Theory]
    [InlineData(1,2,3)]
    [InlineData(1,2,3,4,5)]
    [InlineData(1, 2, 3, 5, 9, 7, -2)]
    public void GetSize_ShouldReturnSize<T>(params int[] values)
    {
        var expected = values.Length;
        var tree = InsertTestNodes(values);
        var size = tree.GetSize();
        
        Assert.Equal(expected, size);
    }
    [Theory]
    [InlineData(new [] {1, 2, 3}, 2)]
    [InlineData(new [] {1, 2, 3, 5, 9, 7, -2}, -2)]
    public void Find_ShouldReturnInsertedNode(int[] values, int findValue)
    {
        var expected = findValue;
        var tree = InsertTestNodes(values);
        var actual = tree.Find(findValue);
        
        Assert.Equal(expected, actual._data);
    }
    [Theory]
    [InlineData(new [] {1}, 1)]
    public void SetDepth_ShouldReturn_ExpectedHeight<T>(int[] values, int height)
    {
        var expected = values[0];
        var sut = new AdpTree();
        sut.Insert(values[0]);
        sut.ListRoot._height = height;
        
        Assert.Equal(expected, sut.ListRoot._height);
    }
    [Theory]
    [InlineData(-1)]
    public void EmtpyTree_ShouldReturnHeight_minus1<T>(int height)
    {
        var expected = height;
        var sut = new AdpTree();

        Assert.Equal(expected, sut.Height());
    }
    [Theory]
    [InlineData(new [] {1}, 0)]
    public void TreeWithRoot_ShouldReturnHeight_1<T>(int[] values, int height)
    {
        var expected = height;
        var sut = new AdpTree();
        sut.Insert(values[0]);
        
        Assert.Equal(expected, sut.Height());
    }
    [Theory]
    [InlineData(new [] {1, 2}, (1))]
    // [InlineData(new [] {1, 2,3}, (2))]
    // [InlineData(new [] {1, 2,3,4}, (3))]
    public void InsertTwoNodes_ShouldReturnHeight_1<T>(int[] values, int height)
    {
        var expected = height;
        var sut = InsertTestNodes(values);
        
        Assert.Equal(expected, sut.Height());
    }
    // [Theory]
    // [InlineData(new [] {1 , 2, 3}, 2)]
    // [InlineData(new [] {1, 2, 3, 5, 9, 7, -2}, 3)]
    // public void Depth_ShouldReturnDepth(int[] values, int findValue)
    // {
    //     var tree = InsertTestNodes(values);
    //     var node = tree.Find(values[findValue]);
    //     var expected = tree.Height(node);
    //     var actual = tree.Find(values[findValue]);
    //     
    //     Assert.Equal(expected, actual.GetDepth());
    // }
    public AdpTree InsertTestNodes(int[] data)
    {
        var tree = new AdpTree();
        foreach (int item in data)
        {
            tree.Insert(item);
        }
        return tree;
    }
}