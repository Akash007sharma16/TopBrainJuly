using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<int> ReverseArray(List<int> numbers)
    {
        List<int> reversedArray = new List<int>();

        for (int i = numbers.Count - 1; i >= 0; i--)
        {
            reversedArray.Add(numbers[i]);
        }

        return reversedArray;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter the number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the array elements separated by space: ");
        List<int> numbers = Console.ReadLine()
                                   .Split(' ')
                                   .Select(int.Parse)
                                   .ToList();

        List<int> result = ReverseArray(numbers);

        Console.WriteLine("\nReversed Array:");

        foreach (int number in result)
        {
            Console.Write(number + " ");
        }

        Console.WriteLine();
    }
}