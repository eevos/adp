using Implementations.DataSets;
using Implementations.DataStructures;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpLinkedListTest : BaseListTest
{
    [Fact]
    public void Create_Empty_List()
    {
        var sut = new AdpLinkedList<int>();
        Assert.Equal(0, sut.Count());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Add_CheckIfCountIsCorrect<T>(T[] values)
    {
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        Assert.Equal(values.Length, sut.Count());
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Add_CheckIfFirstItemIsCorrect<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        Assert.Equal(values[0], sut.First()!.Value);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Add_CheckIfLastItemIsCorrect<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        Assert.Equal(values[^1], sut.Last()!.Value);
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void AddAfter_CheckIfItemIsAdded<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        var addBeforeThisItem = sut.First();
        var valueForType = GetValueForType<T>();
        sut.AddAfter(addBeforeThisItem!, valueForType);
        
        Assert.Equal(valueForType, sut.First()!.Next.Value);
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void AddBefore_CheckIfItemIsAdded<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        var addBeforeThisItem = sut.First();
        var valueForType = GetValueForType<T>();
        sut.AddBefore(addBeforeThisItem!, valueForType);
        Assert.Equal(valueForType, sut.First()!.Value);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Loop_CheckItems<T>(T[] values)
    {
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        var index = 0;
        foreach (var item in sut)
        {
            Assert.Equal(values[index], item);
            index++;
        }
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Search_CheckIfCorrectNodeIsReturned<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        var node = sut.Search(values[^1]);
        Assert.Equal(values[^1], node!.Value);
    }

    // Check if search returns null when item is not found
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Search_CheckIfNullIsReturned<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        var node = sut.Search(GetValueForType<T>());
        Assert.Null(node);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Contains_CheckIfTrue<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        Assert.Contains(values[^1], sut);
    }

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Contains_CheckIfFalse<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        Assert.False(sut.Contains(GetValueForType<T>()));
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void RemoveValue_CheckIfReturnsTrue<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        Assert.True(sut.Remove(values[^1]));
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void RemoveValue_CheckIfItemIsRemoved<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        var valueToRemove = GetValueForType<T>();
        sut.Add(valueToRemove);
        sut.Remove(valueToRemove);
        Assert.False(sut.Contains(valueToRemove));
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void RemoveValue_CheckIfCountIsDecreased<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        var valueToRemove = GetValueForType<T>();
        sut.Add(valueToRemove);
        sut.Remove(valueToRemove);
        Assert.Equal(values.Length, sut.Count());
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void RemoveNode_CheckIfReturnsTrue<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        Assert.True(sut.Remove(sut.First()!));
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void RemoveNode_CheckIfItemIsRemoved<T>(T[] values)
    {
        if (AssertIndexOutOfRangeWhenEmptyArray(values)) return;
        var sut = new AdpLinkedList<T>();
        foreach (var value in values) sut.Add(value);

        var valueToRemove = GetValueForType<T>();
        sut.Add(valueToRemove);
        var nodeToRemove = sut.Search(valueToRemove);
        sut.Remove(nodeToRemove!);
        Assert.False(sut.Contains(nodeToRemove!.Value));
    }
}