using System.Collections.Generic;
using System.Collections.Immutable;
using Implementations.DataSets;
using Implementations.DataStructures;
using Xunit;

namespace Tests.UnitTests;

public class AdpPriorityQueueTest : BaseListTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsIntSortDto>))]
    public void Enqueue_ShouldAddItemToQueue<T>(T[] values)
    {
        var sut = new AdpPriorityQueue<T,T>();

        foreach (var value in values)
        {
            sut.Enqueue(value, value);
        }
        
        var valuesInList = new List<T>(values);
        valuesInList.Sort();
        Assert.Equal(valuesInList[0], sut.Peek());
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsIntSortDto>))]
    public void Dequeue_ShouldRemoveItemFromQueue<T>(T[] values)
    {
        var sut = new AdpPriorityQueue<T,T>();

        foreach (var value in values)
        {
            sut.Enqueue(value, value);
        }
        
        var valuesInList = new List<T>(values);
        valuesInList.Sort();
        
        Assert.Equal(valuesInList[0], sut.Dequeue()); 
    }
}