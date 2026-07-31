using System;

class Program
{
    static void Main()
    {
        string[] orders =
        {
            "O101|Akash|Laptop|2|75000",
            "O102|Rahul|Mobile|1|25000",
            "O103|Priya|Headphones|3|2000",
            "O104|Neha|Keyboard|2|1500",
            "O105|Amit|Monitor|1|12000"
        };

        Console.WriteLine("Order Details\n");

        foreach (string order in orders)
        {
            string[] details = order.Split('|');

            Console.WriteLine("Order ID : " + details[0]);
            Console.WriteLine("Customer : " + details[1]);
            Console.WriteLine("Product  : " + details[2]);
            Console.WriteLine("Quantity : " + details[3]);
            Console.WriteLine("Price    : " + details[4]);
            Console.WriteLine();
        }

        Console.WriteLine("Search Order");

        string searchId = "O103";
        bool found = false;

        foreach (string order in orders)
        {
            string[] details = order.Split('|');

            if (details[0].Equals(searchId, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(order);
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Order Not Found");
        }

        Console.WriteLine("\nTotal Amount of Each Order");

        foreach (string order in orders)
        {
            string[] details = order.Split('|');

            int quantity = Convert.ToInt32(details[3]);
            int price = Convert.ToInt32(details[4]);

            Console.WriteLine(details[0] + " : " + (quantity * price));
        }

        Console.WriteLine("\nCustomer Names in Uppercase");

        foreach (string order in orders)
        {
            string[] details = order.Split('|');
            Console.WriteLine(details[1].ToUpper());
        }

        Console.WriteLine("\nProducts");

        foreach (string order in orders)
        {
            string[] details = order.Split('|');
            Console.WriteLine(details[2]);
        }
    }
}