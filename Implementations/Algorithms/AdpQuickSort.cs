namespace Implementations.Algorithms;

public class AdpQuickSort<T> : BaseSort<T>
{
    public static void Sort(ref T[] array, int left, int right)
    {
        if (array.Length == 0) return;

        var pivotIndex = FindPivot(left, right);
        Swap(ref array, pivotIndex, right);
        var partitionIndex = Partition(array, left, right - 1, array[right]);
        Swap(ref array, partitionIndex, right);

        if (partitionIndex - left > 1) Sort(ref array, left, partitionIndex - 1);
        if (right - partitionIndex > 1) Sort(ref array, partitionIndex + 1, right);
    }


    private static int Partition(T[] array, int left, int right, T pivot)
    {
        while (left <= right)
        {
            while (!Compare(array[left], pivot)) left++;
            while (right >= left && Compare(array[right], pivot)) right--;
            if (right > left) Swap(ref array, left, right);
        }

        return left;
    }
}