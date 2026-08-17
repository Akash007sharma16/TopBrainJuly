using System.Text.RegularExpressions;
using System.Globalization;

public static class Lab3
{
    public static void Run()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("         LAB 3 RESULTS        ");
        Console.WriteLine("==============================\n");

        // ── TODO 1: Named groups on a log line ───────────────────────────────
        string logLine = "2026-08-14 09:15:32 ERROR Connection timed out";

        // Pattern breakdown:
        //   (?<date>\d{4}-\d{2}-\d{2})  – ISO date
        //   \s+
        //   (?<time>\d{2}:\d{2}:\d{2})  – HH:mm:ss
        //   \s+
        //   (?<level>\w+)               – log level word
        //   \s+
        //   (?<message>.+)              – rest of line
        var logPattern = new Regex(
            @"(?<date>\d{4}-\d{2}-\d{2})\s+(?<time>\d{2}:\d{2}:\d{2})\s+(?<level>\w+)\s+(?<message>.+)");

        Match logMatch = logPattern.Match(logLine);
        if (logMatch.Success)
        {
            Console.WriteLine($"date={logMatch.Groups["date"].Value}, " +
                              $"time={logMatch.Groups["time"].Value}, " +
                              $"level={logMatch.Groups["level"].Value}, " +
                              $"message={logMatch.Groups["message"].Value}");
        }
        Console.WriteLine();

        // ── TODO 2: Named groups for key=value pairs ─────────────────────────
        string kvText = "name=Alice;age=30;city=NYC";
        var kvPattern = new Regex(@"(?<key>\w+)=(?<value>[^;]+)");

        foreach (Match m in kvPattern.Matches(kvText))
            Console.WriteLine($"{m.Groups["key"].Value}={m.Groups["value"].Value}");
        Console.WriteLine();

        // ── TODO 3: MatchEvaluator – thousands separators ─────────────────────
        // Matches sequences of digits (whole numbers).
        string numbers = "Revenue: 1234567, Costs: 89000";
        string formatted = Regex.Replace(numbers, @"\d+", m =>
        {
            // Parse and re-format using the current culture's number separator.
            long n = long.Parse(m.Value);
            return n.ToString("N0", CultureInfo.InvariantCulture); // e.g. 1,234,567
        });
        Console.WriteLine(formatted);
        Console.WriteLine();

        // ── TODO 4: MatchEvaluator – ALL CAPS words to Title Case ─────────────
        // \b[A-Z]{2,}\b matches a whole word of 2+ uppercase letters.
        string shouting = "THIS IS URGENT please respond";
        string calmedDown = Regex.Replace(shouting, @"\b[A-Z]{2,}\b", m =>
        {
            // Title Case: first letter upper, the rest lower.
            string word = m.Value;
            return char.ToUpper(word[0]) + word[1..].ToLower();
        });
        Console.WriteLine(shouting + " -> \"" + calmedDown + "\"");
        Console.WriteLine();

        // ── BONUS: Parse multi-line log and zero-pad error codes ─────────────
        Console.WriteLine("-- Bonus: Error code zero-padding --");
        string multiLog =
            "2026-08-14 09:15:00 INFO  Service started\n" +
            "2026-08-14 09:16:12 ERROR Disk read failed, err=404\n" +
            "2026-08-14 09:17:45 ERROR Network error, err=5";

        // Process line by line; only zero-pad numeric error codes (err=NNN) on ERROR lines.
        foreach (string line in multiLog.Split('\n'))
        {
            if (line.Contains("ERROR"))
            {
                // Only match digits that follow "err=" to avoid mangling timestamps.
                string padded = Regex.Replace(line, @"(?<=\berr=)\d+", m =>
                    long.Parse(m.Value).ToString("D5")); // 5-digit zero-padded
                Console.WriteLine(padded);
            }
            else
            {
                Console.WriteLine(line);
            }
        }
    }
}
