using System.Collections;

namespace Algorithms.Algorithms;

public class AdpHashTable 
{
    private LinkedList<HashedItem>[]? _arrayOfLinkedLists_WithHashedItems;
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
        _arrayOfLinkedLists_WithHashedItems = new LinkedList<HashedItem>[ListCapacity];
    }
    private class HashedItem
    {
        public HashedItem(string key, int[] value)
        {
            ListKey = key;
            ListValue = value;
        }
        private int[]? ListValue { get; set; }
        private string ListKey { get; set; }
        
    }
    public void Add(Dictionary<string,int[]> dictionaryEntry) {
        foreach (var (key, arrayValues) in dictionaryEntry)
        {
            Add(key,arrayValues);
        }
    }
    public void Add(string key, int[] arrayValues)
    {   
        var hashedItem = new HashedItem(key, arrayValues);
        var node = new LinkedListNode<HashedItem>(hashedItem);
        
        int indexOfLinkedList = CalculateIndexFromKey(key);
        var linkedList = _arrayOfLinkedLists_WithHashedItems?[indexOfLinkedList];
        linkedList?.AddFirst(node);
    }
    public int CalculateIndexFromKey(string key)
    {
        var positiveHash = key.GetHashCode() & 0xfffffff;
        var length = _arrayOfLinkedLists_WithHashedItems.Length;
        var index = positiveHash % length;
        return index;
    }
    
    public int[]? FindValue(string key)
    {
        int indexOfLinkedList = CalculateIndexFromKey(key);
        var linkedList = _arrayOfLinkedLists_WithHashedItems?[indexOfLinkedList];
        var hashedItem = linkedList.Find();
        linkedList.    
        // return linkedList_WithHashedItems.Find(key);
        int[] array = {1, 2};
        return array;
    }
    
    
}