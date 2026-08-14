using System;

class Program
{
    static int JumpSearch(int[] arr, int key)
    {
        int n = arr.Length;
        int step = (int)Math.Sqrt(n);
        int prev = 0;

        // Finding the block where the element may be present
        while (prev < n && arr[Math.Min(step, n) - 1] < key)
        {
            prev = step;
            step += (int)Math.Sqrt(n);

            if (prev >= n)
                return -1;
        }

        // Linear search within the identified block
        while (prev < Math.Min(step, n))
        {
            if (arr[prev] == key)
                return prev;

            prev++;
        }

        return -1;
    }

    static void Main()
    {
        int[] arr = { 1, 4, 8, 15, 29, 33, 46, 60, 71, 92 };
        int key = 46;

        int index = JumpSearch(arr, key);

        if (index != -1)
            Console.WriteLine($"Element {key} found at index {index}");
        else
            Console.WriteLine("Element not found");
    }
}