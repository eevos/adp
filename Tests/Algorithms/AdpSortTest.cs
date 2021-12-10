using System;
using System.Collections.Generic;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;

namespace Tests.Algorithms;

public class AdpSortTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsSortDto>))]
    public void Sort_AdpInsertionSort_Test<T>(T[] values)
    {
        
        var list = new List<T>(values);

        if (typeof(T).Name == "Object")
        {
            Assert.Throws<InvalidOperationException>(() => list.Sort());
            return;
        }

        list.Sort();
        
        AdpInsertionSort<T>.Sort(ref values);
        Assert.Equal(list.ToArray(), values);
    }
}