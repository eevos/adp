using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.DataStructures;

public class AdpDeque<T> : IEnumerable<T>
{
    private T[] _items;
    private int _size;
    private int _head;
    private int _tail;

    public AdpDeque()
    {
        _items = Array.Empty<T>();
        _size = 0;
        _head = 0;
        _tail = 0;
    }

    public AdpDeque(int capacity)
    {
        _items = new T[capacity];
        _size = 0;
        _head = 0;
        _tail = 0;
    }

    public AdpDeque(IEnumerable<T> collection)
    {
        _items = collection.ToArray();
        _size = _items.Length;
        _head = 0;
        _tail = _size == 0 ? 0 : _size - 1;
    }
    
    public void EnqueueFirst(T item)
    {
        Grow(_size + 1);
        PrevIndex(ref _head);
        _items[_head] = item;
        _size++;
    }

    public void Enqueue(T item)
    {
        Grow(_size + 1);
        _items[_tail] = item;
        NextIndex(ref _tail);
        _size++;
    }
    
    public T Dequeue()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Deque is empty");
        }

        T item = _items[_head];
        _items[_head] = default;
        NextIndex(ref _head);
        _size--;
        return item;
    }
    
    public T DequeueLast()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Deque is empty");
        }

        PrevIndex(ref _tail);
        T item = _items[_tail];
        _items[_tail] = default;
        _size--;
        return item;
    }
    
    private void PrevIndex(ref int index)
    {
        if (index-- == 0)
        {
            index = _items.Length - 1;
        }
    }
    
    private void NextIndex(ref int index)
    {
        if (++index == _items.Length)
        {
            index = 0;
        }
    }

    public int Count => _size;
    
    public T Peek()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Deque is empty");
        }

        return _items[_head];
    }
    
    public T PeekLast()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("Deque is empty");
        }

        var index = _tail - 1;
        
        if (index < 0)
        {
            index = _items.Length - 1;
        }

        return _items[index];
    }

    public T[] ToArray()
    {
        return ResetArrayIndex(new T[_size]);
    }

    public T this[int index]
    {
        get => _items[index];
    }

    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)_items).GetEnumerator();
    }
    
    private void Grow(int newSize)
    {
        if (newSize > _items.Length)
        {
            var newItems = new T[newSize * 2];
            _items = ResetArrayIndex(newItems);
            _tail = _size;
            _head = 0;
        }
    }
    
    private T[] ResetArrayIndex(T[] newItems)
    {
        if (_size == 0)
        {
            return newItems;
        }
        
        if (_head < _tail)
        {
            Array.Copy(_items, _head, newItems, 0, _size);
        }
        else
        {
            Array.Copy(_items, _head, newItems, 0, _items.Length - _head);
            Array.Copy(_items, 0, newItems,  _items.Length - _head, _tail);
        }
        
        return newItems;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}