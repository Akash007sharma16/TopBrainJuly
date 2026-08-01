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
    // Insert node into BST
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

    // Preorder Traversal
    static void PreOrder(Node root)
    {
        if (root == null)
            return;

        Console.Write(root.data + " ");
        PreOrder(root.left);
        PreOrder(root.right);
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

        Console.Write("\nPreorder Traversal: ");
        PreOrder(root);

        Console.WriteLine();
    }
}