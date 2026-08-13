using System;
using System.Collections.Generic;

namespace CustomerSupport
{
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

            foreach (string ticket in ticketQueue)
            {
                string[] data = ticket.Split('|');
                Console.WriteLine(data[0]);
            }

            string firstTicket = ticketQueue.Peek();
            string[] details = firstTicket.Split('|');

            Console.WriteLine("The First Ticket is : "+details[0]);
            Console.ReadKey();
        }
    }
}
