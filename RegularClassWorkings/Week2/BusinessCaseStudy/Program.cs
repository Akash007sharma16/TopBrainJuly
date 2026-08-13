using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Designation { get; set; }
    public string Department { get; set; }
    public int ManagerId { get; set; }

    public Employee(int id, string name, string designation, string department, int managerId)
    {
        Id = id;
        Name = name;
        Designation = designation;
        Department = department;
        ManagerId = managerId;
    }
}

class Program
{
    static List<Employee> employees = new List<Employee>
    {
        new Employee(1001, "John Smith", "CEO", "Management", 0),
        new Employee(1002, "Michael Johnson", "IT Manager", "IT", 1001),
        new Employee(1003, "Sarah Williams", "HR Manager", "HR", 1001),
        new Employee(1004, "David Brown", "Finance Manager", "Finance", 1001),
        new Employee(1005, "Robert Davis", "Team Lead", "IT", 1002),
        new Employee(1006, "Jennifer Miller", "QA Lead", "IT", 1002),
        new Employee(1007, "William Wilson", "Senior Developer", "IT", 1005),
        new Employee(1008, "Emma Moore", "Senior Developer", "IT", 1005),
        new Employee(1009, "Daniel Taylor", "QA Engineer", "IT", 1006),
        new Employee(1010, "Sophia Anderson", "QA Engineer", "IT", 1006),
        new Employee(1011, "James Thomas", "Recruiter", "HR", 1003),
        new Employee(1012, "Olivia Jackson", "Recruiter", "HR", 1003),
        new Employee(1013, "Benjamin White", "Accountant", "Finance", 1004),
        new Employee(1014, "Charlotte Harris", "Accountant", "Finance", 1004),
        new Employee(1015, "Lucas Martin", "Developer", "IT", 1007),
        new Employee(1016, "Ethan Walker", "Developer", "IT", 1007),
        new Employee(1017, "Mia Hall", "UI Developer", "IT", 1008),
        new Employee(1018, "Alexander Young", "Business Analyst", "IT", 1005),
        new Employee(1019, "Harper King", "HR Executive", "HR", 1011),
        new Employee(1020, "Jack Scott", "Finance Executive", "Finance", 1013)
    };

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("ABC TECHNOLOGIES");
            Console.WriteLine("Organization Hierarchy Management System");
            Console.WriteLine("==========================================");
            Console.WriteLine();
            Console.WriteLine("1. Display Complete Organization Chart");
            Console.WriteLine("2. Find Employee by ID");
            Console.WriteLine("3. Find Employee by Name");
            Console.WriteLine("4. Display Employees under a Manager");
            Console.WriteLine("5. Count Total Employees under a Manager");
            Console.WriteLine("6. Display Hierarchy Level");
            Console.WriteLine("7. Exit");
            Console.Write("\nEnter your Choice : ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
                continue;

            Console.WriteLine();

            switch (choice)
            {
                case 1: DisplayOrganization(); break;
                case 2: FindEmployeeById(); break;
                case 3: FindEmployeeByName(); break;
                case 4: DisplayEmployeesUnderManager(); break;
                case 5: CountEmployeesUnderManager(); break;
                case 6: DisplayHierarchyLevel(); break;
                case 7: return;
                default: Console.WriteLine("Invalid Choice."); break;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }

    static void DisplayOrganization()
    {
        Employee ceo = employees.FirstOrDefault(e => e.ManagerId == 0);
        if (ceo != null) PrintHierarchy(ceo, "", true);
    }

    static void PrintHierarchy(Employee manager, string indent, bool last)
    {
        if (indent == "")
            Console.WriteLine($"{manager.Name} ({manager.Designation})");
        else
            Console.WriteLine(indent + (last ? "└── " : "├── ") + $"{manager.Name} ({manager.Designation})");

        List<Employee> team = employees.Where(e => e.ManagerId == manager.Id).ToList();
        for (int i = 0; i < team.Count; i++)
        {
            string newIndent = indent + (last ? "    " : "│   ");
            PrintHierarchy(team[i], newIndent, i == team.Count - 1);
        }
    }

    static void FindEmployeeById()
    {
        Console.Write("Enter Employee ID : ");
        int id = int.Parse(Console.ReadLine());
        Employee emp = employees.FirstOrDefault(e => e.Id == id);
        if (emp == null) { Console.WriteLine("Employee not found."); return; }
        Console.WriteLine($"ID : {emp.Id}");
        Console.WriteLine($"Name : {emp.Name}");
        Console.WriteLine($"Designation : {emp.Designation}");
        Console.WriteLine($"Department : {emp.Department}");
    }

    static void FindEmployeeByName()
    {
        Console.Write("Enter Employee Name : ");
        string name = Console.ReadLine();
        Employee emp = employees.FirstOrDefault(e => e.Name.ToLower().Contains(name.ToLower()));
        if (emp == null) { Console.WriteLine("Employee not found."); return; }
        Console.WriteLine($"ID : {emp.Id}");
        Console.WriteLine($"Name : {emp.Name}");
        Console.WriteLine($"Designation : {emp.Designation}");
        Console.WriteLine($"Department : {emp.Department}");
    }

    static void DisplayEmployeesUnderManager()
    {
        Console.Write("Enter Manager ID : ");
        int id = int.Parse(Console.ReadLine());
        Employee manager = employees.FirstOrDefault(e => e.Id == id);
        if (manager == null) { Console.WriteLine("Manager not found."); return; }
        Console.WriteLine($"\nEmployees under {manager.Name}:\n");
        ShowSubordinates(id, 1);
    }

    static void ShowSubordinates(int managerId, int level)
    {
        List<Employee> team = employees.Where(e => e.ManagerId == managerId).ToList();
        foreach (Employee emp in team)
        {
            Console.WriteLine(new string(' ', level * 4) + $"{emp.Name} ({emp.Designation})");
            ShowSubordinates(emp.Id, level + 1);
        }
    }

    static void CountEmployeesUnderManager()
    {
        Console.Write("Enter Manager ID : ");
        int id = int.Parse(Console.ReadLine());
        Employee manager = employees.FirstOrDefault(e => e.Id == id);
        if (manager == null) { Console.WriteLine("Manager not found."); return; }
        int count = CountSubordinates(id);
        Console.WriteLine($"Total Employees under {manager.Name} : {count}");
    }

    static int CountSubordinates(int managerId)
    {
        int count = 0;
        List<Employee> team = employees.Where(e => e.ManagerId == managerId).ToList();
        foreach (Employee emp in team) { count++; count += CountSubordinates(emp.Id); }
        return count;
    }

    static void DisplayHierarchyLevel()
    {
        Console.Write("Enter Employee ID : ");
        int id = int.Parse(Console.ReadLine());
        Employee emp = employees.FirstOrDefault(e => e.Id == id);
        if (emp == null) { Console.WriteLine("Employee not found."); return; }
        int level = 1;
        while (emp.ManagerId != 0) { level++; emp = employees.First(e => e.Id == emp.ManagerId); }
        Console.WriteLine($"Hierarchy Level : {level}");
    }
}
