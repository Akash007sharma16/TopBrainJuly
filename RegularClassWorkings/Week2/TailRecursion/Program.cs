using System;

namespace TailRecursionFactorial
{
    class Program
    {
        static long Factorial(int n, long accumulator = 1)
        {
            if (n < 0)
            {
                Console.WriteLine("Factorial is not defined for negative numbers.");
                return -1;
            }

            if (n == 0 || n == 1)
            {
                return accumulator;
            }

            return Factorial(n - 1, accumulator * n);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int n = int.Parse(Console.ReadLine());

            long result = Factorial(n);

            if (result != -1)
            {
                Console.WriteLine("Factorial of " + n + " is " + result);
            }
        }
    }
}
