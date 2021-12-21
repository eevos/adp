using Implementations.DataSets;
using Implementations.DataStructures;
using Xunit;

namespace Tests.UnitTests;

public class AdpPriorityQueueTest : BaseListTest
{
    // [Theory]
    // [ClassData(typeof(DataSetLoader<DsSortDto>))]
    // public void Add_ShouldAddItemToQueue<T>(T[] values)
    // {
    //     var sut = new AdpPriorityQueue<T,T>();
    //
    //     sut.Enqueue(values[0], values[0]);
    //
    //     // Assert
    //     Assert.Equal(1, sut[0]);
    // }
}