using System;
using System.Threading.Tasks;

class Program
{
    static void ParallelQuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivot = Partition(arr, low, high);

            // Sort left and right partitions in parallel
            Parallel.Invoke(
                () => ParallelQuickSort(arr, low, pivot - 1),
                () => ParallelQuickSort(arr, pivot + 1, high)
            );
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
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

        ParallelQuickSort(arr, 0, arr.Length - 1);

        Console.WriteLine("After:");
        PrintArray(arr);
    }
}