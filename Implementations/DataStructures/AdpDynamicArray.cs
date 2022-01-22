using System.Collections;

namespace Implementations.DataStructures;

public class AdpDynamicArray<T> : IEnumerable<T>
{
    private T[] items;
    private int _size;

    public AdpDynamicArray()
    {
        items = Array.Empty<T>();
        _size = 0;
    }

    public AdpDynamicArray(int capacity)
    {
        items = new T[capacity];
        _size = capacity;
    }

    public AdpDynamicArray(IEnumerable<T> collection)
    {
        items = collection.ToArray();
        _size = items.Length;
    }

    public int Capacity => items.Length;

    public T this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)items).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count()
    {
        return _size;
    }

    public void Add(T item)
    {
        Grow(_size + 1);
        items[_size] = item;
        _size++;
    }

    public void Add(T[] collection)
    {
        Grow(_size + collection.Length);
        Array.Copy(collection, 0, items, _size, collection.Length);
        _size += collection.Length;
    }

    public T Pop()
    {
        var item = items[_size - 1];
        RemoveAt(_size - 1);
        return item;
    }

    public void Clear()
    {
        items = Array.Empty<T>();
        _size = 0;
    }

    public bool Contains(T item)
    {
        return items.Contains(item);
    }

    public int IndexOf(T item)
    {
        return Array.IndexOf(items, item);
    }

    public void Insert(int index, T item)
    {
        Grow(_size + 1);
        Array.Copy(items, index, items, index + 1, _size - index);
        items[index] = item;
        _size++;
    }

    public bool Remove(T item)
    {
        var index = IndexOf(item);
        if (index >= 0) return RemoveAt(index);

        return false;
    }

    public bool RemoveAt(int index)
    {
        Shrink(_size - 1);
        Array.Copy(items, index + 1, items, index, _size - index - 1);
        _size--;
        return true;
    }

    public T[] ToArray()
    {
        var newItems = new T[_size];
        for (var i = 0; i < _size; i++) newItems[i] = items[i];

        return newItems;
    }

    private void Grow(int newSize)
    {
        if (newSize < items.Length) return;
        
        var newItems = new T[newSize * 2];
        Array.Copy(items, newItems, _size);
        items = newItems;
    }

    private void Shrink(int newSize)
    {
        if (newSize >= items.Length / 2) return;
        var newItems = new T[(int)Math.Ceiling((double)items.Length / 2)];
        Array.Copy(items, newItems, _size);
        items = newItems;
    }
}