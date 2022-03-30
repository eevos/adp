namespace Algorithms.Algorithms;

public class BinarySearch<T>
{
    public bool Search(T[] array, T item)
    {
        var low = 0;
        var high = array.Length - 1;
        
        while (low <= high)
        {
            var middle = (low + high) / 2;
            var comparer = Comparer<T>.Default;
            if (comparer.Compare(item, array[middle]) == 0)
            {
                return true;
            }
            if (comparer.Compare(item, array[middle]) < 0)
            {
                high = middle - 1;
            }
            else
            {
                low = middle + 1;
            }
        }
        return false;
    }
}