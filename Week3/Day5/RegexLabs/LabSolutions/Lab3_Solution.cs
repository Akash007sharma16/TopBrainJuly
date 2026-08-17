// ──────────────────────────────────────────────────────────────────────────────
// Lab 3 Reference Solution
// Groups & Programmatic Replacement
// ──────────────────────────────────────────────────────────────────────────────
using System.Text.RegularExpressions;
using System.Globalization;

public static class Lab3Solution
{
    public static void Run()
    {
        // 1. Named groups on log line
        string logLine = "2026-08-14 09:15:32 ERROR Connection timed out";
        var m1 = Regex.Match(logLine,
            @"(?<date>\d{4}-\d{2}-\d{2})\s+(?<time>\d{2}:\d{2}:\d{2})\s+(?<level>\w+)\s+(?<message>.+)");
        Console.WriteLine($"date={m1.Groups["date"].Value}, time={m1.Groups["time"].Value}, " +
                          $"level={m1.Groups["level"].Value}, message={m1.Groups["message"].Value}");

        // 2. Key-value pairs
        foreach (Match m in Regex.Matches("name=Alice;age=30;city=NYC", @"(?<key>\w+)=(?<value>[^;]+)"))
            Console.WriteLine($"{m.Groups["key"].Value}={m.Groups["value"].Value}");

        // 3. Thousands separators
        Console.WriteLine(Regex.Replace("Revenue: 1234567, Costs: 89000", @"\d+",
            m => long.Parse(m.Value).ToString("N0", CultureInfo.InvariantCulture)));

        // 4. ALL CAPS to Title Case
        string result = Regex.Replace("THIS IS URGENT please respond", @"\b[A-Z]{2,}\b",
            m => char.ToUpper(m.Value[0]) + m.Value[1..].ToLower());
        Console.WriteLine(result);
    }
}
