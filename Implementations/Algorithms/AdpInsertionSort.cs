namespace Implementations.Algorithms;

public class AdpInsertionSort<T> : BaseSort<T>
{
    public static void Sort(T[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            for (var j = i; j > 0; j--)
            {
                if (Compare(array[j], array[j - 1])) break;
                Swap(array, j, j - 1);
            }
        }
    }
}