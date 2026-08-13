using System;
using System.Collections.Generic;

class Program
{
    static long GridlandMetro(int n, int m, int k, List<List<int>> track)
    {
        Dictionary<int, List<int[]>> map = new Dictionary<int, List<int[]>>();

        foreach (var t in track)
        {
            int row = t[0];
            if (!map.ContainsKey(row))
                map[row] = new List<int[]>();
            map[row].Add(new int[] { t[1], t[2] });
        }

        long occupied = 0;

        foreach (var row in map)
        {
            List<int[]> intervals = row.Value;
            intervals.Sort((a, b) => a[0] == b[0] ? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0]));

            long left = intervals[0][0];
            long right = intervals[0][1];

            for (int i = 1; i < intervals.Count; i++)
            {
                if (intervals[i][0] <= right)
                    right = Math.Max(right, intervals[i][1]);
                else
                {
                    occupied += right - left + 1;
                    left = intervals[i][0];
                    right = intervals[i][1];
                }
            }
            occupied += right - left + 1;
        }

        return (long)n * m - occupied;
    }

    static void Main()
    {
        string[] first = Console.ReadLine().Split();
        int n = int.Parse(first[0]);
        int m = int.Parse(first[1]);
        int k = int.Parse(first[2]);

        List<List<int>> track = new List<List<int>>();
        for (int i = 0; i < k; i++)
        {
            string[] input = Console.ReadLine().Split();
            track.Add(new List<int> { int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]) });
        }

        Console.WriteLine(GridlandMetro(n, m, k, track));
    }
}
