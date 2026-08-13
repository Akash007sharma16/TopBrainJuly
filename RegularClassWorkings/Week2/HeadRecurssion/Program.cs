using System;

class Program
{
    static void SumDigitsReversed(int n)
    {
        if (n == 0)
            return;

        Console.Write(n % 10 + " ");
        SumDigitsReversed(n / 10);
    }

    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        if (n == 0)
        {
            Console.WriteLine(0);
        }
        else
        {
            SumDigitsReversed(n);
        }
    }
}
