using System.Collections;

namespace Implementations.DataStructures;

public class AdpLinkedList<T> : IEnumerable<T>
{
    private readonly AdpLinkedListNode<T> _baseNode;
    private int _size;

    public AdpLinkedList()
    {
        _baseNode = new AdpLinkedListNode<T>(default!);
        _size = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = _baseNode.Next;
        while (current != _baseNode)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count()
    {
        return _size;
    }

    public AdpLinkedListNode<T>? First()
    {
        return _baseNode.Next == _baseNode ? null : _baseNode.Next;
    }

    public AdpLinkedListNode<T>? Last()
    {
        return _baseNode.Prev == _baseNode ? null : _baseNode.Prev;
    }

    public void Add(T item)
    {
        AddAfter(_baseNode.Prev, item);
    }
    
    public void AddAfter(AdpLinkedListNode<T> node, T item)
    {
        var newNode = new AdpLinkedListNode<T>(item, node, node.Next);
        node.Next = newNode;
        newNode.Next.Prev = newNode;
        _size++;
    }
    
    public void AddBefore(AdpLinkedListNode<T> node, T item)
    {
        var newNode = new AdpLinkedListNode<T>(item, node.Prev, node);
        node.Prev = newNode;
        newNode.Prev.Next = newNode;
        _size++;
    }

    public AdpLinkedListNode<T>? Search(T item)
    {
        var current = _baseNode.Next;
        while (!Equals(current.Value, item))
        {
            current = current.Next;
            if (current == _baseNode) return null;
        }

        return current;
    }

    public bool Contains(T item)
    {
        return Search(item) != null;
    }

    public bool Remove(T value)
    {
        var node = Search(value);
        if (node == null) return false;
        return Remove(node);
    }

    public bool Remove(AdpLinkedListNode<T> node)
    {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
        _size--;
        return true;
    }
}

public class AdpLinkedListNode<T>
{
    public AdpLinkedListNode<T> Prev { get; set; }
    public AdpLinkedListNode<T> Next { get; set; }
    public T Value { get; set; }

    public AdpLinkedListNode(T value)
    {
        Value = value;
        Prev = this;
        Next = this;
    }

    public AdpLinkedListNode(T value, AdpLinkedListNode<T> prev, AdpLinkedListNode<T> next)
    {
        Value = value;
        Prev = prev;
        Next = next;
    }
}