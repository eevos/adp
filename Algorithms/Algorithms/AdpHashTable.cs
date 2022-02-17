using System.Collections;

namespace Algorithms.Algorithms;

public class AdpHashTable
{
    private LinkedList<HashedItem>[]? array;
    public int ListCapacity { get; set; }
    private double _loadFactor = 0.70;
    private Dictionary<string, int[]> _dictionary;

    public AdpHashTable(int capacity)
    {
        ListCapacity = capacity;
        array = new LinkedList<HashedItem>[capacity];
        _dictionary = new Dictionary<string, int[]>();
    }
    public AdpHashTable()
    {
        ListCapacity = 10;
        array = new LinkedList<HashedItem>[ListCapacity];
        _dictionary = new Dictionary<string, int[]>();
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
        _dictionary = dictionary;
        foreach (var (key, arrayValues) in dictionary)
        {
            Add(key, arrayValues);
        }
    }

    private bool HashTableExceedsLoadFactor()
    {
        var filledSpotsInArray = 0;
        foreach (var spot in array)
        {
            if (spot.First != null)
            {
                filledSpotsInArray++;
            }
        }
        if ((filledSpotsInArray / (double) array.Length) > _loadFactor)
        {
            return true;
        }
        return false;
    }
    public void Add(string key, int[] arrayValues)
    {
        if (HashTableExceedsLoadFactor())
        {
            ListCapacity = ListCapacity * 2;
            Add(_dictionary);
            return;
        }

        var hashedItem = new HashedItem(key, arrayValues);
        var node = new LinkedListNode<HashedItem>(hashedItem);
        
        int indexOfLinkedList = CalculateIndexFromKey(key);
        // if index has no LinkedList: declare first
        if (array[indexOfLinkedList] == null)
        {
            array[indexOfLinkedList] = new LinkedList<HashedItem>();
            array[indexOfLinkedList].AddFirst(node);
        }
        else
        {
            array[indexOfLinkedList].AddFirst(node);
        }
    }

    public void Add(Hashtable hashtable)
    {
        
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
        try
        {
            int indexOfLinkedList = CalculateIndexFromKey(key);
            var linkedList = array?[indexOfLinkedList];
            for (var node = linkedList.First; node != null; node = node.Next)
            {
                if (key == node.Value.ListKey)
                {
                    returnValue = node.Value.ListValue;
                }
            }
        } catch (Exception e)
        {
            throw new Exception("exception: no key in linkedlist corresponds to requested key");
        }
        return returnValue;
    }
}