using System.Text.RegularExpressions;

// ── Data model ────────────────────────────────────────────────────────────────
public class LogEntry
{
    public string Date    { get; init; } = string.Empty;
    public string Time    { get; init; } = string.Empty;
    public string Level   { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
}

// ── Log parser utility ────────────────────────────────────────────────────────
public static class LogParser
{
    // Single named-group pattern, anchored to the start of each line with
    // RegexOptions.Multiline so ^ matches at the start of every line.
    private static readonly Regex LinePattern = new(
        @"^(?<date>\d{4}-\d{2}-\d{2})\s+(?<time>\d{2}:\d{2}:\d{2})\s+(?<level>\w+)\s+(?<message>.+)$",
        RegexOptions.Multiline | RegexOptions.Compiled);

    // Pattern to detect a numeric code in ERROR lines: code=NNN
    private static readonly Regex ErrorCodePattern = new(
        @"(?<=\bERROR\b.*)\bcode=(\d+)",
        RegexOptions.Compiled);

    /// <summary>
    /// Parses every line of rawLog into a List&lt;LogEntry&gt; using a single
    /// named-group Regex with RegexOptions.Multiline.
    /// </summary>
    public static List<LogEntry> ParseLog(string rawLog)
    {
        var entries = new List<LogEntry>();

        foreach (Match m in LinePattern.Matches(rawLog))
        {
            entries.Add(new LogEntry
            {
                Date    = m.Groups["date"].Value,
                Time    = m.Groups["time"].Value,
                Level   = m.Groups["level"].Value,
                Message = m.Groups["message"].Value
            });
        }

        return entries;
    }

    /// <summary>
    /// Returns a copy of rawLog where every "code=NNN" that appears on an
    /// ERROR line has its numeric part replaced with "###".
    /// Uses Regex.Replace with a MatchEvaluator so we can inspect context.
    /// </summary>
    public static string RedactErrorCodes(string rawLog)
    {
        // Process line by line so we only touch ERROR lines.
        var lines = rawLog.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("ERROR"))
            {
                // Replace code=<digits> with code=###
                lines[i] = Regex.Replace(lines[i], @"\bcode=\d+\b", m => "code=###");
            }
        }
        return string.Join('\n', lines);
    }

    /// <summary>
    /// BONUS: Filters ERROR entries whose Time falls within [startTime, endTime]
    /// using simple string comparison (safe because the format is fixed-width
    /// zero-padded HH:mm:ss).
    /// </summary>
    public static IEnumerable<LogEntry> FindErrorsInRange(
        List<LogEntry> entries, string startTime, string endTime)
    {
        return entries.Where(e =>
            e.Level == "ERROR" &&
            string.Compare(e.Time, startTime, StringComparison.Ordinal) >= 0 &&
            string.Compare(e.Time, endTime,   StringComparison.Ordinal) <= 0);
    }
}

// ── Lab runner ────────────────────────────────────────────────────────────────
public static class Lab5
{
    // Sample 6-line log with 3 INFO, 1 WARN, 2 ERROR (both with a code=NNN)
    private static readonly string RawLog =
        "2026-08-14 09:15:00 INFO  Service started\n" +
        "2026-08-14 09:16:12 WARN  Disk usage high\n" +
        "2026-08-14 09:17:45 ERROR Request failed code=404\n" +
        "2026-08-14 09:18:03 INFO  Request completed\n" +
        "2026-08-14 09:19:22 ERROR Upstream error code=500\n" +
        "2026-08-14 09:20:00 INFO  Shutdown complete";

    public static void Run()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("         LAB 5 RESULTS        ");
        Console.WriteLine("==============================\n");

        // ── Parse ─────────────────────────────────────────────────────────────
        List<LogEntry> entries = LogParser.ParseLog(RawLog);
        Console.WriteLine($"Parsed {entries.Count} entries.");

        // ── LINQ summary ──────────────────────────────────────────────────────
        var summary = entries
            .GroupBy(e => e.Level.Trim())
            .Select(g => $"{g.Key}: {g.Count()}");
        Console.WriteLine("Summary: " + string.Join(", ", summary));
        Console.WriteLine();

        // ── Redacted log ──────────────────────────────────────────────────────
        Console.WriteLine("--- Redacted log ---");
        Console.WriteLine(LogParser.RedactErrorCodes(RawLog));
        Console.WriteLine();

        // ── BONUS: errors in time range ───────────────────────────────────────
        Console.WriteLine("-- Bonus: ERROR entries between 09:17:00 and 09:19:30 --");
        var ranged = LogParser.FindErrorsInRange(entries, "09:17:00", "09:19:30").ToList();
        if (ranged.Count == 0)
            Console.WriteLine("  (none)");
        else
            foreach (var e in ranged)
                Console.WriteLine($"  [{e.Time}] {e.Level} - {e.Message}");
    }
}
