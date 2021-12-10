using System.Collections;

namespace Implementations.DataStructures;

public class AdpStack<T> : IEnumerable<T>
{
    private T[] _items;
    private int _size;
    
    public AdpStack(int capacity)
    {
        _items = new T[capacity];
        _size = 0;
    }
    
    public int Count
    {
        get { return _size; }
    }
    
    public void Push(T item)
    {
        if (_size == _items.Length)
        {
            throw new StackOverflowException();
        }
        
        _items[_size++] = item;
    }
    
    public T Pop()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException();
        }
        
        return _items[--_size];
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