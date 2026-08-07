using System;

class Program
{
    static void HeadRecursion(int n)
    {
        if (n == 0)
            return;

        HeadRecursion(n - 1);
        Console.Write(n + " ");
    }

    static void TailRecursion(int n)
    {
        if (n == 0)
            return;

        Console.Write(n + " ");
        TailRecursion(n - 1);
    }

    static int TreeRecursion(int n)
    {
        if (n <= 1)
            return n;

        return TreeRecursion(n - 1) + TreeRecursion(n - 2);
    }

    static void IndirectA(int n)
    {
        if (n <= 0)
            return;

        Console.Write(n + " ");
        IndirectB(n - 1);
    }

    static void IndirectB(int n)
    {
        if (n <= 0)
            return;

        Console.Write(n + " ");
        IndirectA(n - 1);
    }

    static void Main()
    {
        Console.WriteLine("Head Recursion:");
        HeadRecursion(5);

        Console.WriteLine();

        Console.WriteLine("Tail Recursion:");
        TailRecursion(5);

        Console.WriteLine();

        Console.WriteLine("Tree Recursion:");
        Console.WriteLine(TreeRecursion(5));

        Console.WriteLine();

        Console.WriteLine("Indirect Recursion:");
        IndirectA(5);
    }
}