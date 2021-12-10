namespace Algorithms.Algorithms;

public class MergeSortStrategy
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
        int midPoint = array.Length / 2;
        left = new int[midPoint];
        
        if (array.Length % 2 == 0)
            right = new int[midPoint];
        else
            right = new int[midPoint + 1];
        for (int i = 0; i < midPoint; i++)
            left[i] = array[i];
        int x = 0;
        for (int i = midPoint; i < array.Length; i++)
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
            if (left[iLeft] > right[iRight])
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
    //
    // public List<int> MergeSort(List<int> array)
    // {
    //     List<int> left;
    //     List<int> right;
    //     List<int> result = new List<int>();
    //     if (array.Count <= 1) return array;
    //     int midPoint = array.Count / 2;
    //     left = new List<int>();
    //     
    //     if (array.Count % 2 == 0)
    //         right = new List<int>();
    //     else
    //         right = new List<int>();
    //     for (int i = 0; i < midPoint; i++)
    //         left[i] = array[i];
    //     int x = 0;
    //     for (int i = midPoint; i < array.Count; i++)
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
    // private List<int> Merge(List<int> left, List<int> right)
    // {
    //     List<int> result = new List<int>();
    //     var iResult = 0;
    //     var iRight = 0;
    //     var iLeft = 0;
    //     while (iLeft < left.Count && iRight < right.Count)
    //     {
    //         if (left[iLeft] > right[iRight])
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