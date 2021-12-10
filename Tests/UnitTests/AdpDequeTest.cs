using System.Linq;
using Implementations.DataSets;
using Implementations.DataStructures;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpDequeTest : BaseListTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Enqueue_CheckIfItemsAreEqual<T>(T[] values)
    {
        var sut = new AdpDeque<T>();
        foreach (var value in values) sut.Enqueue(value);
        Assert.Equal(values, sut.ToArray());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Enqueue_CheckIfCountIsEqual<T>(T[] values)
    {
        var sut = new AdpDeque<T>();
        foreach (var value in values) sut.Enqueue(value);
        Assert.Equal(values.Length, sut.Count);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Dequeue_CheckIfFirstItemIsRemoved<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDeque<T>();
        foreach (var value in values) sut.Enqueue(value);
        sut.Dequeue();
        Assert.Equal(values.Skip(1).ToArray(), sut.ToArray());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Dequeue_CheckIfFirstItemIsReturned<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDeque<T>();
        foreach (var value in values) sut.Enqueue(value);
        var first = sut.Dequeue();
        Assert.Equal(values.First(), first);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Dequeue_CheckIfItemsAreEqualAndRemoved<T>(T[] values)
    {
        var sut = new AdpDeque<T>();
        foreach (var value in values) sut.Enqueue(value);
        foreach (var value in values) sut.Dequeue();
        Assert.Equal(0, sut.Count);
    }

    [Theory]
    [InlineData(1, 2, 3, 4, 5, 6, 7, 8)]
    public void Circular_CheckIfItemsAreStoredCircularly(params int[] values)
    {
        var sut = new AdpDeque<int>();
        
        sut.Enqueue(values[0]);
        sut.Enqueue(values[1]);
        sut.Enqueue(values[2]);
        sut.Enqueue(values[3]);
        sut.Dequeue();
        sut.Dequeue();
        sut.Enqueue(values[4]);
        sut.Enqueue(values[5]);
        sut.Enqueue(values[6]);
        sut.Enqueue(values[7]);
        sut.Dequeue();

        Assert.Equal(values[7], sut[1]);
        Assert.Equal(values[7], sut.ToArray()[4]);
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void EnqueueFirst_CheckIfItemsAreEqual<T>(T[] values)
    {
        var sut = new AdpDeque<T>();
        foreach (var value in values) sut.EnqueueFirst(value);
        Assert.Equal(values.Reverse(), sut.ToArray());
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void EnqueueFirst_CheckIfCountIsEqual<T>(T[] values)
    {
        var sut = new AdpDeque<T>();
        foreach (var value in values) sut.EnqueueFirst(value);
        Assert.Equal(values.Length, sut.Count);
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void DequeueLast_CheckIfLastItemIsRemoved<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDeque<T>();
        foreach (var value in values) sut.Enqueue(value);
        sut.DequeueLast();
        Assert.Equal(values.Take(values.Length - 1).ToArray(), sut.ToArray());
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void DequeueLast_CheckIfLastItemIsReturned<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDeque<T>();
        foreach (var value in values) sut.Enqueue(value);
        var last = sut.DequeueLast();
        Assert.Equal(values.Last(), last);
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void DequeueLast_CheckIfItemsAreEqualAndRemoved<T>(T[] values)
    {
        var sut = new AdpDeque<T>();
        foreach (var value in values) sut.Enqueue(value);
        foreach (var value in values) sut.DequeueLast();
        Assert.Equal(0, sut.Count);
    }

    [Theory]
    [InlineData(1, 2, 3, 4, 5, 6, 7, 8)]
    public void Circular_CheckIfItemsAreStoredCircularlyReverse(params int[] values)
    {
        var sut = new AdpDeque<int>();
        
        sut.EnqueueFirst(values[0]);
        sut.EnqueueFirst(values[1]);
        sut.EnqueueFirst(values[2]);
        sut.EnqueueFirst(values[3]);
        sut.DequeueLast();
        sut.DequeueLast();
        sut.EnqueueFirst(values[4]);
        sut.DequeueLast();

        Assert.Equal(values[3], sut[4]);
        Assert.Equal(values[3], sut.ToArray()[1]);
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Peek_CheckIfFirstItemIsReturned<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDeque<T>();
        foreach (var value in values) sut.Enqueue(value);
        var first = sut.Peek();
        Assert.Equal(values.First(), first);
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void PeekLast_CheckIfLastItemIsReturned<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpDeque<T>();
        foreach (var value in values) sut.Enqueue(value);
        var last = sut.PeekLast();
        Assert.Equal(values.Last(), last);
    }
}