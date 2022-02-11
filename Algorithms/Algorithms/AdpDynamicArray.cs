using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms;

public class AdpDynamicArray<T> : IAdpDynamicArray<T>
{
    T?[] _items;
    int _size;

    public int ListCapacity
    {
        get { return _items.Length; }
    }

    public int Count()
    {
        return _size;
    }

    public AdpDynamicArray()
    {
        _items = Array.Empty<T>();
        _size = 0;
    }

    public AdpDynamicArray(int capacity)
    {
        _items = new T[capacity];
        _size = capacity;
    }

    public AdpDynamicArray(IEnumerable<T> collection)
    {
        _items = collection.ToArray();
        _size = _items.Length;
    }
    
    public void Add(T item)
    {
        Grow(_size + 1);
        _items[_size] = item;
        _size++;
    }
    
    public void Add(T[] collection)
    {
        Grow(_size + collection.Length);
        Array.Copy(collection, 0, _items, _size, collection.Length);
        _size += collection.Length;
    }

    public T Pop()
    {
        var item = _items[_size - 1];
        RemoveAt(_size - 1);
        return item;
    }

    public void Clear()
    {
        _items = Array.Empty<T>();
        _size = 0;
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
        Grow(_size + 1);
        Array.Copy(_items, index, _items, index + 1, _size - index);
        _items[index] = item;
        _size++;
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
        Shrink(_size - 1);
        Array.Copy(_items, index + 1, _items, index, _size - index - 1);
        _size--;
        return true;
    }

    public T[] ToArray()
    {
        var newItems = new T[_size];
        for (var i = 0; i < _size; i++)
        {
            newItems[i] = _items[i];
        }

        return newItems;
    }

    public T? this[int index]
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
    
    private void Grow(int newSize)
    {
        if (newSize >= _items.Length)
        {
            var newItems = new T[newSize * 2];
            Array.Copy(_items, newItems, _size);
            _items = newItems;
        }
    }
    
    private void Shrink(int newSize)
    {
        if (newSize < _items.Length / 2)
        {
            var newItems = new T[(int)Math.Ceiling((double)_items.Length / 2)];
            Array.Copy(_items, newItems, _size);
            _items = newItems;
        }
    }
}