using System.Collections;

namespace Algorithms.Algorithms;

public class AdpHashTable
{
    private LinkedList<HashedItem>[]? array;
    public int ListCapacity { get; set; }
    private double _loadFactor = 0.70;
    private int _filledSpotsInArray;
    private Dictionary<string, int[]> _dictionary;

    public AdpHashTable(int capacity)
    {
        ListCapacity = capacity;
        array = new LinkedList<HashedItem>[capacity];
        _dictionary = new Dictionary<string, int[]>();
        _filledSpotsInArray = 0;
    }

    public AdpHashTable()
    {
        ListCapacity = 30;
        array = new LinkedList<HashedItem>[ListCapacity];
        _dictionary = new Dictionary<string, int[]>();
        _filledSpotsInArray = 0;
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
        if (_dictionary.Count == 0) _dictionary = dictionary;
        foreach (var (key, arrayValues) in dictionary)
        {
            Add(key, arrayValues);
        }
    }

    public void Grow()
    {
        ListCapacity *= 2;
        array = new LinkedList<HashedItem>[ListCapacity];
    }

    public void Add(string key, int[] arrayValues)
    {
        if (HashTableExceedsLoadFactor())
        {
            Clear();
            Grow();
            Add(_dictionary);
            return;
        }
        var hashedItem = new HashedItem(key, arrayValues);
        var node = new LinkedListNode<HashedItem>(hashedItem);

        int indexOfLinkedList = CalculateIndexFromKey(key);
        if (array[indexOfLinkedList] == null)
        {
            array[indexOfLinkedList] = new LinkedList<HashedItem>();
        }

        array[indexOfLinkedList].AddFirst(node);
    }

    private void CountFilledSpotsInArray()
    {
        if (array.Any(i => i != null))
        {
            _filledSpotsInArray++;
        }
    }

    public double MeasureLoadFactor()
    {
        return _filledSpotsInArray / (double) array.Length;
    }

    private bool HashTableExceedsLoadFactor()
    {
        CountFilledSpotsInArray();
        if (MeasureLoadFactor() > _loadFactor)
        {
            return true;
        }

        return false;
    }

    public void Clear()
    {
        array = null;
        _filledSpotsInArray = 0;
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
        }
        catch (Exception e)
        {
            throw new Exception("exception: no key in linkedlist corresponds to requested key");
        }

        return returnValue;
    }
}