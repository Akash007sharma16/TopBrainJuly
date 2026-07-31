using System;
using System.Collections.Generic;

class SocialNetwork
{
    private readonly List<int>[] friends;
    private readonly int totalUsers;

    public SocialNetwork(int numberOfUsers)
    {
        totalUsers = numberOfUsers;
        friends = new List<int>[numberOfUsers];

        for (int i = 0; i < numberOfUsers; i++)
        {
            friends[i] = new List<int>();
        }
    }

    public void AddFriendship(int user1, int user2)
    {
        friends[user1].Add(user2);
        friends[user2].Add(user1);
    }

    public void DisplayFriends(int user)
    {
        Console.Write("Friends of User " + user + ": ");

        foreach (int friend in friends[user])
        {
            Console.Write(friend + " ");
        }

        Console.WriteLine();
    }

    public bool AreConnected(int startUser, int endUser)
    {
        bool[] visited = new bool[totalUsers];

        return SearchConnection(startUser, endUser, visited);
    }

    private bool SearchConnection(int currentUser, int targetUser, bool[] visited)
    {
        if (currentUser == targetUser)
        {
            return true;
        }

        visited[currentUser] = true;

        foreach (int friend in friends[currentUser])
        {
            if (!visited[friend])
            {
                if (SearchConnection(friend, targetUser, visited))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void FindShortestPath(int startUser, int endUser)
    {
        bool[] visited = new bool[totalUsers];
        int[] parent = new int[totalUsers];

        for (int i = 0; i < totalUsers; i++)
        {
            parent[i] = -1;
        }

        Queue<int> queue = new Queue<int>();

        queue.Enqueue(startUser);
        visited[startUser] = true;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            foreach (int friend in friends[current])
            {
                if (!visited[friend])
                {
                    visited[friend] = true;
                    parent[friend] = current;
                    queue.Enqueue(friend);
                }
            }
        }

        if (!visited[endUser])
        {
            Console.WriteLine("\nNo path exists.");
            return;
        }

        Stack<int> path = new Stack<int>();

        int temp = endUser;

        while (temp != -1)
        {
            path.Push(temp);
            temp = parent[temp];
        }

        Console.Write("\nShortest Path: ");

        while (path.Count > 0)
        {
            Console.Write(path.Pop());

            if (path.Count > 0)
            {
                Console.Write(" -> ");
            }
        }

        Console.WriteLine();
    }

    public void UsersAtDistanceTwo(int user)
    {
        bool[] visited = new bool[totalUsers];
        Queue<(int user, int distance)> queue = new Queue<(int, int)>();

        visited[user] = true;
        queue.Enqueue((user, 0));

        Console.Write("\nUsers at distance 2 from User " + user + ": ");

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.distance == 2)
            {
                Console.Write(current.user + " ");
                continue;
            }

            foreach (int friend in friends[current.user])
            {
                if (!visited[friend])
                {
                    visited[friend] = true;
                    queue.Enqueue((friend, current.distance + 1));
                }
            }
        }

        Console.WriteLine();
    }

    public bool HasCycle()
    {
        bool[] visited = new bool[totalUsers];

        for (int i = 0; i < totalUsers; i++)
        {
            if (!visited[i])
            {
                if (DetectCycle(i, visited, -1))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool DetectCycle(int current, bool[] visited, int parent)
    {
        visited[current] = true;

        foreach (int friend in friends[current])
        {
            if (!visited[friend])
            {
                if (DetectCycle(friend, visited, current))
                {
                    return true;
                }
            }
            else if (friend != parent)
            {
                return true;
            }
        }

        return false;
    }

    public void DisplayFriendGroups()
    {
        bool[] visited = new bool[totalUsers];

        Console.WriteLine("\nConnected Components:");

        for (int i = 0; i < totalUsers; i++)
        {
            if (!visited[i])
            {
                PrintComponent(i, visited);
                Console.WriteLine();
            }
        }
    }

    private void PrintComponent(int user, bool[] visited)
    {
        visited[user] = true;

        Console.Write(user + " ");

        foreach (int friend in friends[user])
        {
            if (!visited[friend])
            {
                PrintComponent(friend, visited);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        SocialNetwork network = new SocialNetwork(6);

        network.AddFriendship(0, 1);
        network.AddFriendship(0, 2);
        network.AddFriendship(1, 3);
        network.AddFriendship(2, 3);
        network.AddFriendship(2, 4);
        network.AddFriendship(3, 5);
        network.AddFriendship(4, 5);

        network.DisplayFriends(2);

        Console.WriteLine("\nUser 0 and User 5 Connected : " +
                          network.AreConnected(0, 5));

        network.FindShortestPath(0, 5);

        network.UsersAtDistanceTwo(1);

        Console.WriteLine("\nCycle Present : " + network.HasCycle());

        network.DisplayFriendGroups();

        Console.ReadKey();
    }
}