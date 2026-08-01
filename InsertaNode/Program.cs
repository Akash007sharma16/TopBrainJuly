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

    public void InsertNode(int data)
    {
        Node node = new Node(data);

        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            tail.next = node;
            tail = node;
        }
    }

    public void PrintList()
    {
        Node current = head;

        while (current != null)
        {
            Console.Write(current.data + " ");
            current = current.next;
        }

        Console.WriteLine();
    }

    public void InsertAtPosition(int data, int position)
    {
        Node newNode = new Node(data);

        // Insert at the beginning
        if (position == 0)
        {
            newNode.next = head;
            head = newNode;

            if (tail == null)
                tail = newNode;

            return;
        }

        Node current = head;

        // Move to the node before the insertion position
        for (int i = 0; i < position - 1; i++)
        {
            current = current.next;
        }

        newNode.next = current.next;
        current.next = newNode;

        // Update tail if inserted at the end
        if (newNode.next == null)
            tail = newNode;
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList list = new LinkedList();

        Console.Write("Enter number of nodes: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the node values:");

        for (int i = 0; i < n; i++)
        {
            int value = int.Parse(Console.ReadLine());
            list.InsertNode(value);
        }

        Console.Write("Enter data to insert: ");
        int data = int.Parse(Console.ReadLine());

        Console.Write("Enter position: ");
        int position = int.Parse(Console.ReadLine());

        Console.WriteLine("\nOriginal List:");
        list.PrintList();

        list.InsertAtPosition(data, position);

        Console.WriteLine("List After Insertion:");
        list.PrintList();
    }
}