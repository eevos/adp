using System.Collections;

namespace Implementations.DataStructures;

public class AdpHashTable : IDictionary
{
    private AdpBucket[] _buckets;
    private int _bucketCount;
    private int _size;
    private double _loadFactor = 0.75;
    private int _threshold;

    public AdpHashTable()
    {
        _bucketCount = 7;
        _buckets = new AdpBucket[_bucketCount];
        _threshold = (int)(_bucketCount * _loadFactor);
        _size = 0;
    }

    public AdpHashTable(int capacity)
    {
        _bucketCount = GetNewBucketSize(capacity);
        _buckets = new AdpBucket[_bucketCount];
        _threshold = (int)(_bucketCount * _loadFactor);
        _size = 0;
    }

    public AdpBucket[] GetBuckets()
    {
        return _buckets;
    }

    public void Add(object key, object value)
    {
        Grow(_size + 1);
        var hash = GetHash(key);
        var bucketIndex = GetEmptyBucketIndexForKey(hash);
        _buckets[bucketIndex] = new AdpBucket
        {
            HashKey = hash,
            Key = key,
            Value = value
        };
        _size++;
    }


    public void Clear()
    {
        _buckets = new AdpBucket[_bucketCount];
        _size = 0;
    }

    public bool Contains(object key)
    {
        return GetBucketIndexForKey(key) >= 0;
    }

    public IDictionaryEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void Remove(object key)
    {
        var bucketIndex = GetBucketIndexForKey(key);
        if (bucketIndex == -1)
        {
            return;
        }
        _buckets[bucketIndex] = null;
        _size--;
    }

    public bool IsFixedSize { get; }
    public bool IsReadOnly { get; }

    public object? this[object key]
    {
        get
        {
            var bucketIndex = GetBucketIndexForKey(key);
            return _buckets[bucketIndex]?.Value;
        }
        set => Add(key, value);
    }

    public ICollection Keys { get; }
    public ICollection Values { get; }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    public int Count
    {
        get => _size;
    }
    public bool IsSynchronized { get; }
    public object SyncRoot { get; }
    
    private int GetNewBucketSize(int capacity)
    {
        if (capacity < 7) return 7;
        
        var isEven = capacity % 2 == 0;
        return isEven ? capacity + 1 : capacity;
    }

    private int GetEmptyBucketIndexForKey(int hash)
    {
        var bucketIndex = hash % _bucketCount;
        var numberOfProbes = 1;
        while (_buckets[bucketIndex] != null)
        {
            bucketIndex = GetNextIndex(bucketIndex, numberOfProbes);
            numberOfProbes++;
        }

        return bucketIndex;
    }

    private int GetBucketIndexForKey(object key)
    {
        var hash = GetHash(key);
        var bucketIndex = hash % _bucketCount;

        var numberOfProbes = 1;
        while (_buckets[bucketIndex] != null && _buckets[bucketIndex].HashKey != hash)
        {
            bucketIndex = GetNextIndex(bucketIndex, numberOfProbes);
            numberOfProbes++;
        }
        
        if (_buckets[bucketIndex] == null)
        {
            return -1;
        }

        return bucketIndex;
    }

    // Rehash the table if the newSize is greater than the threshold
    private void Grow(int newSize)
    {
        if (newSize >= _threshold)
        {
            var newHashTable = new AdpHashTable(newSize * 2);
            foreach (var bucket in _buckets)
            {
                if (bucket == null) continue;
                newHashTable.Add(bucket.Key, bucket.Value);
            }
            
            _buckets = newHashTable.GetBuckets();
            _bucketCount = _buckets.Length;
            _threshold = (int)(_bucketCount * _loadFactor);
        }
    }

    private int GetNextIndex(int index, int numberOfProbes)
    {
        return (index + numberOfProbes ^ 2) % _bucketCount;
    }

    private int GetHash(object key)
    {
        // & 0x7FFFFFFF to remove the sign bit (because we are using ints)
        return key.GetHashCode() & 0xfffffff;
    }

    
}

public class AdpBucket : Object
{
    public int? HashKey { get; set; }
    public object Key { get; set; }
    public object Value { get; set; }
}