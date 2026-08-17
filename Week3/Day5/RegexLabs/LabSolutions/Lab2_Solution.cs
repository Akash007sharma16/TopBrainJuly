// ──────────────────────────────────────────────────────────────────────────────
// Lab 2 Reference Solution
// Extracting & Transforming Text
// ──────────────────────────────────────────────────────────────────────────────
using System.Text.RegularExpressions;

public static class Lab2Solution
{
    public static void Run()
    {
        // 1. Order numbers
        string text = "Order #4521 was shipped. order #99 is pending. ORDER #12345 was cancelled.";
        var orders = Regex.Matches(text, @"order\s+#(\d+)", RegexOptions.IgnoreCase)
                          .Select(m => m.Groups[1].Value);
        Console.WriteLine("Order numbers found: " + string.Join(", ", orders));

        // 2. Mask credit card
        string cardText = "Card on file: 4111-1111-1111-1234";
        string masked = Regex.Replace(
            cardText,
            @"(\d{4})([\s-])(\d{4})([\s-])(\d{4})([\s-])(\d{4})",
            m => $"XXXX{m.Groups[2].Value}XXXX{m.Groups[4].Value}XXXX{m.Groups[6].Value}{m.Groups[7].Value}");
        Console.WriteLine("Masked card: " + masked);

        // 3. Reformat name
        string names = "Smith, John";
        Console.WriteLine("Reformatted name: " + Regex.Replace(names, @"^(\w+),\s*(\w+)$", "$2 $1"));

        // 4. Split tags
        string tags = "red, blue;green , yellow";
        var tagArray = Regex.Split(tags, @"\s*[,;]\s*")
                            .Select(t => t.Trim()).Where(t => t.Length > 0).ToArray();
        Console.WriteLine("Tags: [" + string.Join(", ", tagArray) + "]");

        // Bonus
        foreach (Match m in Regex.Matches(text, @"(order)\s+#(\d+)", RegexOptions.IgnoreCase))
            Console.WriteLine($"  Keyword \"{m.Groups[1].Value}\" -> {m.Groups[2].Value}");
    }
}
