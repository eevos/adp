namespace Algorithms.Algorithms;

public class QuickSortStrategy
{
    public QuickSortStrategy()
    {
    }

    public int[] QuickSort(int[] array)
    {
        //sort


        var result = array;

        return result;
    }

    private void quicksort(int[] A, int p, int r)
    {
        if (p < r)
        {
            int q = partition(A, p, r);
            quicksort(A, p, q);
            quicksort(A, q + 1, r);
        }
    }

    private int partition(int[] A, int p, int r)
    {
        int x = A[p]; // pivot
        int i = p;
        int j = r;
        while (true)
        {
            while (A[i] > x)
            {
                i++;
            }
            while (A[j] < x)
            {
                j--;
            }
            if (i < j)
            {
                int temp = A[i];
                A[i] = A[j];
                A[j] = temp;
            }
            else
            {
                return j;
            }
        }
    }

    class Program
    {
        private static void Quick_Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);
                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] {2, 5, -4, 11, 0, 18, 22, 67, 51, 6};
            Console.WriteLine("Original array : ");
            foreach (var item in arr)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
            Quick_Sort(arr, 0, arr.Length - 1);
            Console.WriteLine();
            Console.WriteLine("Sorted array : ");
            foreach (var item in arr)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();
        }
    }
}