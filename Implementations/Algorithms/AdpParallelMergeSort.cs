namespace Implementations.Algorithms;

public class AdpParallelMergeSort<T> : BaseSort<T>
{
    public static void Sort(T[] array, int left, int right, bool isParallel = false)
    {
        if (array.Length == 0 || left >= right) return;

        var pivot = FindPivot(left, right);

        if (!isParallel)
        {
            try
            {
                Parallel.Invoke(
                    () => Sort(array, left, pivot, true),
                    () => Sort(array, pivot + 1, right, true)
                );
            }
            catch (AggregateException e)
            {
                throw new InvalidOperationException("Can't compare types", e);
            }
        }
        else
        {
            Sort(array, left, pivot, true);
            Sort(array, pivot + 1, right, true);
        }

        Merge(array, left, pivot, right);
    }

    private static void Merge(T[] array, int left, int pivot, int right)
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