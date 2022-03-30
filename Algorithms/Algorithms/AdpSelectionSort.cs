namespace Algorithms.Algorithms;

public class AdpSelectionSort<T>
{
    
    public T[] Sort(T[] array)
    {
        if (array is null)
        {
            throw new InvalidOperationException("Array is not allowed to be null.");
        }
        var unsorted = new List<T>();
        var sorted = new List<T>();

        unsorted = array.ToList();
        var comparer = Comparer<T>.Default;
        
        for (int i = 0; i < array.Length; i++)
        {
            var minimum = unsorted[0];
            var indexMinimum = 0;
            for (int j = 0; j < unsorted.Count; j++)
            {
                if (comparer.Compare(unsorted[j], minimum) < 0)
                {
                    minimum = unsorted[j];
                    indexMinimum = j;
                }
            }
            sorted.Add(minimum);
            unsorted.RemoveAt(indexMinimum);
        }
        return sorted.ToArray();
    }
}