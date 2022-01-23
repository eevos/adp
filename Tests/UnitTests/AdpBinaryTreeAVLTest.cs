using System;
using System.Linq;
using Implementations.DataSets;
using Implementations.DataStructures;
using Xunit;
using Xunit.Abstractions;

namespace Tests.UnitTests;

public class AdpBinaryTreeAVLTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public AdpBinaryTreeAVLTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Insert_SeePreOrderResults<T>(T[] values)
    {
        var sut = new AdpBinaryTreeAVL<T>();
        
        if (CanDataBeCompared<T>())
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var value in values)
                {
                    sut.Root = sut.Insert(sut.Root, value);
                }
            });
            return;
        }

        foreach (var value in values)
        {
           sut.Root = sut.Insert(sut.Root, value);
        }
        
        _testOutputHelper.WriteLine(sut.PreOrder(sut.Root));
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsIntSortDto>))]
    public void MinValue_CheckMinValue<T>(T[] values)
    {
        var sut = new AdpBinaryTreeAVL<T>();
        
        if (CanDataBeCompared<T>())
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var value in values)
                {
                    sut.Root = sut.Insert(sut.Root, value);
                }
            });
            return;
        }

        foreach (var value in values)
        {
            sut.Root = sut.Insert(sut.Root, value);
        }
        
        Assert.Equal(sut.MinValue(sut.Root), values.Min());
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsIntSortDto>))]
    public void MaxValue_CheckMaxValue<T>(T[] values)
    {
        var sut = new AdpBinaryTreeAVL<T>();
        
        if (CanDataBeCompared<T>())
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var value in values)
                {
                    sut.Root = sut.Insert(sut.Root, value);
                }
            });
            return;
        }

        foreach (var value in values)
        {
            sut.Root = sut.Insert(sut.Root, value);
        }
        
        Assert.Equal(sut.MaxValue(sut.Root), values.Max());
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsIntSortDto>))]
    public void Search_CheckSearch<T>(T[] values)
    {
        var sut = new AdpBinaryTreeAVL<T>();
        
        if (CanDataBeCompared<T>())
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var value in values)
                {
                    sut.Root = sut.Insert(sut.Root, value);
                }
            });
            return;
        }

        foreach (var value in values)
        {
            sut.Root = sut.Insert(sut.Root, value);
        }
        
        Assert.Equal(sut.Search( values.Min()).Key, values.Min());
        Assert.Equal(sut.Search( values.Max()).Key, values.Max());
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsIntSortDto>))]
    public void Search_CheckIfNullWhenNotFound<T>(T[] values)
    {
        var sut = new AdpBinaryTreeAVL<T>();
        
        if (CanDataBeCompared<T>())
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                foreach (var value in values)
                {
                    sut.Root = sut.Insert(sut.Root, value);
                }
            });
            return;
        }

        foreach (var value in values)
        {
            sut.Root = sut.Insert(sut.Root, value);
        }
        
        Assert.Null(sut.Search(default));
    }
    
    private static bool CanDataBeCompared<T>()
    {
        return typeof(T).Name == "Object" && !typeof(IComparable).IsAssignableFrom(typeof(T));
    }
}