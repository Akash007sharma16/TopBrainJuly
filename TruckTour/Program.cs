using System;
using System.Collections.Generic;

class Program
{
    static int TruckTour(List<List<int>> petrolPumps)
    {
        int start = 0;
        long balance = 0;
        long deficit = 0;

        for (int i = 0; i < petrolPumps.Count; i++)
        {
            balance += petrolPumps[i][0] - petrolPumps[i][1];

            if (balance < 0)
            {
                start = i + 1;
                deficit += balance;
                balance = 0;
            }
        }

        if (balance + deficit >= 0)
            return start;
        else
            return -1;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter number of petrol pumps: ");
        int n = int.Parse(Console.ReadLine());

        List<List<int>> petrolPumps = new List<List<int>>();

        Console.WriteLine("Enter petrol and distance for each pump:");

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();

            int petrol = int.Parse(input[0]);
            int distance = int.Parse(input[1]);

            petrolPumps.Add(new List<int> { petrol, distance });
        }

        int result = TruckTour(petrolPumps);

        Console.WriteLine("\nStarting Petrol Pump Index: " + result);
    }
}