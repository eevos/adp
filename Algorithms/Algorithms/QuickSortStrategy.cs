using System.Collections.Concurrent;

namespace Algorithms.Algorithms;

public class QuickSortStrategy<T>
{
    public T[] QuickSort(T[] array, int leftPointer, int rightPointer)
    {
        if (array is null)
        {
            throw new InvalidOperationException("Array is not allowed to be null.");
        }
        var pivot = leftPointer;
        var comparer = Comparer<T>.Default;

        while (leftPointer != rightPointer)
        {
            while (comparer.Compare(array[rightPointer],array[pivot]) > 0
                   && leftPointer != rightPointer)
            {
                rightPointer--;
            }
            array[leftPointer] = array[rightPointer];
            while (comparer.Compare(array[leftPointer],array[pivot]) < 0
                   && leftPointer != rightPointer)
            {
                leftPointer++;
            }
            array[rightPointer] = array[leftPointer];
        }
        array[leftPointer] = array[pivot];
        return array;
    }
}
