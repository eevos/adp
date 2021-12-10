namespace Implementations.Algorithms;

public class AdpInsertionSort<T>
{
    public static void Sort(ref T[] array)
    {
        var length = array.Length;
        var comparer = Comparer<T>.Default;

        for (var i = 1; i < length; i++)
        {
            for (var j = i; j > 0; j--)
            {
                try
                {
                    if (comparer.Compare(array[j], array[j - 1]) > 0) break;
                    (array[j], array[j - 1]) = (array[j - 1], array[j]);
                }
                catch (ArgumentException e)
                {
                    throw new InvalidOperationException("Can't compare types", e);
                }
            }
        }
    }
}