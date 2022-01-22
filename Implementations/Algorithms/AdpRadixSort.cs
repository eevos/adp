using System.Diagnostics;

namespace Implementations.Algorithms;

public class AdpRadixSort<T> : BaseSort<T>
{
    public static void Sort(int[] array)
    {
        var tempArray = new int[array.Length];
        
        var numberOfBuckets = GetNumberOfBuckets(array);
        var maxItemLenght = GetMaxItemLenght(array);
        
        var countPerBucket = new int[numberOfBuckets];
        
        for (int i = 0, charPosition = 1; i < maxItemLenght; i++, charPosition *= 10)
        {
            for (var j = 0; j < numberOfBuckets; j++) countPerBucket[j] = 0; // Reset bucket count

            foreach (var item in array)
            {
                var bucketIndex = GetBucketIndex(item, charPosition, numberOfBuckets);
                countPerBucket[bucketIndex]++;
            }

            countPerBucket[0]--;
            for (var j = 1; j < numberOfBuckets; j++) countPerBucket[j] += countPerBucket[j - 1];
            
            for (var j = array.Length - 1; j >= 0; j--)
            {
                var bucketIndex = GetBucketIndex(array[j], charPosition, numberOfBuckets);
                tempArray[countPerBucket[bucketIndex]] = array[j];
                countPerBucket[bucketIndex]--;
            }
            
            Array.Copy(tempArray, array, array.Length);
        }
    }
    
    private static int GetBucketIndex(int item, int charPosition, int numberOfBuckets)
    {
        if (numberOfBuckets > 10)
        {
            var bucketIndex = item / charPosition % 10 + 10;
            return bucketIndex;
        }
        return (item / charPosition) % numberOfBuckets;
    }

    // private static int GetNumberOfPossibleCharacters()
    // {
    //     return typeof(T).Name switch
    //     {
    //         "Int32" => 10,
    //         "String" => (T)Convert.ChangeType("notInArray", typeof(T)),
    //         "Boolean" => (T)Convert.ChangeType(true, typeof(T)),
    //         "Single" => (T)Convert.ChangeType(99999999, typeof(T)),
    //         "Object" => (T)Convert.ChangeType("notInArray", typeof(T)),
    //         "Nullable`1" => (T)Convert.ChangeType(99993434, Nullable.GetUnderlyingType(typeof(T))!),
    //         _ => throw new Exception("Type not supported")
    //     }; 
    // };

    private static int GetMaxItemLenght(int[] array)
    {
        var minLength = array.Min().ToString().Length;
        var maxLength = array.Max().ToString().Length;
        
        return maxLength > minLength ? maxLength : minLength;
    }

    private static int GetNumberOfBuckets(int[] array)
    {
        return array.Min() < 0 ? 19 : 10;
    }
    
    
}