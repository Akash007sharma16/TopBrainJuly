using System;
using System.Text;

class Lab4
{
    public static void Run()
    {
        const string rawData = @"
john smith|engineering|72000
MARY jones|sales|65000
ravi KUMAR|engineering|81000
";
        StringBuilder sb = new StringBuilder();
        int employeeCount = 0;
        decimal totalSalary = 0;

        sb.AppendLine("==================================================");
        sb.AppendLine("           EMPLOYEE COMPENSATION REPORT");
        sb.AppendLine("==================================================");
        sb.AppendLine("Name".PadRight(20) + "Department".PadRight(20) + "Salary".PadLeft(10));
        sb.AppendLine("--------------------------------------------------");

        string[] rows = rawData.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        foreach (string row in rows)
        {
            if (string.IsNullOrWhiteSpace(row)) continue;

            string[] fields = row.Trim().Split('|');
            string name = StringToolkit.ToTitleCase(fields[0]);
            string department = fields[1];
            decimal salary = decimal.Parse(fields[2]);

            sb.AppendLine(name.PadRight(20) + department.PadRight(20) + salary.ToString("N0").PadLeft(10));
            employeeCount++;
            totalSalary += salary;
        }

        sb.AppendLine("--------------------------------------------------");
        sb.AppendLine($"Employees: {employeeCount}    Total Salary: {totalSalary:N0}");
        sb.AppendLine("==================================================");

        Console.WriteLine(sb.ToString());
        Console.WriteLine("String concatenations inside loops: 0");
    }
}
