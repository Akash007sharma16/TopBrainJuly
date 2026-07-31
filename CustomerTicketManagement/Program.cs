using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] tickets =
        {
            "T001|John|Login Issue",
            "T002|Alice|Payment Failed",
            "T003|David|Account Locked",
            "T004|Emma|Refund Request",
            "T005|James|Password Reset"
        };

        Queue<string> ticketQueue = new Queue<string>();

        foreach (string ticket in tickets)
        {
            ticketQueue.Enqueue(ticket);
        }

        Console.WriteLine("Task 1 : Enqueue Tickets");
        foreach (string ticket in ticketQueue)
        {
            Console.WriteLine(ticket);
        }

        Console.WriteLine("\nTask 2 : Display All Tickets");
        foreach (string ticket in ticketQueue)
        {
            Console.WriteLine(ticket);
        }

        Console.WriteLine("\nTask 3 : Process First Ticket");

        if (ticketQueue.Count > 0)
        {
            Console.WriteLine(ticketQueue.Dequeue());
        }

        Console.WriteLine("\nTask 4 : View Next Ticket");

        if (ticketQueue.Count > 0)
        {
            Console.WriteLine(ticketQueue.Peek());
        }

        Console.WriteLine("\nTask 5 : Queue Count");
        Console.WriteLine(ticketQueue.Count);

        Console.WriteLine("\nTask 6 : Search Ticket By ID");

        string searchId = "T004";
        bool found = false;

        foreach (string ticket in ticketQueue)
        {
            string[] details = ticket.Split('|');

            if (details[0] == searchId)
            {
                Console.WriteLine(ticket);
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Ticket Not Found");
        }

        Console.WriteLine("\nTask 7 : Count Tickets By Issue Type");

        Dictionary<string, int> issueCount = new Dictionary<string, int>();

        foreach (string ticket in ticketQueue)
        {
            string[] details = ticket.Split('|');
            string issue = details[2];

            if (issueCount.ContainsKey(issue))
            {
                issueCount[issue]++;
            }
            else
            {
                issueCount[issue] = 1;
            }
        }

        foreach (var item in issueCount)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }
    }
}