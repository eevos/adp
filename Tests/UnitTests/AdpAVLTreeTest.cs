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
    // [ClassData(typeof(DataSetLoader<DsSortDto>))]
    [InlineData(1)]
    public void InsertNode_ShouldReturnDepth<T>(params int[] values)
    {
        var expected = 1;
        var insertedData = values[0];
        
        var sut = new AdpTree(new AdpNode(insertedData,null,null,null,1));
        
        Assert.Equal(expected, sut.ListRoot.GetDepth());
    }    
    [Theory]
    // [ClassData(typeof(DataSetLoader<DsSortDto>))]
    [InlineData(1)]
    public void InsertMultipleNodes_ShouldReturnDepth<T>(params int[] values)
    {
        var tree = InsertTestNodes();
        
        Assert.Equal(4, tree.ListRoot.GetDepth());
    }

    public AdpTree InsertTestNodes()
    {
        var tree = new AdpTree();
        tree.Insert(1);
        tree.Insert(2);
        tree.Insert(3);
        tree.Insert(4);

        return tree;
    }
    
    
}