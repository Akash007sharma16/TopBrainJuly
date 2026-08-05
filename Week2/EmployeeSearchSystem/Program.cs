using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int Id;
    public string Name;
    public string Department;
    public string Designation;
    public int Experience;
    public double Salary;
    public string City;

    public Employee(int id, string name, string department, string designation,
                    int experience, double salary, string city)
    {
        Id = id;
        Name = name;
        Department = department;
        Designation = designation;
        Experience = experience;
        Salary = salary;
        City = city;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Department: {Department}");
        Console.WriteLine($"Designation: {Designation}");
        Console.WriteLine($"Experience: {Experience} Years");
        Console.WriteLine($"Salary: {Salary}");
        Console.WriteLine($"City: {City}");
        Console.WriteLine("-------------------------------------------");
    }
}

class Program
{
    static List<Employee> employees = new List<Employee>
    {
        new Employee(1001,"Rahul Sharma","IT","Software Engineer",2,45000,"Chennai"),
        new Employee(1002,"Priya Singh","HR","HR Executive",3,40000,"Bangalore"),
        new Employee(1003,"Amit Kumar","Finance","Accountant",5,55000,"Hyderabad"),
        new Employee(1004,"Neha Patel","IT","Senior Developer",6,85000,"Pune"),
        new Employee(1005,"Arjun Reddy","Sales","Sales Executive",2,38000,"Chennai"),
        new Employee(1006,"Sneha Iyer","Marketing","Marketing Executive",4,52000,"Coimbatore"),
        new Employee(1007,"Karan Mehta","IT","Team Lead",8,95000,"Mumbai"),
        new Employee(1008,"Divya Nair","Support","Support Engineer",1,32000,"Kochi"),
        new Employee(1009,"Rohit Verma","IT","Software Engineer",3,50000,"Delhi"),
        new Employee(1010,"Anjali Gupta","Finance","Financial Analyst",4,65000,"Noida"),
        new Employee(1011,"Suresh Kumar","Admin","Administrator",7,58000,"Madurai"),
        new Employee(1012,"Pooja Sharma","HR","Recruiter",2,42000,"Bangalore"),
        new Employee(1013,"Vikram Das","IT","System Engineer",5,62000,"Chennai"),
        new Employee(1014,"Meena Joshi","Support","Technical Support",3,41000,"Trichy"),
        new Employee(1015,"Naveen Raj","Sales","Sales Manager",9,98000,"Salem"),
        new Employee(1016,"Kavya R","Marketing","SEO Analyst",2,45000,"Chennai"),
        new Employee(1017,"Ajay Kumar","IT","DevOps Engineer",4,72000,"Hyderabad"),
        new Employee(1018,"Lakshmi Devi","Finance","Senior Accountant",6,76000,"Coimbatore"),
        new Employee(1019,"Manoj Singh","IT","QA Engineer",3,53000,"Pune"),
        new Employee(1020,"Deepika Rao","HR","HR Manager",8,90000,"Bangalore")
    };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n====================================");
            Console.WriteLine("      ABC Technologies");
            Console.WriteLine(" Employee Search Management System");
            Console.WriteLine("====================================");

            Console.WriteLine("1. Display All Employees");
            Console.WriteLine("2. Search by Employee ID (Linear Search)");
            Console.WriteLine("3. Search by Employee ID (Binary Search)");
            Console.WriteLine("4. Search by Employee Name");
            Console.WriteLine("5. Search by Department");
            Console.WriteLine("6. Search by City");
            Console.WriteLine("7. Search by Experience");
            Console.WriteLine("8. Search by Salary Range");
            Console.WriteLine("9. Exit");

            Console.Write("\nEnter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayAll();
                    break;

                case 2:
                    Console.Write("Enter Employee ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    LinearSearch(id);
                    break;

                case 3:
                    Console.Write("Enter Employee ID: ");
                    id = Convert.ToInt32(Console.ReadLine());
                    BinarySearch(id);
                    break;

                case 4:
                    Console.Write("Enter Employee Name: ");
                    string name = Console.ReadLine();
                    SearchByName(name);
                    break;

                case 5:
                    Console.Write("Enter Department: ");
                    string dept = Console.ReadLine();
                    SearchByDepartment(dept);
                    break;

                case 6:
                    Console.Write("Enter City: ");
                    string city = Console.ReadLine();
                    SearchByCity(city);
                    break;

                case 7:
                    Console.Write("Enter Minimum Experience: ");
                    int exp = Convert.ToInt32(Console.ReadLine());
                    SearchByExperience(exp);
                    break;

                case 8:
                    Console.Write("Enter Minimum Salary: ");
                    double min = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter Maximum Salary: ");
                    double max = Convert.ToDouble(Console.ReadLine());

                    SearchBySalary(min, max);
                    break;

                case 9:
                    Console.WriteLine("Thank You!");
                    return;

                default:
                    Console.WriteLine("Invalid Choice.");
                    break;
            }
        }
    }

    static void DisplayAll()
    {
        foreach (Employee emp in employees)
            emp.Display();
    }

    static void LinearSearch(int id)
    {
        foreach (Employee emp in employees)
        {
            if (emp.Id == id)
            {
                Console.WriteLine("\nEmployee Found:");
                emp.Display();
                return;
            }
        }
        Console.WriteLine("Employee Not Found.");
    }

    static void BinarySearch(int id)
    {
        List<Employee> sorted = employees.OrderBy(e => e.Id).ToList();

        int low = 0;
        int high = sorted.Count - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (sorted[mid].Id == id)
            {
                Console.WriteLine("\nEmployee Found:");
                sorted[mid].Display();
                return;
            }
            else if (id < sorted[mid].Id)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        Console.WriteLine("Employee Not Found.");
    }

    static void SearchByName(string name)
    {
        bool found = false;

        foreach (Employee emp in employees)
        {
            if (emp.Name.ToLower().Contains(name.ToLower()))
            {
                emp.Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("Employee Not Found.");
    }

    static void SearchByDepartment(string department)
    {
        bool found = false;

        foreach (Employee emp in employees)
        {
            if (emp.Department.Equals(department, StringComparison.OrdinalIgnoreCase))
            {
                emp.Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No Employees Found.");
    }

    static void SearchByCity(string city)
    {
        bool found = false;

        foreach (Employee emp in employees)
        {
            if (emp.City.Equals(city, StringComparison.OrdinalIgnoreCase))
            {
                emp.Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No Employees Found.");
    }

    static void SearchByExperience(int experience)
    {
        bool found = false;

        foreach (Employee emp in employees)
        {
            if (emp.Experience >= experience)
            {
                emp.Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No Employees Found.");
    }

    static void SearchBySalary(double minSalary, double maxSalary)
    {
        bool found = false;

        foreach (Employee emp in employees)
        {
            if (emp.Salary >= minSalary && emp.Salary <= maxSalary)
            {
                emp.Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No Employees Found.");
    }
}