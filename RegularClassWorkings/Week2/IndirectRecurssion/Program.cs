using System;

class Program
{
    static bool IsPositiveChain(int n)
    {
        if (n == 0)
            return true;

        if (n < 0)
            return false;

        return IsNegativeChain(n - 1);
    }

    static bool IsNegativeChain(int n)
    {
        if (n == 0)
            return true;

        if (n > 0)
            return false;

        return IsPositiveChain(n + 1);
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        bool result;

        if (n >= 0)
            result = IsPositiveChain(n);
        else
            result = IsNegativeChain(n);

        Console.WriteLine(result);
    }
}
