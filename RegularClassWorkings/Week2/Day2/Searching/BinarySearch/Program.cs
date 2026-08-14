using System;

class Program
{
    static int BinarySearch(int[] arr, int key)
    {
        int left = 0;
        int right = arr.Length - 1;

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

    static void Main()
    {
        int[] arr = { 1, 4, 8, 15, 29, 33, 46, 60, 71, 92 };
        int key = 46;

        int index = BinarySearch(arr, key);

        if (index != -1)
            Console.WriteLine($"Element {key} found at index {index}");
        else
            Console.WriteLine("Element not found");
    }
}