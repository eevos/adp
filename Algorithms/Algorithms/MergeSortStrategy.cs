namespace Algorithms.Algorithms;

public class MergeSortStrategy
{
    public MergeSortStrategy()
    {
    }

    public int[] MergeSort(int[] array)
    {
        int[] left;
        int[] right;
        int[] result = new int[array.Length];
        if (array.Length <= 1)
            return array;
        int midPoint = array.Length / 2;
        left = new int[midPoint];

        //if array has an even number of elements, the left and right array will have the same number of 
        //elements
        if (array.Length % 2 == 0)
            right = new int[midPoint];
        //if array has an odd number of elements, the right array will have one more element than left
        else
            right = new int[midPoint + 1];
        //populate left array
        for (int i = 0; i < midPoint; i++)
            left[i] = array[i];
        //populate right array   
        int x = 0;
        //We start our index from the midpoint, as we have already populated the left array from 0 to midpont
        for (int i = midPoint; i < array.Length; i++)
        {
            right[x] = array[i];
            x++;
        }

        left = MergeSort(left);
        right = MergeSort(right);
        result = merge(left, right);
        return result;
    }

    public static int[] merge(int[] left, int[] right)
    {
        int resultLength = right.Length + left.Length;
        int[] result = new int[resultLength];
        //
        int indexLeft = 0, indexRight = 0, indexResult = 0;
        //while either array still has an element
        while (indexLeft < left.Length || indexRight < right.Length)
        {
            //if both arrays have elements  
            if (indexLeft < left.Length && indexRight < right.Length)
            {
                //If item on left array is less than item on right array, add that item to the result array 
                if (left[indexLeft] <= right[indexRight])
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                // else the item in the right array wll be added to the results array
                else
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            //if only the left array still has elements, add all its items to the results array
            else if (indexLeft < left.Length)
            {
                result[indexResult] = left[indexLeft];
                indexLeft++;
                indexResult++;
            }
            //if only the right array still has elements, add all its items to the results array
            else if (indexRight < right.Length)
            {
                result[indexResult] = right[indexRight];
                indexRight++;
                indexResult++;
            }
        }

        return result;
    }
}