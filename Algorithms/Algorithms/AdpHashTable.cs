using System.Collections;

namespace Algorithms.Algorithms;

public class AdpHashTable
{
    private LinkedList<HashedItem>[]? array;
    public int ListCapacity { get; set; }
    private double _loadFactor = 0.7;

    // public AdpHashTable(int capacity)
    // {
    //     ListCapacity = capacity;
    //     // _arrayOfLinkedLists_WithHashedItems = new HashedItem[capacity];
    //     _arrayOfLinkedLists_WithHashedItems = new LinkedList<HashedItem>[capacity];
    // }
    public AdpHashTable()
    {
        ListCapacity = 30;
        array = new LinkedList<HashedItem>[ListCapacity];
    }

    private class HashedItem
    {
        public HashedItem(string key, int[] value)
        {
            ListKey = key;
            ListValue = value;
        }

        public int[]? ListValue { get; set; }
        public string ListKey { get; set; }
    }

    public void Add(Dictionary<string, int[]> dictionary)
    {
        foreach (var (key, arrayValues) in dictionary)
        {
            Add(key, arrayValues);
        }
    }

    public void Add(string key, int[] arrayValues)
    {
        var hashedItem = new HashedItem(key, arrayValues);
        var node = new LinkedListNode<HashedItem>(hashedItem);
        
        int indexOfLinkedList = CalculateIndexFromKey(key);
        // if index has no LinkedList:
        var linkedList = new LinkedList<HashedItem>();
        // var linkedList = 
        array[indexOfLinkedList] = linkedList;
        linkedList.AddFirst(node);
    }

    public int CalculateIndexFromKey(string key)
    {
        var positiveHash = key.GetHashCode() & 0xfffffff;
        var length = array.Length;
        var index = positiveHash % length;
        return index;
    }

    public int[]? FindValue(string key)
    {
        int[]? returnValue = null;
        // try
        // {
            int indexOfLinkedList = CalculateIndexFromKey(key);
            var linkedList = array?[indexOfLinkedList];
            for (var node = linkedList.First; node != null; node = node.Next)
            {
                if (key == node.Value.ListKey)
                {
                    returnValue = node.Value.ListValue;
                }
            }
        // } catch (Exception e)
        // {
        //     throw new Exception("exception: no key in linkedlist corresponds to requested key");
        // }
        return returnValue;
    }
}