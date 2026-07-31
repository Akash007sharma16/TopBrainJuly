using System;
using System.Collections.Generic;
using System.Linq;

class Result
{
    public static List<int> reverseArray(List<int> a)
    {
        List<int> result = new List<int>();

        for (int i = a.Count - 1; i >= 0; i--)
        {
            result.Add(a[i]);
        }

        return result;
    }
}

class Solution
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of elements: ");
        int arrCount = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter array elements: ");
        List<int> arr = Console.ReadLine()
                               .Split(' ')
                               .Select(int.Parse)
                               .ToList();

        List<int> result = Result.reverseArray(arr);

        Console.WriteLine("Reversed Array:");
        Console.WriteLine(string.Join(" ", result));
    }
}