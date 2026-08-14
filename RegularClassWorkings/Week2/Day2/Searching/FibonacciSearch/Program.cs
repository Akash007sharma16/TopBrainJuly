using System;

class Program
{
    static int FibonacciSearch(int[] arr, int key)
    {
        int n = arr.Length;

        int fibMMm2 = 0;      // (m-2)'th Fibonacci Number
        int fibMMm1 = 1;      // (m-1)'th Fibonacci Number
        int fibM = fibMMm2 + fibMMm1; // m'th Fibonacci Number

        // Find the smallest Fibonacci number greater than or equal to n
        while (fibM < n)
        {
            fibMMm2 = fibMMm1;
            fibMMm1 = fibM;
            fibM = fibMMm2 + fibMMm1;
        }

        int offset = -1;

        while (fibM > 1)
        {
            int i = Math.Min(offset + fibMMm2, n - 1);

            if (arr[i] < key)
            {
                fibM = fibMMm1;
                fibMMm1 = fibMMm2;
                fibMMm2 = fibM - fibMMm1;
                offset = i;
            }
            else if (arr[i] > key)
            {
                fibM = fibMMm2;
                fibMMm1 = fibMMm1 - fibMMm2;
                fibMMm2 = fibM - fibMMm1;
            }
            else
            {
                return i;
            }
        }

        // Check the last possible element
        if (fibMMm1 == 1 && offset + 1 < n && arr[offset + 1] == key)
            return offset + 1;

        return -1;
    }

    static void Main()
    {
        int[] arr = { 1, 4, 8, 15, 29, 33, 46, 60, 71, 92 };
        int key = 46;

        int index = FibonacciSearch(arr, key);

        if (index != -1)
            Console.WriteLine($"Element {key} found at index {index}");
        else
            Console.WriteLine("Element not found");
    }
}