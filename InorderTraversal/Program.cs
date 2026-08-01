using System;

class Node
{
    public int data;
    public Node left;
    public Node right;

    public Node(int data)
    {
        this.data = data;
        left = null;
        right = null;
    }
}

class Program
{
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

    static void InOrder(Node root)
    {
        if (root == null)
            return;

        InOrder(root.left);
        Console.Write(root.data + " ");
        InOrder(root.right);
    }

    static void Main()
    {
        int[] arr = { 1, 2, 5, 3, 6, 4 };

        Node root = null;

        foreach (int x in arr)
        {
            root = Insert(root, x);
        }

        Console.Write("Inorder Traversal: ");
        InOrder(root);
        Console.WriteLine();
    }
}