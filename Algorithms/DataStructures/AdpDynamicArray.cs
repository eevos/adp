using System.Collections;

namespace Algorithms.DataStructures;

public class AdpDynamicArray<T> : IEnumerable<T>
{
    private T[] items;
    private int size;

    public AdpDynamicArray()
    {
        items = Array.Empty<T>();
        size = 0;
    }

    public AdpDynamicArray(int capacity)
    {
        items = new T[capacity];
        size = capacity;
    }

    public AdpDynamicArray(IEnumerable<T> collection)
    {
        items = collection.ToArray();
        size = items.Length;
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
        return size;
    }

    public void Add(T item)
    {
        Grow(size + 1);
        items[size] = item;
        size++;
    }

    public void Add(T[] collection)
    {
        Grow(size + collection.Length);
        Array.Copy(collection, 0, items, size, collection.Length);
        size += collection.Length;
    }

    public T Pop()
    {
        var item = items[size - 1];
        RemoveAt(size - 1);
        return item;
    }

    public void Clear()
    {
        items = Array.Empty<T>();
        size = 0;
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
        Grow(size + 1);
        Array.Copy(items, index, items, index + 1, size - index);
        items[index] = item;
        size++;
    }

    public bool Remove(T item)
    {
        var index = IndexOf(item);
        if (index >= 0) return RemoveAt(index);

        return false;
    }

    public bool RemoveAt(int index)
    {
        Shrink(size - 1);
        Array.Copy(items, index + 1, items, index, size - index - 1);
        size--;
        return true;
    }

    public T[] ToArray()
    {
        var newItems = new T[size];
        for (var i = 0; i < size; i++) newItems[i] = items[i];

        return newItems;
    }

    private void Grow(int newSize)
    {
        if (newSize >= items.Length)
        {
            var newItems = new T[newSize * 2];
            Array.Copy(items, newItems, size);
            items = newItems;
        }
    }

    private void Shrink(int newSize)
    {
        if (newSize < items.Length / 2)
        {
            var newItems = new T[(int)Math.Ceiling((double)items.Length / 2)];
            Array.Copy(items, newItems, size);
            items = newItems;
        }
    }
}