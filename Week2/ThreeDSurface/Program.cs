using System;
using System.Collections.Generic;

class Program
{
    static int SurfaceArea(int[,] A, int H, int W)
    {
        int area = 0;

        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                int h = A[i, j];

                area += 2 + 4 * h;

                if (i > 0)
                    area -= Math.Min(h, A[i - 1, j]);

                if (i < H - 1)
                    area -= Math.Min(h, A[i + 1, j]);

                if (j > 0)
                    area -= Math.Min(h, A[i, j - 1]);

                if (j < W - 1)
                    area -= Math.Min(h, A[i, j + 1]);
            }
        }

        return area;
    }

    static void Main()
    {
        string[] first = Console.ReadLine().Split();

        int H = int.Parse(first[0]);
        int W = int.Parse(first[1]);

        int[,] A = new int[H, W];

        for (int i = 0; i < H; i++)
        {
            string[] row = Console.ReadLine().Split();

            for (int j = 0; j < W; j++)
            {
                A[i, j] = int.Parse(row[j]);
            }
        }

        Console.WriteLine(SurfaceArea(A, H, W));
    }
}