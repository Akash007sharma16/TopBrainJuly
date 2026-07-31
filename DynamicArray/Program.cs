using System;
using System.Collections.Generic;

class Program
{
    static List<int> DynamicArray(int n, List<List<int>> queries)
    {
        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(new List<int>());
        }

        List<int> result = new List<int>();
        int lastAnswer = 0;

        foreach (List<int> query in queries)
        {
            int type = query[0];
            int x = query[1];
            int y = query[2];

            int index = (x ^ lastAnswer) % n;

            if (type == 1)
            {
                arr[index].Add(y);
            }
            else if (type == 2)
            {
                lastAnswer = arr[index][y % arr[index].Count];
                result.Add(lastAnswer);
            }
        }

        return result;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter n and q: ");
        string[] input = Console.ReadLine().Split(' ');

        int n = int.Parse(input[0]);
        int q = int.Parse(input[1]);

        List<List<int>> queries = new List<List<int>>();

        Console.WriteLine("Enter the queries:");

        for (int i = 0; i < q; i++)
        {
            string[] queryInput = Console.ReadLine().Split(' ');

            List<int> query = new List<int>();

            foreach (string value in queryInput)
            {
                query.Add(int.Parse(value));
            }

            queries.Add(query);
        }

        List<int> answer = DynamicArray(n, queries);

        Console.WriteLine("\nOutput:");

        foreach (int value in answer)
        {
            Console.WriteLine(value);
        }
    }
}