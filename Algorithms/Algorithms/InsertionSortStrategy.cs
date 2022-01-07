namespace Algorithms.Algorithms;

public class InsertionSortStrategy<T>
{
    public T[] InsertionSort(T[] array, int iterator)
    {

        if (array is null)
        {
            throw new InvalidOperationException("Array is not allowed to be null.");
        }

        
        // Recursie totdat array nog 1 item heeft
        if (iterator < 1) return array;
        InsertionSort(array, iterator - 1);
     
        // Insert last element at
        // its correct position
        // in sorted array.
        int lastPosition = iterator - 1;
        int oneBeforeLastPosition = iterator - 2;
     
        /* Move elements of arr[0..i-1],
        that are greater than key, to
        one position ahead of their
        current position */
        var comparer = Comparer<T>.Default;
            //while (j >= 0 && array[j] > last)
            while (oneBeforeLastPosition >= 0 && comparer.Compare(array[oneBeforeLastPosition],array[lastPosition]) > 0)
        {
            array[lastPosition] = array[oneBeforeLastPosition];
            oneBeforeLastPosition--;
        }
        array[oneBeforeLastPosition + 1] = array[lastPosition];
        return array;
    }
}