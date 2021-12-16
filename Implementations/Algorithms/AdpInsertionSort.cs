namespace Implementations.Algorithms;

public class AdpInsertionSort<T> : BaseSort<T>
{
    public static void Sort(ref T[] array)
    {
        var length = array.Length;

        for (var i = 1; i < length; i++)
        {
            for (var j = i; j > 0; j--)
            {
                if (Compare(array[j], array[j - 1])) break;
                Swap(ref array, j, j - 1);
            }
        }
    }
}