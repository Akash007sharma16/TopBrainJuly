using System;

class Node
{
    public int data;
    public Node left, right;

    public Node(int data)
    {
        this.data = data;
        left = null;
        right = null;
    }
}

class Program
{
    // Insert a node into the Binary Search Tree
    static Node Insert(Node root, int data)
    {
        if (root == null)
            return new Node(data);

        if (data <= root.data)
            root.left = Insert(root.left, data);
        else
            root.right = Insert(root.right, data);

        return root;
    }

    // Postorder Traversal (Left -> Right -> Root)
    static void PostOrder(Node root)
    {
        if (root == null)
            return;

        PostOrder(root.left);
        PostOrder(root.right);
        Console.Write(root.data + " ");
    }

    static void Main(string[] args)
    {
        Console.Write("Enter number of nodes: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter node values:");

        string[] input = Console.ReadLine().Split();

        Node root = null;

        for (int i = 0; i < n; i++)
        {
            root = Insert(root, int.Parse(input[i]));
        }

        Console.Write("\nPostorder Traversal: ");
        PostOrder(root);
        Console.WriteLine();
    }
}