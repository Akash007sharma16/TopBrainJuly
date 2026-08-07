using System;
using System.Collections.Generic;

class Program
{
    static List<int> IcecreamParlor(int m, List<int> arr)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < arr.Count; i++)
        {
            int complement = m - arr[i];

            if (map.ContainsKey(complement))
            {
                return new List<int> { map[complement] + 1, i + 1 };
            }

            if (!map.ContainsKey(arr[i]))
            {
                map[arr[i]] = i;
            }
        }

        return new List<int>();
    }

    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());

        while (t-- > 0)
        {
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            List<int> arr = new List<int>();

            string[] input = Console.ReadLine().Split(' ');

            for (int i = 0; i < n; i++)
            {
                arr.Add(int.Parse(input[i]));
            }

            List<int> result = IcecreamParlor(m, arr);

            Console.WriteLine(result[0] + " " + result[1]);
        }
    }
}