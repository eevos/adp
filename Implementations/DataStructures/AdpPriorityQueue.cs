using System.Collections;

namespace Implementations.DataStructures;

public class AdpPriorityQueue<TElement, TPriority>
{
    
    private (TElement, TPriority)[] _heap;
    private int _size;

    public AdpPriorityQueue()
    {
        _heap = Array.Empty<(TElement, TPriority)>();
        _size = 0;
    }
    
    public int Count()
    {
        return _size;
    }
    
    public void Enqueue(TElement item, TPriority priority)
    {
        throw new NotImplementedException();
    }
    
    // Returns the object with the highest priority and removes it from the queue
    public TElement Dequeue()
    {
        throw new NotImplementedException();
    }
    
    // Returns the object with the highest priority
    public TElement Peek()
    {
        throw new NotImplementedException();
    }
}