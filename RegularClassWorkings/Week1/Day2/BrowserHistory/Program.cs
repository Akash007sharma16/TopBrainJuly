using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<string> History = new Stack<string>();

        int choice;
        do
        {
            Console.WriteLine("Browser History Management");
            Console.WriteLine("============================");
            Console.WriteLine("1. Visit Page");
            Console.WriteLine("2. Back");
            Console.WriteLine("3. Current Page");
            Console.WriteLine("4. Display History");
            Console.WriteLine("5. Clear History");
            Console.WriteLine("6. Total Pages");
            Console.WriteLine("7. Exit");

            Console.Write("Enter the choice : ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    Console.WriteLine("Enter the Website");
                    string page = Console.ReadLine();
                    History.Push(page);
                    Console.WriteLine("Page Visited Successfully !");
                    break;
                case 2:
                    if(History.Count > 0)
                    {
                        Console.WriteLine("Back From : "+ History.Pop());
                    }
                    else
                    {
                        Console.WriteLine("No History Found");
                    }
                    break;
                case 3:
                    if(History.Count > 0)
                    {
                        Console.WriteLine("Cuurent Page : "+ History.Peek());
                    }
                    else
                    {
                        Console.WriteLine("No Current Page");
                    }
                    break;
                case 4:
                    if(History.Count > 0)
                    {
                        Console.WriteLine("\n Browser History");
                        foreach(string item in History)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No History Found");
                    }
                    break;

                case 5:
                    History.Clear();
                    Console.WriteLine("History Cleared !");
                    break;
                
                case 6:
                    Console.WriteLine("Total History : "+ History.Count);
                    break;

                case 7:
                    Console.WriteLine("ThankYou");
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;

            }

        } while(choice !=7);
    }
}
