using System;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

namespace Tests.UnitTests;

public class AdpBinarySearchStrategyTest : TestHelper
{

    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Search_ShouldReturnTrue<T>(T[] values)
    {
        var sut = new BinarySearch<T>();
        Array.Sort(values); // array must be sorted for Binary Search

        if (values.Length == 0) // you can't search for empty
        {
            return;
        }

        Random random = new Random();
        var i = random.Next(0, values.Length - 1);
        var expected = values[i];
        
        Assert.True(sut.Search(values,expected));
    }    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void SearchNonExistent_ShouldReturnFalse<T>(T[] values)
    {
        var sut = new BinarySearch<T>();
        Array.Sort(values); 

        if (values.Length == 0) 
        {
            return;
        }

        var expected = GetValueForType<T>(); // this number can't exist
        
        Assert.False(sut.Search(values,expected));
    }
}
