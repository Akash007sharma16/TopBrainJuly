using System;

class Program
{
    static void Main()
    {
        int[] arr = {10,20,30,40,50};
        Console.WriteLine("Original Array");
        foreach(int num in arr)
        {
            Console.WriteLine(num + " ");
        }

        Array.Reverse(arr);

        Console.WriteLine("\n Reversed Array : ");
        foreach(int num in arr)
        {
            Console.Write(num + " ");
        }
    }
}