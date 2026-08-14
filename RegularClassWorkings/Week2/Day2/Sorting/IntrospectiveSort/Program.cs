using System;

class Program
{
    const int INSERTION_SORT_THRESHOLD = 16;

    static void IntroSort(int[] arr)
    {
        int depthLimit = 2 * (int)Math.Log(arr.Length, 2);
        IntroSortUtil(arr, 0, arr.Length - 1, depthLimit);
    }

    static void IntroSortUtil(int[] arr, int low, int high, int depthLimit)
    {
        while (high - low > INSERTION_SORT_THRESHOLD)
        {
            if (depthLimit == 0)
            {
                HeapSort(arr, low, high);
                return;
            }

            depthLimit--;

            int pivot = Partition(arr, low, high);

            IntroSortUtil(arr, pivot + 1, high, depthLimit);
            high = pivot - 1;
        }

        InsertionSort(arr, low, high);
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
    }

    static void HeapSort(int[] arr, int low, int high)
    {
        int n = high - low + 1;

        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i, low);

        for (int i = n - 1; i > 0; i--)
        {
            Swap(arr, low, low + i);
            Heapify(arr, i, 0, low);
        }
    }

    static void Heapify(int[] arr, int n, int i, int offset)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && arr[offset + left] > arr[offset + largest])
            largest = left;

        if (right < n && arr[offset + right] > arr[offset + largest])
            largest = right;

        if (largest != i)
        {
            Swap(arr, offset + i, offset + largest);
            Heapify(arr, n, largest, offset);
        }
    }

    static void InsertionSort(int[] arr, int low, int high)
    {
        for (int i = low + 1; i <= high; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= low && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
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

        IntroSort(arr);

        Console.WriteLine("After:");
        PrintArray(arr);
    }
}