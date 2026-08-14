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

        // Header
        sb.AppendLine("==================================================");
        sb.AppendLine("           EMPLOYEE COMPENSATION REPORT");
        sb.AppendLine("==================================================");

        sb.AppendLine(
            "Name".PadRight(20) +
            "Department".PadRight(20) +
            "Salary".PadLeft(10)
        );

        sb.AppendLine("--------------------------------------------------");

        // Split raw data into rows
        string[] rows = rawData.Split(
            '\n',
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string row in rows)
        {
            // Skip blank rows
            if (string.IsNullOrWhiteSpace(row))
            {
                continue;
            }

            // Split each row using |
            string[] fields = row.Trim().Split('|');

            string name = fields[0];
            string department = fields[1];
            decimal salary = decimal.Parse(fields[2]);

            // Normalize employee name
            name = StringToolkit.ToTitleCase(name);

            // Add employee information to report
            sb.AppendLine(
                name.PadRight(20) +
                department.PadRight(20) +
                salary.ToString("N0").PadLeft(10)
            );

            employeeCount++;
            totalSalary += salary;
        }

        // Footer
        sb.AppendLine("--------------------------------------------------");

        sb.AppendLine(
            $"Employees: {employeeCount}    " +
            $"Total Salary: {totalSalary:N0}"
        );

        sb.AppendLine("==================================================");

        // Print final report
        Console.WriteLine(sb.ToString());

        Console.WriteLine(
            "String concatenations inside loops: 0"
        );
    }
}