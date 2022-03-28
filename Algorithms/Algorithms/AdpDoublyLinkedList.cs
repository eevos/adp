using Algorithms.Interfaces;

namespace Algorithms.Algorithms;

public class AdpDoublyLinkedList<T>
{
    private LinkedList<T> _items;

    public AdpDoublyLinkedList()
    {
        _items = new LinkedList<T>();
    }

    public AdpDoublyLinkedList(T[] inputItems)
    {
        _items = new LinkedList<T>(inputItems);
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

    public void AddLeft(T itemToAdd)
    {
        Push(itemToAdd, "left");
    }

    public void AddRight(T itemToAdd)
    {
        Push(itemToAdd, "right");
    }

    private void Push(T itemToAdd, string side)
    {
        var node = new LinkedListNode<T>(itemToAdd);
        if (side is "left" or null)
        {
            _items.AddFirst(itemToAdd);
        }
        else
        {
            _items.AddLast(itemToAdd);
        }
    }

    public void Push(T[] itemsToAdd)
    {
        for (var i = 0; i < itemsToAdd.Length; i++)
        {
            AddLeft(itemsToAdd[i]);
        }
    }

    public T Get(int index)
    {
        if (_items == null || _items.Count == 0 || _items.First.Value == null)
        {
            throw new Exception("LinkedList is empty");
        }

        if (index == 0) return _items.First.Value;
        
        var node = _items.First;
        for (int i = 0; i < _items.Count; i++)
        {
            var nextNode = node.Next;
            if (i != index)
            {
                node = nextNode;
            }
            else
            {
                break;
            }
        }
        return node.Value;
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

    public void Remove(T item)
    {
        var node = _items.First;
        ErrorCheck(node);

        var comparer = Comparer<T>.Default;
        for (int i = 0; i < _items.Count; i++)
        {
            var nextNode = node.Next;
            if (comparer.Compare(node.Value, item) == 0)
            {
                _items.Remove(item);
                node = nextNode;
            }
            else
            {
                node = nextNode;
            }
        }
    }


    public void RemoveAt(int index)
    {
        var node = _items.First;
        ErrorCheck(node);

        for (int i = 0; i < _items.Count; i++)
        {
            var nextNode = node.Next;
            if (i == index)
            {
                _items.Remove(node);
                return;
            }
            node = nextNode;
        }
    }

    private void ErrorCheck(LinkedListNode<T> node)
    {
        if (_items.First == null || node.Value == null || _items.Count == 0)
        {
            throw new Exception("LinkedList is empty");
        }

        if (_items.Count > 2500)
        {
            throw new Exception("LinkedList is too big for memory");
        }
    }
}