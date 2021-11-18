using Algorithms.Interfaces;

namespace Algorithms.Algorithms;

public class AdpDoublyLinkedList<T>: IAdpDoublyLinkedList<T>
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

    public void Push(T item)
    {
        throw new NotImplementedException();
    }

    public T Pop()
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

    public int IndexOf(T item)
    {
        throw new NotImplementedException();
    }

    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
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