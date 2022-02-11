using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms;

public class AdpDynamicArrayStepSize1<T> : IAdpDynamicArray<T>
{
    T[] _items;

    public int Count()
    {
        return _items.Length;
    }

    public AdpDynamicArrayStepSize1()
    {
        _items = Array.Empty<T>();
    }

    public AdpDynamicArrayStepSize1(int capacity)
    {
        _items = new T[capacity];
        var test = new List<int>();
    }
    
    public AdpDynamicArrayStepSize1(IEnumerable<T> collection)
    {
        _items = collection.ToArray();
    }

    public void Add(T item)
    {
        var newItems = new T[_items.Length + 1];
        for (var i = 0; i < _items.Length; i++)
        {
            newItems[i] = _items[i];
        }

        newItems[^1] = item;
        _items = newItems;
    }
    
    public void Add(T[] collection)
    {
        var newItems = new T[_items.Length + collection.Length];
        for (var i = 0; i < _items.Length; i++)
        {
            newItems[i] = _items[i];
        }
        
        for (var i = 0; i < collection.Length; i++)
        {
            newItems[i + _items.Length] = collection[i];
        }

        _items = newItems;
    }

    public T Pop()
    {
        var item = _items[^1];
        var newItems = new T[_items.Length - 1];
        for (var i = 0; i < newItems.Length; i++)
        {
            newItems[i] = _items[i];
        }

        _items = newItems;
        return item;
    }

    public void Clear()
    {
        _items = Array.Empty<T>();
    }

    public bool Contains(T item)
    {
        return _items.Contains(item);
    }

    public int IndexOf(T item)
    {
        return Array.IndexOf(_items, item);
    }

    public void Insert(int index, T item)
    {
        var newItems = new T[_items.Length + 1];

        var j = 0;
        for (var i = 0; i < newItems.Length; i++)
        {
            if (i == index)
            {
                newItems[i] = item;
                continue;
            }

            newItems[i] = _items[j];
            j++;
        }

        _items = newItems;
    }

    public bool Remove(T item)
    {
        var index = IndexOf(item);
        if (index >= 0)
        {
            return RemoveAt(index);
        }

        return false;
    }

    public bool RemoveAt(int index)
    {
        var newItems = new T[_items.Length - 1];

        var j = 0;
        for (var i = 0; i < _items.Length; i++)
        {
            if (i == index) continue;

            newItems[j] = _items[i];
            j++;
        }

        _items = newItems;
        return true;
    }

    public T[] ToArray()
    {
        return _items;
    }

    public T this[int index]
    {
        get => _items[index];
        set => _items[index] = value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)_items).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}