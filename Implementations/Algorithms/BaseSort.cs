namespace Implementations.Algorithms;

public abstract class BaseSort<T>
{
    protected static bool Compare(T a, T b)
    {
        try
        {
            var comparer = Comparer<T>.Default;
            return comparer.Compare(a, b) >= 0;
        }
        catch (ArgumentException e)
        {
            throw new InvalidOperationException("Can't compare types", e);
        }
    }
    
    protected static int FindPivot(int left, int right)
    {
        return (left + right) / 2;
    }
    
    protected static void Swap(ref T[] array, int index1, int index2)
    {
        (array[index2], array[index1]) = (array[index1], array[index2]);
    }
}