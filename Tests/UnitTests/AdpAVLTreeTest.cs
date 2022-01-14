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
        var insertedDepth = 1;
        var expected = insertedDepth;
        var sut = new AdpTree<T>.AdpNode<T>();
        sut.SetDepth(insertedDepth);
        Assert.Equal(expected, sut.GetDepth());
    }
    
    
    
    
    // [Theory]
    // [ClassData(typeof(DataSetLoader<DsSortDto>))]
    // public void InsertShouldMakeNode<T>(T[] values)
    // {
    //     
    //     Assert.Equal(expected, actual);
    // }
    
}