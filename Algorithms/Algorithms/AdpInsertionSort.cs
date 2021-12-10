namespace Algorithms.Algorithms;

public class AdpInsertionSort<T> 
{
    public static void Sort(ref T[] array)
    {
        var length = array.Length;
        
        var comparer = Comparer<T>.Default;
        
        for (var i = 1; i < length; i++)
        {
            var currentValue = array[i];
            var j = i - 1;

            while (j >= 0 && comparer.Compare(array[j],currentValue) > 0)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = currentValue;
        }
    }
}