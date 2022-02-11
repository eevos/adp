using System;
using System.Collections.Generic;
using Implementations.DataSets;
using Algorithms;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;


namespace Tests.UnitTests;

public class AdpHashTableTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsHashTableDto>))]
    public void Add_CheckIfMultipleAdded_FindValueReturnsCorrectValue(Dictionary<string, int[]> values)
    {
    }

    [Theory]
    [InlineData(2)]
    [InlineData(-2)]
    [InlineData(945457457)]
    public void Add_CheckIfAddWorks(int value)
    {
        var hashTable = new AdpHashTable();
        var key = "a";
        
        hashTable.Add(key, value);
        var foundValue = hashTable.FindValue(key);
        
        Assert.Equal(value, foundValue);
    }

    [Theory]
    [InlineData("barbabababapapabarba")]
    [InlineData("ieniemienie")]
    public void CalculateIndexFromKey_CheckIfWorks(string key)
    {
        var hashTable = new AdpHashTable();
        var testIndex = hashTable.CalculateIndexFromKey(key);
        Assert.InRange(testIndex,0,hashTable.ListCapacity);
    }
    
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsHashTableDto>))]
    public void Add_CheckIfAdded_FindValueReturnsCorrectValue(Dictionary<string, int[]> values)
    {
        var hashTable = new AdpHashTable();
        hashTable.Add(values);
        // foreach (var (key, value) in values)
        // {
        //     hashTable.Add(key,value);
        // }
        foreach (var (key, value) in values)
        {
            //     Assert.Equal(value, hashTable[key]);
        Assert.Equal(value, hashTable.FindValue(key));
        }
    } 
    // [Theory]
    // [ClassData(typeof(DataSetLoader<DsHashTableDto>))]
    // public void AddDictionary_CheckIfAdded_FindValueReturnsCorrectValue(Dictionary<string, int[]> values)
    // {
    //     var hashTable = new AdpHashTable();
    //     foreach (var (key, value) in values)
    //     {
    //         hashTable.Add(key,value);
    //     }
    //     foreach (var (key, value) in values)
    //     {
    //         //     Assert.Equal(value, hashTable[key]);
    //     Assert.Equal(value, hashTable.FindValue(key));
    //     }
    // }
}