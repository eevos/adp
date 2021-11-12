using System.Collections;

namespace Algorithms.Interfaces;

public interface IAdpDynamicArray<T> : IEnumerable<T>
{
    public int Count();
    public void Push(T item);
    public T Pop();

    public void Clear();

    public bool Contains(T item);

    public void CopyTo(T[] array, int arrayIndex);

    public int IndexOf(T item);
    public void Insert(int index, T item);
    public void RemoveAt(int index);

    public T this[int index] { get; set; }
}