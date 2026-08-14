using System;

class Program
{
    static int InterpolationSearch(int[] arr, int key)
    {
        int low = 0;
        int high = arr.Length - 1;

        while (low <= high &&
               key >= arr[low] &&
               key <= arr[high])
        {
            // If there is only one element
            if (low == high)
            {
                if (arr[low] == key)
                    return low;
                return -1;
            }

            // Estimate the probable position
            int pos = low + ((key - arr[low]) * (high - low))
                            / (arr[high] - arr[low]);

            if (arr[pos] == key)
                return pos;

            if (arr[pos] < key)
                low = pos + 1;
            else
                high = pos - 1;
        }

        return -1;
    }

    static void Main()
    {
        int[] arr = { 1, 4, 8, 15, 29, 33, 46, 60, 71, 92 };
        int key = 46;

        int index = InterpolationSearch(arr, key);

        if (index != -1)
            Console.WriteLine($"Element {key} found at index {index}");
        else
            Console.WriteLine("Element not found");
    }
}