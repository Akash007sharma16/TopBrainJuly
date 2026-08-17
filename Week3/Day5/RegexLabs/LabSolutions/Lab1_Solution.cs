// ──────────────────────────────────────────────────────────────────────────────
// Lab 1 Reference Solution
// Pattern-Writing Practice (IsMatch)
// ──────────────────────────────────────────────────────────────────────────────
using System.Text.RegularExpressions;

public static class Lab1Solution
{
    // 1. ZIP code: 5 digits, optionally followed by dash + 4 digits.
    private const string ZipPattern      = @"^\d{5}(-\d{4})?$";

    // 2. Username: starts with letter/underscore, 3-16 total word-chars.
    private const string UserPattern     = @"^[A-Za-z_]\w{2,15}$";

    // 3. Hex color: # + exactly 6 hex digits.
    private const string HexPattern      = @"^#[0-9A-Fa-f]{6}$";

    // 4. Sentence: no . ! ? inside, exactly one at the very end.
    private const string SentencePattern = @"^[^.!?]+[.!?]$";

    public static void Run()
    {
        Console.WriteLine($"ZIP     \"12345\"     : {Regex.IsMatch("12345",     ZipPattern)}");
        Console.WriteLine($"ZIP     \"12345-6789\": {Regex.IsMatch("12345-6789", ZipPattern)}");
        Console.WriteLine($"ZIP     \"1234\"      : {Regex.IsMatch("1234",      ZipPattern)}");

        Console.WriteLine($"User    \"user_1\"    : {Regex.IsMatch("user_1", UserPattern)}");
        Console.WriteLine($"User    \"1user\"     : {Regex.IsMatch("1user",  UserPattern)}");
        Console.WriteLine($"User    \"ab\"        : {Regex.IsMatch("ab",     UserPattern)}");

        Console.WriteLine($"Hex     \"#1A2B3C\"   : {Regex.IsMatch("#1A2B3C", HexPattern)}");
        Console.WriteLine($"Hex     \"#GGGGGG\"   : {Regex.IsMatch("#GGGGGG", HexPattern)}");
        Console.WriteLine($"Hex     \"1A2B3C\"    : {Regex.IsMatch("1A2B3C",  HexPattern)}");

        // Password – multiple IsMatch approach (see Lab1.cs for rationale)
        Console.WriteLine($"Pwd     \"password\"  : {IsStrongPassword("password")}");
        Console.WriteLine($"Pwd     \"Password1\" : {IsStrongPassword("Password1")}");
        Console.WriteLine($"Pwd     \"pass1\"     : {IsStrongPassword("pass1")}");

        Console.WriteLine($"Sentence \"Hello there.\": {Regex.IsMatch("Hello there.", SentencePattern)}");
        Console.WriteLine($"Sentence \"Wait...\"     : {Regex.IsMatch("Wait...",      SentencePattern)}");
        Console.WriteLine($"Sentence \"Really?\"     : {Regex.IsMatch("Really?",      SentencePattern)}");
    }

    private static bool IsStrongPassword(string pwd) =>
        pwd.Length >= 8 && Regex.IsMatch(pwd, @"\d") && Regex.IsMatch(pwd, @"[A-Z]");

    public static List<string> ValidateSignup(string username, string password)
    {
        var errors = new List<string>();
        if (!Regex.IsMatch(username, UserPattern))
            errors.Add("Invalid username.");
        if (password.Length < 8)
            errors.Add("Password too short.");
        if (!Regex.IsMatch(password, @"\d"))
            errors.Add("Password needs a digit.");
        if (!Regex.IsMatch(password, @"[A-Z]"))
            errors.Add("Password needs an uppercase letter.");
        return errors;
    }
}
