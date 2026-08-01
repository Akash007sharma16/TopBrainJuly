using System;

class Node
{
    public int data;
    public Node next;

    public Node(int data)
    {
        this.data = data;
        next = null;
    }
}

class LinkedList
{
    public Node head;
    public Node tail;

    // Insert at Tail
    public void InsertAtTail(int data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.next = newNode;
            tail = newNode;
        }
    }

    // Display the Linked List
    public void Display()
    {
        Node current = head;

        while (current != null)
        {
            Console.Write(current.data + " ");
            current = current.next;
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList list = new LinkedList();

        Console.Write("Enter the number of nodes: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the node values:");

        for (int i = 0; i < n; i++)
        {
            int value = int.Parse(Console.ReadLine());
            list.InsertAtTail(value);
        }

        Console.WriteLine("\nLinked List:");

        list.Display();
    }
}