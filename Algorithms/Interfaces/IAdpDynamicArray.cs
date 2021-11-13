using System.Collections;

namespace Algorithms.Interfaces;

public interface IAdpDynamicArray<T>
{
    public int Count();
    public void Push(T item);
    public T Pop();

    public void Clear();

    public bool Contains(T item);

    public int IndexOf(T item);

    public void Insert(int index, T item);
    public bool Remove(T item);
    public bool RemoveAt(int index);

    public T this[int index] { get; set; }
}