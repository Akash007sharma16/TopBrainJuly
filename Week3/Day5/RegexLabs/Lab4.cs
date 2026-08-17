using System.Text.RegularExpressions;

// ── PatternLibrary ────────────────────────────────────────────────────────────
// A small, reusable static class of pre-compiled Regex patterns.
// RegexOptions.Compiled tells the runtime to emit IL for the pattern, giving
// faster repeated matching at the cost of a slightly longer first-build time.
public static class PatternLibrary
{
    // Email: simple but practical – local@domain.tld
    public static readonly Regex Email = new(
        @"^[A-Za-z0-9._%+\-]+@[A-Za-z0-9.\-]+\.[A-Za-z]{2,}$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    // US Phone: accepts 555-123-4567, (555) 123-4567, 555.123.4567
    public static readonly Regex UsPhone = new(
        @"^(\(?\d{3}\)?[\s.\-])?\d{3}[\s.\-]\d{4}$",
        RegexOptions.Compiled);

    // Hex color: # + exactly 6 hex digits
    public static readonly Regex HexColor = new(
        @"^#[0-9A-Fa-f]{6}$",
        RegexOptions.Compiled);

    public static bool IsValidEmail(string input)    => Email.IsMatch(input);
    public static bool IsValidPhone(string input)    => UsPhone.IsMatch(input);
    public static bool IsValidHexColor(string input) => HexColor.IsMatch(input);
}

public static class Lab4
{
    public static void Run()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("         LAB 4 RESULTS        ");
        Console.WriteLine("==============================\n");

        // ── TODO 3: IgnoreCase demo ───────────────────────────────────────────
        string pattern = "hello";
        string target  = "HELLO";
        bool withoutIC = Regex.IsMatch(target, pattern);
        bool withIC    = Regex.IsMatch(target, pattern, RegexOptions.IgnoreCase);
        Console.WriteLine($"IgnoreCase off: {withoutIC}, IgnoreCase on: {withIC}");
        Console.WriteLine();

        // ── TODO 4: Multiline demo ───────────────────────────────────────────
        // Three lines; we count how many times ^ matches.
        string multiLine = "First line\nSecond line\nThird line";

        int countWithout = Regex.Matches(multiLine, @"^").Count;          // only 1 (very start)
        int countWith    = Regex.Matches(multiLine, @"^",                 // 3 (one per line)
                               RegexOptions.Multiline).Count;

        Console.WriteLine($"Line-start matches WITHOUT Multiline: {countWithout}");
        Console.WriteLine($"Line-start matches WITH    Multiline: {countWith}");
        Console.WriteLine();

        // ── TODO 5: PatternLibrary demo ──────────────────────────────────────
        Console.WriteLine($"IsValidEmail(\"a@b.com\")      : {PatternLibrary.IsValidEmail("a@b.com")}");
        Console.WriteLine($"IsValidEmail(\"not-an-email\") : {PatternLibrary.IsValidEmail("not-an-email")}");

        Console.WriteLine($"IsValidPhone(\"555-123-4567\") : {PatternLibrary.IsValidPhone("555-123-4567")}");
        Console.WriteLine($"IsValidPhone(\"5551234567\")   : {PatternLibrary.IsValidPhone("5551234567")}");

        Console.WriteLine($"IsValidHexColor(\"#1A2B3C\")  : {PatternLibrary.IsValidHexColor("#1A2B3C")}");
        Console.WriteLine($"IsValidHexColor(\"1A2B3C\")   : {PatternLibrary.IsValidHexColor("1A2B3C")}");
        Console.WriteLine();

        // ── BONUS: Timeout on pathological pattern ────────────────────────────
        Console.WriteLine("-- Bonus: RegexMatchTimeoutException --");
        try
        {
            // (a+)+ against a long string of 'a's followed by 'X' causes
            // catastrophic backtracking.  The timeout cuts it off.
            string bomb = new string('a', 30) + "X";
            var timedOut = new Regex(@"(a+)+$", RegexOptions.None,
                               TimeSpan.FromMilliseconds(200));
            bool result = timedOut.IsMatch(bomb);
            Console.WriteLine($"Match result (unlikely to reach here): {result}");
        }
        catch (RegexMatchTimeoutException ex)
        {
            Console.WriteLine($"Caught RegexMatchTimeoutException as expected: {ex.Message}");
        }
    }
}
