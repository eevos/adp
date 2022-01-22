using System.Collections.Generic;
using Implementations.DataSets;
using Implementations.DataStructures;
using Xunit;

namespace Tests.UnitTests;

public class AdpHashTableTest
{
    [Theory]
    [ClassData(typeof(DataSetLoader<DsHashDto>))]
    public void Add_CheckIfAddedAndKeyReturnsCorrectValue(Dictionary<string, int[]> values)
    {
        var hashTable = new AdpHashTable();

        foreach (var (key, value) in values)
        {
            hashTable.Add(key,value);
        }
        
        foreach (var (key, value) in values)
        {
            Assert.Equal(value, hashTable[key]);
        }
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsHashDto>))]
    public void Count_CheckIfSizeIsCorrectAndCheckSetter(Dictionary<string, int[]> values)
    {
        var hashTable = new AdpHashTable(values.Count);

        foreach (var (key, value) in values)
        {
            hashTable[key] = value;
        }
        
        Assert.Equal(values.Count, hashTable.Count);
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsHashDto>))]
    public void Contains_CheckIfContainsKey(Dictionary<string, int[]> values)
    {
        var hashTable = new AdpHashTable();

        foreach (var (key, value) in values)
        {
            hashTable.Add(key,value);
        }
        
        foreach (var (key, value) in values)
        {
            Assert.True(hashTable.Contains(key));
        }
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsHashDto>))]
    public void Contains_CheckIfDoesNotContainKey(Dictionary<string, int[]> values)
    {
        var hashTable = new AdpHashTable();

        foreach (var (key, value) in values)
        {
            hashTable.Add(key,value);
        }
        
        var doesContain = hashTable.Contains("not-a-key");
        
        Assert.False(hashTable.Contains("not_existing_key"));
    }
    
    [Theory]
    [ClassData(typeof(DataSetLoader<DsHashDto>))]
    public void Remove_CheckIfRemoved(Dictionary<string, int[]> values)
    {
        var hashTable = new AdpHashTable();

        foreach (var (key, value) in values)
        {
            hashTable.Add(key,value);
        }
        
        foreach (var (key, value) in values)
        {
            hashTable.Remove(key);
            Assert.False(hashTable.Contains(key));
        }
    }
    
}