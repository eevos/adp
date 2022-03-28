namespace Algorithms.Algorithms;

public class AdpStack<T>
{
    private List<T> _items;
    private int _top;
    private int _size;

    public AdpStack()
    {
        _items = new List<T>();
        _size = 0;
        _top = 0;
    }

    public AdpStack(T[] values)
    {
        _items = new List<T>();
        _top = 0;
        _size = 0;
        foreach (var value in values)
        {
            Push(value);
        }
    }

    public T Pop()
    {
        if (_top == 0 || _items[0] == null)
        {
            _items.Clear();
            throw new Exception("Stack is empty");
        }
        var result = _items[_top - 1];
        _top--;
        return result;
    }

    public void Push(T item)
    {
        _top++;
        _size++;
        _items.Add(item);
    }

    public void Clear()
    {
        _items.Clear();
        _top = 0;
    }

    public int CountSize()
    {
        if (_top < 1)
        {
            return 0;
        }

        return _size;
    }

    public int FindTop()
    {
        if (_top == 0 || _items[0] == null)
        {
            _items.Clear();
            throw new Exception("Stack is empty");
        }
        return _top;
    }
}