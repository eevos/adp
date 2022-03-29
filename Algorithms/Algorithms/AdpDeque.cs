namespace Algorithms.Algorithms;

public class AdpDeque<T>
{
    private LinkedList<T> _items;

    public AdpDeque(T[] items)
    {
        _items = new LinkedList<T>(items);
    }

    public AdpDeque()
    {
        _items = new LinkedList<T>();
    }

    public int Count()
    {
        var count = 0;
        foreach (var item in _items)
        {
            count++;
        }

        return count;
    }

    public void Clear()
    {
        _items.Clear();
    }

    public void AddLeft(T itemToAdd)
    {
        _items.AddFirst(itemToAdd);
    }

    public void AddRight(T itemToAdd)
    {
        _items.AddLast(itemToAdd);
    }

    public T GetLeft()
    {
        if (_items.First == null)
            ErrorCheck();
        else
            ErrorCheck(_items.First);

        return _items.First.Value;
    }

    public T GetRight()
    {
        if (_items.First == null)
            ErrorCheck();
        else
            ErrorCheck(_items.First);
        return _items.Last.Value;
    }

    public void RemoveRight()
    {
        if (_items.First == null)
        {
            ErrorCheck();
        }
        else
        {
            ErrorCheck(_items.First);
        }
        _items.RemoveLast();
    }

    public void RemoveLeft()
    {
        if (_items.First == null)
        {
            ErrorCheck();
        }
        else
        {
            ErrorCheck(_items.First);
        }
        _items.RemoveFirst();
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

    private void ErrorCheck()
    {
        if (_items.First == null || _items.Count == 0)
        {
            throw new Exception("LinkedList is empty");
        }

        if (_items.Count > 2500)
        {
            throw new Exception("LinkedList is too big for memory");
        }
    }
}