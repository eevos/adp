using System;
using System.Collections.Generic;
using Implementations.DataSets;
using Algorithms.Algorithms;
using Tests.DataSets;
using Xunit;


namespace Tests.UnitTests;

public class AdpHashTableTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsHashTableDto>))]
    public void Clear_CheckIfMultipleAdded_FindReturnsNull(Dictionary<string, int[]> values)
    {
        var hashTable = new AdpHashTable();
        
        hashTable.Add(values);
        hashTable.Clear();
        
        foreach (var (key, value) in values)
        {
            Assert.Throws<Exception>(() => hashTable.FindValue(key));
        }
    } 
    [Theory]
    [ClassData(typeof(DataSetLoader<DsHashTableDto>))]
    public void HashTableExceedsLoadFactor_CheckIfHashTableGrows(Dictionary<string, int[]> values)
    {        
        var initialLength = 2;
        var hashTable = new AdpHashTable(initialLength);

        hashTable.Add(values);
        
        Assert.NotInRange(hashTable.ListCapacity,2,2);
        
    }
    [Theory]
    [ClassData(typeof(DataSetLoader<DsHashTableDto>))]
    public void Add_CheckIfMultipleAdded_FindReturnsValues(Dictionary<string, int[]> values)
    {
        var hashTable = new AdpHashTable();
        
        hashTable.Add(values);

        foreach (var (key, value) in values)
        {
            Assert.Equal(value, hashTable.FindValue(key));
        }
    } 
    [Theory]
    [InlineData(2)]
    [InlineData(-2)]
    [InlineData(945457457)]
    public void Add_CheckIfAddedString_FindReturnsString(params int[] value)
    {
        var hashTable = new AdpHashTable();
        var key = "ieniemienie";
        
        hashTable.Add(key, value);
        var foundValue = hashTable.FindValue(key);
        
        Assert.Equal(value, foundValue);
    }
    [Theory]
    [InlineData(2)]
    public void Add_CheckIfAddedString_FindReturnsException(params int[] value)
    {
        var hashTable = new AdpHashTable();
        var keyToAdd = "ieniemienie";
        
        hashTable.Add(keyToAdd, value);
        
        Assert.Throws<Exception>(() => hashTable.FindValue("oeniemoenie"));
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
    
}