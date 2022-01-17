using System;
using System.Collections.Generic;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpAVLTreeTest
{
    [Theory]
    [InlineData(1)]
    public void SetDepth_ShouldReturnDepth<T>(params int[] values)
    {
        var expected = values[0];
        
        var node = new AdpNode();
        var sut = new AdpTree(node);
        sut.ListRoot.SetDepth(1);
        
        Assert.Equal(expected, sut.ListRoot.GetDepth());
    }    
    
    [Theory]
    [InlineData(1)]
    public void GetDepth_ShouldReturnDepth<T>(params int[] values)
    {
        var expected = 1;
        var insertedData = values[0];
        
        var sut = new AdpTree(new AdpNode(insertedData,null,null,null,1));
        
        Assert.Equal(expected, sut.ListRoot.GetDepth());
    }
    [Theory]
    [InlineData(1,2,3)]
    public void InsertMultipleNodes_ShouldReturnValueOfRightChild<T>(params int[] values)
    {
        var expected = new List<int>(values);
        var tree = InsertTestNodes(values);
        var datarightChild = tree.ListRoot.GetRightChild().GetRightChild().GetData();
        
        Assert.Equal(expected[2], datarightChild);
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
    [InlineData(1,2,3,4,5,9,8,7)]
    public void GetSize_ShouldReturnSize<T>(params int[] values)
    {
        var expected = values.Length;
        var tree = InsertTestNodes(values);
        var size = tree.GetSize();
        
        Assert.Equal(expected, size);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(1, 2, 3, 4, 5)]
    [InlineData(1, 2, 3, 4, 5, 9, 8, 7)]
    public void Find_ShouldReturnNode<T>(params int[] values)
    {
        var expected = values.Length;
        var tree = InsertTestNodes(values);
        var size = tree.GetSize();

        Assert.Equal(expected, size);
    }

    
    
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