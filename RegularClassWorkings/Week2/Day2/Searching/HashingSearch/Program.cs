using System;
using System.Collections.Generic;

class Program
{
    static int HashingSearch(int[] arr, int key)
    {
        Dictionary<int, int> hashTable = new Dictionary<int, int>();

        // Store each element and its index
        for (int i = 0; i < arr.Length; i++)
        {
            if (!hashTable.ContainsKey(arr[i]))
            {
                hashTable.Add(arr[i], i);
            }
        }

        // Search for the key
        if (hashTable.ContainsKey(key))
        {
            return hashTable[key];
        }

        return -1;
    }

    static void Main()
    {
        int[] arr = { 29, 4, 71, 15, 92, 8, 46, 33, 60, 1 };
        int key = 46;

        int index = HashingSearch(arr, key);

        if (index != -1)
            Console.WriteLine($"Element {key} found at index {index}");
        else
            Console.WriteLine("Element not found");
    }
}