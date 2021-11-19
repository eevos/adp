using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms;

public class AdpDynamicArray<T> : IAdpDynamicArray<T>
{
    T[] items;

    public int Count()
    {
        return items.Length;
    }

    public AdpDynamicArray()
    {
        items = Array.Empty<T>();
    }

    public AdpDynamicArray(int capacity)
    {
        items = new T[capacity];
        var test = new List<int>();
    }

    public void Push(T item)
    {
        var newItems = new T[items.Length + 1];
        for (var i = 0; i < items.Length; i++)
        {
            newItems[i] = items[i];
        }

        newItems[^1] = item;
        items = newItems;
    }

    public T Pop()
    {
        var item = items[^1];
        var newItems = new T[items.Length - 1];
        for (var i = 0; i < newItems.Length; i++)
        {
            newItems[i] = items[i];
        }

        items = newItems;
        return item;
    }

    public void Clear()
    {
        items = Array.Empty<T>();
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
        var newItems = new T[items.Length + 1];

        var j = 0;
        for (var i = 0; i < newItems.Length; i++)
        {
            if (i == index)
            {
                newItems[i] = item;
                continue;
            }

            newItems[i] = items[j];
            j++;
        }

        items = newItems;
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
        var newItems = new T[items.Length - 1];

        var j = 0;
        for (var i = 0; i < items.Length; i++)
        {
            if (i == index) continue;

            newItems[j] = items[i];
            j++;
        }

        items = newItems;
        return true;
    }

    public T[] ToArray()
    {
        return items;
    }

    public T this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }
}