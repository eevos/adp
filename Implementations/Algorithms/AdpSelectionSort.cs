namespace Implementations.Algorithms;

public class AdpSelectionSort<T>
{
    public static void Sort(ref T[] array)
    {
        var length = array.Length;
        var comparer = Comparer<T>.Default;

        for (var i = 0; i < length - 1; i++)
        {
            var maxIndex = 0;
            for (var j = 1; j < length - i; j++)
            {
                try
                {
                    if (comparer.Compare(array[j], array[maxIndex]) > 0)
                    {
                        maxIndex = j;
                    }
                    (array[maxIndex], array[length - i - 1]) = (array[length - i - 1], array[maxIndex]);
                }
                catch (ArgumentException e)
                {
                    throw new InvalidOperationException("Can't compare types", e);
                }
            }
        }
    }
}