using System;

class Program
{
    static int CountPaths(int rows, int cols)
    {
        if (rows == 1 || cols == 1)
            return 1;

        return CountPaths(rows - 1, cols) + CountPaths(rows, cols - 1);
    }

    static void Main(string[] args)
    {
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int cols = int.Parse(Console.ReadLine());

        int result = CountPaths(rows, cols);

        Console.WriteLine("Total Paths = " + result);
    }
}