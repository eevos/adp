namespace Algorithms.Algorithms;
using System.Collections;

public class AdpPriorityQueue<T> //: ErrorCheck
{
    private List<T> _items;

    public AdpPriorityQueue()
    {
        
    }
    public AdpPriorityQueue(IEnumerable<T> items)
    {
        _items = new List<T>(items);
    }
    public void Enqueue(T item)
    {
        _items.Add(item); // add at the end
        SortQueue();
    }
    public T Peek()
    {
        ErrorCheck();
        if (_items[0] == null)
        {
            ErrorCheck(_items[0]);
        }
        else
        {
            ErrorCheck();
        }
        SortQueue();
        return _items[0]; 
    }
    public T Dequeue()
    {
        ErrorCheck();

        var firstItem = Peek(); 
        _items.RemoveAt(0);
        return firstItem;
    }
    private void SortQueue()
    {
        // TODO: Elaborate Sort to SelectionSort or other?
        _items.Sort();
    }

    public int Count()
    {
        return _items.Count;
    }
    private void ErrorCheck()
    {
        if (_items == null || _items.Count == 0)
        {
            throw new Exception("Queue is empty");
        }
    }
    private void ErrorCheck(object item)
    {
        if (_items[0] == null || item == null || _items.Count == 0)
        {
            throw new Exception("Queue is empty");
        }
    }
}