namespace Implementations.Algorithms;

public class AdpQuickSort<T> : BaseSort<T>
{
    public static void Sort(T[] array, int left, int right)
    {
        if (array.Length == 0) return;

        var pivotIndex = FindPivot(left, right);
        Swap(array, pivotIndex, right);
        var partitionIndex = Partition(array, left, right - 1, array[right]);
        Swap(array, partitionIndex, right);

        if (partitionIndex - left > 1) Sort(array, left, partitionIndex - 1);
        if (right - partitionIndex > 1) Sort(array, partitionIndex + 1, right);
    }


    private static int Partition(T[] array, int leftIndex, int rightIndex, T pivot)
    {
        while (leftIndex <= rightIndex)
        {
            while (!Compare(array[leftIndex], pivot)) leftIndex++;
            while (rightIndex >= leftIndex && Compare(array[rightIndex], pivot)) rightIndex--;
            if (rightIndex > leftIndex) Swap(array, leftIndex, rightIndex);
        }

        return leftIndex;
    }
}