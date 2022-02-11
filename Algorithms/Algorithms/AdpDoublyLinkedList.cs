using Algorithms.Interfaces;

namespace Algorithms.Algorithms;

public class AdpDoublyLinkedList<T> : IAdpDoublyLinkedList<T>
{
    private LinkedList<T> _items;

    public AdpDoublyLinkedList()
    {
        this._items = new();
    }

    public AdpDoublyLinkedList(T[] inputItems)
    {
        this._items = new LinkedList<T>(inputItems);
    }

    public int Count()
    {
        if (_items.Count == 0)
        {
            return 0;
        }

        var teller = 0;
        var node = _items.First;
        teller++;
        while (node.Next != null)
        {
            teller++;
            node = node.Next;
        }

        return teller;
    }

    public void Clear()
    {
        while (_items.First != null)
        {
            _items.RemoveFirst();
        }
    }

    public bool Contains(T item)
    {
        return _items.Contains(item);
    }

    public void Push(T itemToAdd)
    {
        var node = new LinkedListNode<T>(itemToAdd);
        _items.AddFirst(node);
    }
    // public void Push(int itemToAdd)
    // {
    //     var node = new LinkedListNode<T>(itemToAdd);
    //     items.AddFirst(node);
    // }
    public void Push(T[] itemsToAdd)
    {
        for (var i = 0; i < itemsToAdd.Length; i++)
        {
            var node = new LinkedListNode<T>(itemsToAdd[i]);
            this._items.AddFirst(node);
        }
    }

    public T Get(int index)
    {
        if (_items == null)
        {
            throw new Exception("Array is empty");
        } 
        var itemsToSearch = _items;
        var j = 0;
        while (j < index)
        {
            itemsToSearch.RemoveFirst();
            j++;
        }
        var item = itemsToSearch.First.Value;
        return item;
    }

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        if (index == 0)
        {
            var firstNode = _items.First;
            _items.AddBefore(firstNode, item);
        }
        else
        {
            var node = _items.First;
            for (int i = 0; i < index + 1; i++)
            {
                if (i == index)
                {
                    _items.AddAfter(node.Previous, item);
                }

                node = node.Next;
            }
        }
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public bool RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public T this[int index]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
}