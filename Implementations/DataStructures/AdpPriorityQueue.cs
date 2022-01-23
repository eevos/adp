using System.Collections;

namespace Implementations.DataStructures;

public class AdpPriorityQueue<TElement, TPriority>
{
    // TODO - Replace list with binary three
    private List<PriorityItem<TElement, TPriority>> _items;
    
    public AdpPriorityQueue()
    {
        _items = new List<PriorityItem<TElement, TPriority>>();
    }

    public int Count()
    {
        return _items.Count;
    }
    
    public void Enqueue(TElement item, TPriority priority)
    {
        _items.Add(new PriorityItem<TElement, TPriority>(item, priority));

    }
    
    // Returns the object with the highest priority and removes it from the queue
    public TElement Dequeue()
    {
        _items.Sort();
        var firstItem = _items[0];
        _items.RemoveAt(0);
        return firstItem.Element;
    }
    
    // Returns the object with the highest priority
    public TElement Peek()
    {
        _items.Sort();
        return _items[0].Element;
    }
}

internal class PriorityItem<TElement, TPriority> : IComparable
{
    public TElement Element { get; set; }
    public TPriority Priority { get; set; }

    public PriorityItem(TElement element, TPriority priority)
    {
        Element = element;
        Priority = priority;
    }

    public int CompareTo(object? obj)
    {
        if (obj == null) return 1;

        if (obj is not PriorityItem<TElement, TPriority> otherPriorityItem)
            throw new ArgumentException("Object is not a priority item");
        var comparer = Comparer<TPriority>.Default;
        return comparer.Compare(Priority, otherPriorityItem.Priority);
    }
}