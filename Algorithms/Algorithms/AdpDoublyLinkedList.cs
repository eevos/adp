using Algorithms.Interfaces;

namespace Algorithms.Algorithms;

public class AdpDoublyLinkedList<T> : IAdpDoublyLinkedList<T>
{
    private LinkedList<T> items;

    public AdpDoublyLinkedList()
    {
        this.items = new();
    }

    public AdpDoublyLinkedList(T[] inputItems)
    {
        this.items = new LinkedList<T>(inputItems);
    }

    public int Count()
    {
        if (items.Count == 0)
        {
            return 0;
        }

        var teller = 0;
        var node = items.First;
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
        while (items.First != null)
        {
            items.RemoveFirst();
        }
    }

    public bool Contains(T item)
    {
        return items.Contains(item);
    }

    public void Push(T itemToAdd)
    {
        var node = new LinkedListNode<T>(itemToAdd);
        items.AddFirst(node);
    }

    public void Push(T[] itemsToAdd)
    {
        for (var i = 0; i < itemsToAdd.Length; i++)
        {
            var node = itemsToAdd[i];
            this.items.AddFirst(node);
        }
    }

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        if (index == 0)
        {
            var firstNode = items.First;
            items.AddBefore(firstNode, item);
        }
        else
        {
            var node = items.First;
            for (int i = 0; i < index + 1; i++)
            {
                if (i == index)
                {
                    items.AddAfter(node.Previous, item);
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