using System;
using System.Collections.Generic;

class Program
{
    static long AVeryBigSum(List<long> ar)
    {
        long sum = 0;

        foreach (long num in ar)
        {
            sum += num;
        }

        return sum;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string[] input = Console.ReadLine().Split();

        List<long> ar = new List<long>();

        for (int i = 0; i < n; i++)
        {
            ar.Add(long.Parse(input[i]));
        }

        long result = AVeryBigSum(ar);

        Console.WriteLine(result);
    }
}
