using System;
namespace Ecommerce
{
class Program
{
     static string[] orders =
        {
            "ORD1001|John Smith|Laptop|2|$1200|Delivered",
            "ORD1002|Alice Brown|Mobile|1|$800|Pending",
            "ORD1003|David Wilson|Keyboard|3|$150|Shipped",
            "ORD1004|Emma Davis|Monitor|2|$350|Delivered",
            "ORD1005|James Miller|Mouse|5|$50|Pending"
        };

      static void DisplayOrders()
        {
            Console.WriteLine("Task 1 : Display all orders Details ");
            foreach(string order in orders)
            {
                string[] data = order.Split('|');
                Console.WriteLine("order Id: "+data[0]);
                Console.WriteLine("Customer Name: "+data[1]);

                Console.WriteLine("Product : "+data[2]);
                Console.WriteLine("Quantity : "+data[3]);
                Console.WriteLine("Price :"+data[4]);
                Console.WriteLine("Status :"+data[5]);

                Console.WriteLine();
            }
        }

            
            static void DisplayUpperCaseCustomerNames()
            {
                Console.WriteLine("Task 2 : Customer Names in Uppercase\n");

                foreach (string order in orders)
                {
                    string[] data = order.Split('|');
                    Console.WriteLine(data[1].ToUpper());
                }
            }

            static void DisplayCustomerInitials()
            {
                Console.WriteLine("Task 3 : Customer Initials\n");

                foreach (string order in orders)
                {
                    string[] data = order.Split('|');

                    string[] names = data[1].Split(' ');

                    string initials = "";

                    foreach (string name in names)
                    {
                        initials += name.Substring(0, 1);
                    }

                    Console.WriteLine(data[1] + " -> " + initials);
                }
            }

            static void DisplayDeliveredOrders()
            {
                Console.WriteLine("Task 4 : Delivered  Orders");

                foreach(string order in orders)
                {
                    if(order.Contains("Delivered"))
                    {
                    string[] data = order.Split('|');
                    Console.WriteLine("OrderId :  "+data[0]);
                    Console.WriteLine("Customer Name : "+data[1]);
                    Console.WriteLine("Product : "+data[2]);
                    Console.WriteLine("Quantity      : " + data[3]);
                    Console.WriteLine("Price         : " + data[4]);
                    Console.WriteLine("Status        : " + data[5]);
                    Console.WriteLine();
                    }
                }
            }
            static void SearchByOrderId( string OrderId)
            {
                Console.WriteLine("Task  5 :  Search Order By Id");
                bool found = false;
                foreach(string order in orders)
            {
                if(order.StartsWith(OrderId))
                {
                    string[] data = order.Split('|');
                    Console.WriteLine("Order Found");
                    Console.WriteLine("OrderId : "+data[0]);
                    Console.WriteLine("Customer Name : "+data[1]);
                    Console.WriteLine("Product : "+data[2]);
                    Console.WriteLine("Quantity      : " + data[3]);
                    Console.WriteLine("Price         : " + data[4]);
                    Console.WriteLine("Status        : " + data[5]);
                    Console.WriteLine();

                    found = true;
                    break;
                }
            }
            if(!found)
            {
                Console.WriteLine("Order not Found");
            }
            }
            static void CountOrders()
            {
                Console.WriteLine("Task 5 : Count Total Orders ");
                Console.WriteLine("Total Orders : "+orders.Length);
            }
            static void Main(string[] args)
            {
                DisplayOrders();
                DisplayUpperCaseCustomerNames();
                DisplayCustomerInitials();
                DisplayDeliveredOrders();
                // Console.Write("Enter the OrderId You want to search ");
                // string id = Console.ReadLine();
                // SearchByOrderId(id);
                SearchByOrderId("ORD1001");
                CountOrders();
                Console.ReadKey();
            }


        
    }
}