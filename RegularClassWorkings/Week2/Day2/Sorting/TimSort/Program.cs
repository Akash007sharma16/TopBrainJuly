using System;

class Program
{
    const int RUN = 32;

    static void InsertionSort(int[] arr, int left, int right)
    {
        for (int i = left + 1; i <= right; i++)
        {
            int temp = arr[i];
            int j = i - 1;

            while (j >= left && arr[j] > temp)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = temp;
        }
    }

    static void Merge(int[] arr, int l, int m, int r)
    {
        int len1 = m - l + 1;
        int len2 = r - m;

        int[] left = new int[len1];
        int[] right = new int[len2];

        for (int i = 0; i < len1; i++)
            left[i] = arr[l + i];

        for (int i = 0; i < len2; i++)
            right[i] = arr[m + 1 + i];

        int x = 0, y = 0, k = l;

        while (x < len1 && y < len2)
        {
            if (left[x] <= right[y])
                arr[k++] = left[x++];
            else
                arr[k++] = right[y++];
        }

        while (x < len1)
            arr[k++] = left[x++];

        while (y < len2)
            arr[k++] = right[y++];
    }

    static void TimSort(int[] arr)
    {
        int n = arr.Length;

        // Sort individual runs using Insertion Sort
        for (int i = 0; i < n; i += RUN)
        {
            InsertionSort(arr, i, Math.Min(i + RUN - 1, n - 1));
        }

        // Merge runs
        for (int size = RUN; size < n; size *= 2)
        {
            for (int left = 0; left < n; left += 2 * size)
            {
                int mid = left + size - 1;
                int right = Math.Min(left + 2 * size - 1, n - 1);

                if (mid < right)
                    Merge(arr, left, mid, right);
            }
        }
    }

    static void PrintArray(int[] arr)
    {
        Console.Write("[");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i]);
            if (i != arr.Length - 1)
                Console.Write(", ");
        }
        Console.WriteLine("]");
    }

    static void Main()
    {
        int[] arr = { 29, 4, 71, 15, 92, 8, 46, 33, 60, 1 };

        Console.WriteLine("Before:");
        PrintArray(arr);

        TimSort(arr);

        Console.WriteLine("After:");
        PrintArray(arr);
    }
}