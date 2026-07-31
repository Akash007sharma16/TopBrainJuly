using System;
using System.Collections.Generic;

class CourseGraph
{
    private readonly List<int>[] graph;
    private readonly int totalCourses;

    public CourseGraph(int numberOfCourses)
    {
        totalCourses = numberOfCourses;
        graph = new List<int>[numberOfCourses];

        for (int i = 0; i < numberOfCourses; i++)
        {
            graph[i] = new List<int>();
        }
    }

    // Adds a prerequisite relationship
    public void AddPrerequisite(int prerequisite, int course)
    {
        graph[prerequisite].Add(course);
    }

    // Displays the graph
    public void DisplayGraph()
    {
        Console.WriteLine("Course Dependency Graph\n");

        for (int i = 0; i < totalCourses; i++)
        {
            Console.Write("Course " + i + " -> ");

            foreach (int course in graph[i])
            {
                Console.Write(course + " ");
            }

            Console.WriteLine();
        }
    }

    // Finds all prerequisites for a given course
    public void ShowAllPrerequisites(int course)
    {
        bool[] visited = new bool[totalCourses];

        Console.WriteLine("\nAll prerequisites for Course " + course + ":");

        FindPrerequisites(course, visited);
    }

    private void FindPrerequisites(int course, bool[] visited)
    {
        for (int i = 0; i < totalCourses; i++)
        {
            if (graph[i].Contains(course) && !visited[i])
            {
                visited[i] = true;
                Console.WriteLine("Course " + i);

                FindPrerequisites(i, visited);
            }
        }
    }

    // Shows only direct prerequisites
    public void ShowDirectPrerequisites(int course)
    {
        Console.WriteLine("\nDirect prerequisites for Course " + course + ":");

        bool found = false;

        for (int i = 0; i < totalCourses; i++)
        {
            if (graph[i].Contains(course))
            {
                Console.WriteLine("Course " + i);
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No direct prerequisites.");
        }
    }

    // Cycle detection
    public bool ContainsCycle()
    {
        bool[] visited = new bool[totalCourses];
        bool[] recursionStack = new bool[totalCourses];

        for (int i = 0; i < totalCourses; i++)
        {
            if (IsCyclePresent(i, visited, recursionStack))
            {
                return true;
            }
        }

        return false;
    }

    private bool IsCyclePresent(int currentCourse, bool[] visited, bool[] recursionStack)
    {
        if (recursionStack[currentCourse])
        {
            return true;
        }

        if (visited[currentCourse])
        {
            return false;
        }

        visited[currentCourse] = true;
        recursionStack[currentCourse] = true;

        foreach (int nextCourse in graph[currentCourse])
        {
            if (IsCyclePresent(nextCourse, visited, recursionStack))
            {
                return true;
            }
        }

        recursionStack[currentCourse] = false;

        return false;
    }

    // Topological Sort
    public void DisplayCourseOrder()
    {
        int[] inDegree = new int[totalCourses];

        for (int i = 0; i < totalCourses; i++)
        {
            foreach (int course in graph[i])
            {
                inDegree[course]++;
            }
        }

        Queue<int> readyCourses = new Queue<int>();

        for (int i = 0; i < totalCourses; i++)
        {
            if (inDegree[i] == 0)
            {
                readyCourses.Enqueue(i);
            }
        }

        Console.WriteLine("\nRecommended Course Order:");

        while (readyCourses.Count > 0)
        {
            int currentCourse = readyCourses.Dequeue();

            Console.Write(currentCourse + " ");

            foreach (int nextCourse in graph[currentCourse])
            {
                inDegree[nextCourse]--;

                if (inDegree[nextCourse] == 0)
                {
                    readyCourses.Enqueue(nextCourse);
                }
            }
        }

        Console.WriteLine();
    }

    // Courses that can be taken first
    public void DisplayCoursesWithoutPrerequisites()
    {
        int[] inDegree = new int[totalCourses];

        for (int i = 0; i < totalCourses; i++)
        {
            foreach (int course in graph[i])
            {
                inDegree[course]++;
            }
        }

        Console.WriteLine("\nCourses with no prerequisites:");

        for (int i = 0; i < totalCourses; i++)
        {
            if (inDegree[i] == 0)
            {
                Console.WriteLine("Course " + i);
            }
        }
    }

    // Count direct dependent courses
    public void CountDependentCourses(int course)
    {
        Console.WriteLine("\nCourses directly depending on Course " + course + ": " + graph[course].Count);
    }
}

class Program
{
    static void Main()
    {
        CourseGraph courseGraph = new CourseGraph(6);

        // Prerequisite relationships
        courseGraph.AddPrerequisite(0, 1);
        courseGraph.AddPrerequisite(0, 2);
        courseGraph.AddPrerequisite(1, 3);
        courseGraph.AddPrerequisite(2, 3);
        courseGraph.AddPrerequisite(2, 4);
        courseGraph.AddPrerequisite(3, 5);
        courseGraph.AddPrerequisite(4, 5);

        courseGraph.DisplayGraph();

        courseGraph.ShowAllPrerequisites(5);

        courseGraph.ShowDirectPrerequisites(3);

        Console.WriteLine("\nCycle Found : " + courseGraph.ContainsCycle());

        if (!courseGraph.ContainsCycle())
        {
            courseGraph.DisplayCourseOrder();
        }

        courseGraph.DisplayCoursesWithoutPrerequisites();

        courseGraph.CountDependentCourses(2);

        Console.ReadKey();
    }
}