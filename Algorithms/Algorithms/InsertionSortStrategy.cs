using System.Runtime.InteropServices;

namespace Algorithms.Algorithms;

public class InsertionSortStrategy<T>
{
    public T[] RecursiveSort(T[] array, int iterator)
    {

        if (array is null)
        {
            throw new InvalidOperationException("Array is not allowed to be null.");
        }
        
        if (iterator < 1) 
        {return array;}
        RecursiveSort(array, iterator - 1);

        var last = array[iterator - 1];
        int j = iterator - 2;

        var comparer = Comparer<T>.Default;
            while (j >= 0 && comparer.Compare(array[j],last) > 0)
        {
            array[j+1] = array[j];
            j--;
        }
        array[j + 1] = last;
        return array;
    }
    
    public T[] RecursiveSortForLoop(T[] array, int iterator)
    {

        if (array is null || array.Length == 0 || array[0] == null)
        {
            throw new Exception("Array is not allowed to be null.");
        }
        
        if (iterator < 1) 
        {return array;}
        RecursiveSort(array, iterator - 1);

        var last = array[iterator - 1];
        int j = iterator - 2;

        var comparer = Comparer<T>.Default;

        if (j > 0)
        {
            for (int i = j; comparer.Compare(array[j], last) > 0; i--)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = last;
        }

        return array;
    }
}