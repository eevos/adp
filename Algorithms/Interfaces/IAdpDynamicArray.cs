using System.Collections;

namespace Algorithms.Interfaces;

public interface IAdpDynamicArray<T>
{
    public void Add(T item);

    public void Clear();

    public bool Contains(T item);

    public void CopyTo(T[] array, int arrayIndex);

    public bool Remove(T item);

    public int Count { get; }
    public bool IsReadOnly { get; }
    public int IndexOf(T item);
    public void Insert(int index, T item);
    public void RemoveAt(int index);

    public T this[int index] { get; set; }
}