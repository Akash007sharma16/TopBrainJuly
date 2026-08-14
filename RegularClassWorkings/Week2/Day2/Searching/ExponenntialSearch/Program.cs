using System;

class Program
{
    static int BinarySearch(int[] arr, int left, int right, int key)
    {
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == key)
                return mid;

            if (arr[mid] < key)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }

    static int ExponentialSearch(int[] arr, int key)
    {
        int n = arr.Length;

        // Check the first element
        if (arr[0] == key)
            return 0;

        // Find the range for Binary Search
        int i = 1;

        while (i < n && arr[i] <= key)
        {
            i *= 2;
        }

        // Perform Binary Search within the found range
        return BinarySearch(arr, i / 2, Math.Min(i, n - 1), key);
    }

    static void Main()
    {
        int[] arr = { 1, 4, 8, 15, 29, 33, 46, 60, 71, 92 };
        int key = 46;

        int index = ExponentialSearch(arr, key);

        if (index != -1)
            Console.WriteLine($"Element {key} found at index {index}");
        else
            Console.WriteLine("Element not found");
    }
}