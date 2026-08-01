using System;

class Node
{
    public int data;
    public Node next;

    public Node(int value)
    {
        data = value;
        next = null;
    }
}

class LinkedList
{
    public Node head;

    // Insert at Head
    public void InsertAtHead(int value)
    {
        Node newNode = new Node(value);

        newNode.next = head;
        head = newNode;
    }

    // Display Linked List
    public void Display()
    {
        Node temp = head;

        while (temp != null)
        {
            Console.Write(temp.data + " ");
            temp = temp.next;
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList list = new LinkedList();

        Console.Write("Enter number of nodes: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter node values:");

        for (int i = 0; i < n; i++)
        {
            int value = Convert.ToInt32(Console.ReadLine());
            list.InsertAtHead(value);
        }

        Console.WriteLine("\nLinked List after inserting at head:");
        list.Display();
    }
}