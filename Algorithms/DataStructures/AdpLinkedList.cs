using System.Collections;

namespace Algorithms.DataStructures;

public class AdpLinkedList<T> : IEnumerable<T>
{
    private readonly AdpLinkedListNode<T> baseNode;
    private int size;

    public AdpLinkedList()
    {
        baseNode = new AdpLinkedListNode<T>(default);
        size = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = baseNode.Next;
        while (current != baseNode)
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
        return size;
    }

    public AdpLinkedListNode<T>? First()
    {
        return baseNode.Next == baseNode ? null : baseNode.Next;
    }

    public AdpLinkedListNode<T>? Last()
    {
        return baseNode.Prev == baseNode ? null : baseNode.Prev;
    }

    public void Add(T item)
    {
        AddAfter(baseNode.Prev, item);
    }
    
    public void AddAfter(AdpLinkedListNode<T> node, T item)
    {
        var newNode = new AdpLinkedListNode<T>(item, node, node.Next);
        node.Next = newNode;
        newNode.Next.Prev = newNode;
        size++;
    }
    
    public void AddBefore(AdpLinkedListNode<T> node, T item)
    {
        var newNode = new AdpLinkedListNode<T>(item, node.Prev, node);
        newNode.Next = node;
        newNode.Prev = node.Prev;
        node.Prev = newNode;
        newNode.Prev.Next = newNode;
        size++;
    }

    public AdpLinkedListNode<T>? Search(T item)
    {
        var current = baseNode.Next;
        while (!current.Value.Equals(item))
        {
            current = current.Next;

            if (current == baseNode) return null;
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
        size--;
        return true;
    }
}

public class AdpLinkedListNode<T>
{
    public AdpLinkedListNode<T> Prev { get; set; }
    public AdpLinkedListNode<T> Next { get; set; }
    public T? Value { get; set; }

    public AdpLinkedListNode(T? value)
    {
        Value = value;
        Prev = this;
        Next = this;
    }

    public AdpLinkedListNode(T? value, AdpLinkedListNode<T> prev, AdpLinkedListNode<T> next)
    {
        Value = value;
        Prev = prev;
        Next = next;
    }
}