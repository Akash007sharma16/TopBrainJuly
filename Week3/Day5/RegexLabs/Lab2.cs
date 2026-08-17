using System.Text.RegularExpressions;

public static class Lab2
{
    public static void Run()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("         LAB 2 RESULTS        ");
        Console.WriteLine("==============================\n");

        // ── TODO 1: Extract order numbers with IgnoreCase ─────────────────────
        // Group 1 captures the numeric part only.
        string text = "Order #4521 was shipped. order #99 is pending. ORDER #12345 was cancelled.";
        var orderMatches = Regex.Matches(text, @"order\s+#(\d+)", RegexOptions.IgnoreCase);

        var orderNumbers = orderMatches.Select(m => m.Groups[1].Value).ToList();
        Console.WriteLine($"Order numbers found: {string.Join(", ", orderNumbers)}");
        Console.WriteLine();

        // ── TODO 2: Mask credit-card digits ───────────────────────────────────
        // Pattern: four groups of 4 digits separated by space or dash,
        //          captured individually so we can mask the first three groups.
        string cardText = "Card on file: 4111-1111-1111-1234";

        // Replace with a MatchEvaluator that keeps the separators intact and
        // replaces each character in the first 12 digit chars with 'X'.
        string masked = Regex.Replace(
            cardText,
            @"(\d{4})([\s-])(\d{4})([\s-])(\d{4})([\s-])(\d{4})",
            m =>
            {
                // Rebuild: mask first 3 groups, keep separators and last group.
                string sep1 = m.Groups[2].Value;
                string sep2 = m.Groups[4].Value;
                string sep3 = m.Groups[6].Value;
                string last4 = m.Groups[7].Value;
                return $"XXXX{sep1}XXXX{sep2}XXXX{sep3}{last4}";
            });
        Console.WriteLine($"Masked card: {masked}");
        Console.WriteLine();

        // ── TODO 3: Reformat "Lastname, Firstname" -> "Firstname Lastname" ────
        // Group 1 = lastname, Group 2 = firstname.
        string names = "Smith, John";
        string reformatted = Regex.Replace(names, @"^(\w+),\s*(\w+)$", "$2 $1");
        Console.WriteLine($"Reformatted name: {reformatted}");
        Console.WriteLine();

        // ── TODO 4: Split tag string into clean, trimmed tags ─────────────────
        // Split on any combination of whitespace, comma, or semicolon.
        string tags = "red, blue;green , yellow";
        string[] tagArray = Regex.Split(tags, @"\s*[,;]\s*")
                                 .Select(t => t.Trim())
                                 .Where(t => t.Length > 0)
                                 .ToArray();
        Console.WriteLine($"Tags: [{string.Join(", ", tagArray)}]");
        Console.WriteLine();

        // ── BONUS: Also capture the original casing of "order" ───────────────
        Console.WriteLine("-- Bonus: Order word casing --");
        foreach (Match m in Regex.Matches(text, @"(order)\s+#(\d+)", RegexOptions.IgnoreCase))
            Console.WriteLine($"  Keyword: \"{m.Groups[1].Value}\"  ->  Number: {m.Groups[2].Value}");
    }
}
