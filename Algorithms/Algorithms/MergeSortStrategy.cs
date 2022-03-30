namespace Algorithms.Algorithms;

public class MergeSortStrategy<T> 
{
    //php-example from rosettacode
    public List<T> MergeSort(List<T> values)
    {
        if (values.Count <= 1) return values; // base

        var mid = values.Count / 2;
        var left = values.GetRange(0, mid);
        var right = values.GetRange(mid, values.Count - mid);

        left = MergeSort(left);
        right = MergeSort(right);
        var result = Merge(left, right);
 
        return result;
    }

    private static List<T> Merge(List<T> left, List<T> right)
    {
        List<T> result = new List<T>();
        var comparer = Comparer<T>.Default;

        while (left.Count > 0 & right.Count > 0)
        {
            if (comparer.Compare(left[0], right[0]) > 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
            else
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }
        }
        while (left.Count > 0)
        {
            result.Add(left[0]);
            left.RemoveAt(0);
        }
        while (right.Count > 0)
        {
            result.Add(right[0]);
            right.RemoveAt(0);
        }
        return result;
    }
}