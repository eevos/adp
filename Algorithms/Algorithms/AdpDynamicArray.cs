﻿using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms;

public class AdpDynamicArray<T> : IAdpDynamicArray<T>
{
    T?[] items;
    int size;

    public int Capacity
    {
        get
        {
            return items.Length;
        }
    }
    public int Count()
    {
        return items.Length;
    }

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

    public void Add(T item)
    {
        var newItems = items;
        
        if (items.Length == 0)
        {
            newItems = new []{item};
        }
        else if (size == items.Length)
        {
            newItems = new T?[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                newItems[i] = items[i];
            }
            newItems[size] = item;
        }
        else
        {
            newItems[size] = item;
        }

        size++;
        items = newItems;
    }

    
    // public void Add(T item)
    // {
    //     var newItems = Resize(size + 1);
    //
    //     for (int i = 0; i < size; i++)
    //     {
    //         newItems[i] = items[i];
    //     }
    //
    //     newItems[size] = item;
    //     
    //     size++;
    //     items = newItems;
    // }
    
    private T[] Resize(int newSize)
    {
        if (newSize >= items.Length)
        {
            return new T[newSize * 2];
        }
        if (newSize < items.Length/2 )
        {
            return new T[(int)Math.Ceiling((double)items.Length / 2)];
        }
        
        return new T[newSize];
    }
    
    
    public void Add(T[] collection)
    {
        var newItems = new T[items.Length + collection.Length];
        for (var i = 0; i < items.Length; i++)
        {
            newItems[i] = items[i];
        }
        
        for (var i = 0; i < collection.Length; i++)
        {
            newItems[i + items.Length] = collection[i];
        }

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
        var newItems = new T[size];
        for (var i = 0; i < size; i++)
        {
            newItems[i] = items[i];
        }
        return newItems;
    }

    public T? this[int index]
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
}