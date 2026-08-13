using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<string> patients = new Queue<string>();
        int choice;

        do
        {
            Console.WriteLine("Hospital Queue Management System");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Register Patient");
            Console.WriteLine("2. Call Next Patient");
            Console.WriteLine("3. View Next Patient");
            Console.WriteLine("4. Display Waiting Patients");
            Console.WriteLine("5. Search Patient");
            Console.WriteLine("6. Count Waiting Patients");
            Console.WriteLine("7. Exit");

            Console.Write("Enter Choice : ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Patient Name : ");
                    string patient = Console.ReadLine();
                    patients.Enqueue(patient);
                    Console.WriteLine("Patient Registered Successfully.");
                    break;

                case 2:
                    if (patients.Count > 0)
                    {
                        Console.WriteLine("Calling : " + patients.Dequeue());
                    }
                    else
                    {
                        Console.WriteLine("No Patients Waiting.");
                    }
                    break;

                case 3:
                    if (patients.Count > 0)
                    {
                        Console.WriteLine("Next Patient : " + patients.Peek());
                    }
                    else
                    {
                        Console.WriteLine("Queue Empty.");
                    }
                    break;

                case 4:
                    if (patients.Count > 0)
                    {
                        Console.WriteLine("\nWaiting Patients");
                        foreach (string p in patients)
                        {
                            Console.WriteLine(p);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Patients Waiting.");
                    }
                    break;

                case 5:
                    Console.Write("Enter Patient Name : ");
                    string search = Console.ReadLine();

                    if (patients.Contains(search))
                    {
                        Console.WriteLine("Patient Found.");
                    }
                    else
                    {
                        Console.WriteLine("Patient Not Found.");
                    }
                    break;

                case 6:
                    Console.WriteLine("Total Waiting Patients : " + patients.Count);
                    break;

                case 7:
                    Console.WriteLine("Thank You");
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

        } while (choice != 7);
    }
}
