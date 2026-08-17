// ──────────────────────────────────────────────────────────────────────────────
// Lab 4 Reference Solution
// Regex Options & a Small Pattern Library
// ──────────────────────────────────────────────────────────────────────────────
using System.Text.RegularExpressions;

// PatternLibrary is already defined in Lab4.cs (shared across labs).
// This solution file shows the equivalent inline for reference only.

public static class Lab4Solution
{
    public static void Run()
    {
        // IgnoreCase demo
        Console.WriteLine($"IgnoreCase off: {Regex.IsMatch("HELLO", "hello")}, " +
                          $"IgnoreCase on: {Regex.IsMatch("HELLO", "hello", RegexOptions.IgnoreCase)}");

        // Multiline demo
        string ml = "First line\nSecond line\nThird line";
        Console.WriteLine($"Without Multiline: {Regex.Matches(ml, @"^").Count}");
        Console.WriteLine($"With    Multiline: {Regex.Matches(ml, @"^", RegexOptions.Multiline).Count}");

        // PatternLibrary calls
        Console.WriteLine($"Email   valid  : {PatternLibrary.IsValidEmail("a@b.com")}");
        Console.WriteLine($"Email   invalid: {PatternLibrary.IsValidEmail("not-an-email")}");
        Console.WriteLine($"Phone   valid  : {PatternLibrary.IsValidPhone("555-123-4567")}");
        Console.WriteLine($"Phone   invalid: {PatternLibrary.IsValidPhone("5551234567")}");
        Console.WriteLine($"HexColor valid : {PatternLibrary.IsValidHexColor("#1A2B3C")}");
        Console.WriteLine($"HexColor invld : {PatternLibrary.IsValidHexColor("1A2B3C")}");

        // Timeout bonus
        try
        {
            var rx = new Regex(@"(a+)+$", RegexOptions.None, TimeSpan.FromMilliseconds(200));
            rx.IsMatch(new string('a', 30) + "X");
        }
        catch (RegexMatchTimeoutException ex)
        {
            Console.WriteLine("Timeout caught: " + ex.Message);
        }
    }
}
