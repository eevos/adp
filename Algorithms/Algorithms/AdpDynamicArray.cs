using System.Collections;
using Algorithms.Interfaces;

namespace Algorithms;

public class AdpDynamicArray<T> : IAdpDynamicArray<T>
{
    T[] items;
    int size;
    
    public AdpDynamicArray()
    {
        items = Array.Empty<T>();
    }
    
    public AdpDynamicArray(int capacity)
    {
        items = new T[capacity];
    }
    
    public AdpDynamicArray(IEnumerable<T> collection)
    {
        items = collection.ToArray();
    }

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public int Count { get; }
    public bool IsReadOnly { get; }
    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public T this[int index]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
}