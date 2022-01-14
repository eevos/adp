using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpAVLTreeTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void SetDepth_ShouldReturnDepth<T>(T[] values)
    {
        var expected = 1;
        var node = new AdpNode<T>();
        var sut = new AdpTree<T>(node);
        sut.ListRoot.SetDepth(1);
        
        Assert.Equal(expected, sut.ListRoot.GetDepth());
    }    
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void InsertNode_ShouldReturnDepth<T>(T[] values)
    {
        var insertedData = values[0];
        var sut = new AdpTree<T>(new AdpNode<T>(insertedData,null,null,null,1));
        var expected = 1;
        Assert.Equal(expected, sut.ListRoot.GetDepth());
    }
    
    
    
}