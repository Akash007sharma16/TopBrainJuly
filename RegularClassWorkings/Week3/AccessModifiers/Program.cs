using System;

public class Employee
{
    private decimal _salary;

    public string Name = string.Empty;

    protected string Department = "Gendrel";

    internal string EmployeeId = "E-1001";

    protected internal void SetDepartment(string department)
    {
        Department = department;
    }

    public void ShowSalary()
    {
        Console.WriteLine($"Salary: {_salary}");
    }

    private protected void AdjustSalary(decimal salary)
    {
        _salary = salary;
    }
}

public class Manager : Employee
{
    public void PrintDetails()
    {
        Name = "Benhar";

        Console.WriteLine($"Department : {Department}");

        SetDepartment("Engineer");

        AdjustSalary(500000);

        Console.WriteLine($"Employee ID : {EmployeeId}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Manager manager = new Manager();

        manager.PrintDetails();

        Console.WriteLine();
    }
}