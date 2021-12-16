namespace Implementations.Algorithms;

public class AdpMergeSort<T> : BaseSort<T>
{
    public static void Sort(ref T[] array, int left, int right)
    {
        if (array.Length == 0 || left >= right) return;

        var pivot = FindPivot(left, right);

        Sort(ref array, left, pivot);
        Sort(ref array, pivot + 1, right);

        Merge(ref array, left, pivot, right);
    }

    private static void Merge(ref T[] array, int left, int pivot, int right)
    {
        var (leftArray, rightArray) = Partition(array, left, pivot, right);
        
        var leftIndex = 0;
        var rightIndex = 0;
        var index = left;
        
        while (leftIndex < leftArray.Length && rightIndex < rightArray.Length)
        {
            var result = Compare(leftArray[leftIndex], rightArray[rightIndex]);
            array[index++] = result ? rightArray[rightIndex++] : leftArray[leftIndex++];
        }
        
        while (leftIndex < leftArray.Length) array[index++] = leftArray[leftIndex++];
        while (rightIndex < rightArray.Length) array[index++] = rightArray[rightIndex++];
    }

    private static (T[], T[]) Partition(T[] array, int left, int pivot, int right)
    {
        var leftArrayLength = pivot - left + 1;
        var rightArrayLength = right - pivot;
        
        var leftArray = new T[leftArrayLength];
        var rightArray = new T[rightArrayLength];

        Array.Copy(array, left, leftArray, 0, leftArray.Length);
        Array.Copy(array, pivot + 1, rightArray, 0, rightArray.Length);

        return (leftArray, rightArray);
    }
}