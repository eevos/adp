namespace Algorithms.Algorithms;

public class MergeSortStrategy//<T>where T : IComparable
{
    public MergeSortStrategy()
    {
    }
public int[] MergeSort(int[] array)
    {
        int[] left;
        int[] right;
        int[] result = new int[array.Length];
        if (array.Length <= 1) return array;
        var mid = array.Length / 2;
        left = new int[mid];
        
        if (array.Length % 2 == 0)
            right = new int[mid];
        else
            right = new int[mid + 1];
        for (var i = 0; i < mid; i++)
            left[i] = array[i];
        var x = 0;
        for (var i = mid; i < array.Length; i++)
        {
            right[x] = array[i];
            x++;
        }
        left = MergeSort(left);
        right = MergeSort(right);
        result = Merge(left, right);
        return result;
    }
    
    private static int[] Merge(int[] left, int[] right)
    {
        int[] result = new int[right.Length + left.Length];
        var iResult = 0;
        var iRight = 0;
        var iLeft = 0;
        while (iLeft < left.Length && iRight < right.Length)
        {
            if (left[iLeft].CompareTo(right[iRight]) >= 0)
            {
                result[iResult] = right[iRight];
                iRight++;
            }
            else
            {
                result[iResult] = left[iLeft];
                iLeft++;
            }
            iResult++;
        }
        while (iLeft < left.Length)
        {
            result[iResult] = left[iLeft];
            iLeft++;
            iResult++;
        }
        while (iRight < right.Length)
        {
            result[iResult] = right[iRight];
            iRight++;
            iResult++;
        }
        return result;
    }
    
    // public T[] MergeSort(T[] array)
    // {
    //     T[] left;
    //     T[] right;
    //     T[] result = new T[array.Length];
    //     if (array.Length <= 1) return array;
    //     var mid = array.Length / 2;
    //     left = new T[mid];
    //     
    //     if (array.Length % 2 == 0)
    //         right = new T[mid];
    //     else
    //         right = new T[mid + 1];
    //     for (var i = 0; i < mid; i++)
    //         left[i] = array[i];
    //     var x = 0;
    //     for (var i = mid; i < array.Length; i++)
    //     {
    //         right[x] = array[i];
    //         x++;
    //     }
    //     left = MergeSort(left);
    //     right = MergeSort(right);
    //     result = Merge(left, right);
    //     return result;
    // }
    //
    // private static T[] Merge(T[] left, T[] right)
    // {
    //     T[] result = new T[right.Length + left.Length];
    //     var iResult = 0;
    //     var iRight = 0;
    //     var iLeft = 0;
    //     while (iLeft < left.Length && iRight < right.Length)
    //     {
    //         if (left[iLeft].CompareTo(right[iRight]) >= 0)
    //         {
    //             result[iResult] = right[iRight];
    //             iRight++;
    //         }
    //         else
    //         {
    //             result[iResult] = left[iLeft];
    //             iLeft++;
    //         }
    //         iResult++;
    //     }
    //     while (iLeft < left.Length)
    //     {
    //         result[iResult] = left[iLeft];
    //         iLeft++;
    //         iResult++;
    //     }
    //     while (iRight < right.Length)
    //     {
    //         result[iResult] = right[iRight];
    //         iRight++;
    //         iResult++;
    //     }
    //     return result;
    // }
    
    // public List<T> MergeSort(List<T> array)
    // {
    //     List<T> left;
    //     List<T> right;
    //     List<T> result = new List<T>();
    //     if (array.Count <= 1) return array;
    //     var mid = array.Count / 2;
    //     left = new List<T>();
    //     
    //     if (array.Count % 2 == 0)
    //         right = new List<T>();
    //     else
    //         right = new List<T>();
    //     for (var i = 0; i < mid; i++)
    //         left[i] = array[i];
    //     var x = 0;
    //     for (var i = mid; i < array.Count; i++)
    //     {
    //         right[x] = array[i];
    //         x++;
    //     }
    //     left = MergeSort(left);
    //     right = MergeSort(right);
    //     result = Merge(left, right);
    //     return result;
    // }
    //
    // private List<T> Merge(List<T> left, List<T> right)
    // {
    //     List<T> result = new List<T>();
    //     var iResult = 0;
    //     var iRight = 0;
    //     var iLeft = 0;
    //     while (iLeft < left.Count && iRight < right.Count)
    //     {
    //         if (left[iLeft].CompareTo(right[iRight]) >= 0)
    //         {
    //             result[iResult] = right[iRight];
    //             iRight++;
    //         }
    //         else
    //         {
    //             result[iResult] = left[iLeft];
    //             iLeft++;
    //         }
    //         iResult++;
    //     }
    //     while (iLeft < left.Count)
    //     {
    //         result[iResult] = left[iLeft];
    //         iLeft++;
    //         iResult++;
    //     }
    //     while (iRight < right.Count)
    //     {
    //         result[iResult] = right[iRight];
    //         iRight++;
    //         iResult++;
    //     }
    //     return result;
    // }
}