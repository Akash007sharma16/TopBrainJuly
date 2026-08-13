using System;

class Node
{
    public int Data;
    public Node Left;
    public Node Right;

    public Node(int data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

class BinaryTree
{
    Node root;

    public BinaryTree()
    {
        root = null;
    }

    public void CreateTree()
    {
        root = new Node(10);

        root.Left = new Node(20);
        root.Right = new Node(30);

        root.Left.Left = new Node(40);
        root.Left.Right = new Node(50);

        root.Right.Left = new Node(60);
        root.Right.Right = new Node(70);
    }

    public void Inorder(Node node)
    {
        if (node != null)
        {
            Inorder(node.Left);
            Console.Write(node.Data + " ");
            Inorder(node.Right);
        }
    }

    public void Preorder(Node node)
    {
        if (node != null)
        {
            Console.Write(node.Data + " ");
            Preorder(node.Left);
            Preorder(node.Right);
        }
    }

    public void Postorder(Node node)
    {
        if (node != null)
        {
            Postorder(node.Left);
            Postorder(node.Right);
            Console.Write(node.Data + " ");
        }
    }

    public void Display()
    {
        Console.WriteLine("Inorder Traversal:");
        Inorder(root);

        Console.WriteLine();

        Console.WriteLine("Preorder Traversal:");
        Preorder(root);

        Console.WriteLine();

        Console.WriteLine("Postorder Traversal:");
        Postorder(root);

        Console.WriteLine();
    }

    static void Main()
    {
        BinaryTree tree = new BinaryTree();

        tree.CreateTree();

        tree.Display();

        Console.ReadKey();
    }
}
