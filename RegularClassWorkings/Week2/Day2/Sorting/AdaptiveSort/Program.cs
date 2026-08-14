using System;

class Program
{
    static void AdaptiveSort(int[] arr)
    {
        // Check if already sorted
        bool sorted = true;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < arr[i - 1])
            {
                sorted = false;
                break;
            }
        }

        if (sorted)
            return;

        // Otherwise perform Insertion Sort
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }

    static void PrintArray(int[] arr)
    {
        Console.Write("[");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
            if (i < arr.Length - 1)
                Console.Write(", ");
        }
        Console.WriteLine("]");
    }

    static void Main()
    {
        int[] arr = { 29, 4, 71, 15, 92, 8, 46, 33, 60, 1 };

        Console.WriteLine("Before:");
        PrintArray(arr);

        AdaptiveSort(arr);

        Console.WriteLine("After:");
        PrintArray(arr);
    }
}