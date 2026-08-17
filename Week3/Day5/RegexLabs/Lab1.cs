using System.Text.RegularExpressions;

public static class Lab1
{
    public static void Run()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("         LAB 1 RESULTS        ");
        Console.WriteLine("==============================\n");

        // ── TODO 1: ZIP code ─────────────────────────────────────────────────
        // Pattern: exactly 5 digits, optionally followed by a dash and 4 digits.
        // ^ and $ anchor the full string so "123456" won't slip through.
        string zipPattern = @"^\d{5}(-\d{4})?$";
        Console.WriteLine("-- ZIP Code --");
        Console.WriteLine($"\"12345\"     : {Regex.IsMatch("12345",     zipPattern)}");   // True
        Console.WriteLine($"\"12345-6789\": {Regex.IsMatch("12345-6789", zipPattern)}"); // True
        Console.WriteLine($"\"1234\"      : {Regex.IsMatch("1234",      zipPattern)}");  // False
        Console.WriteLine();

        // ── TODO 2: Username ─────────────────────────────────────────────────
        // Must start with a letter or underscore (not a digit), then 2-15 more
        // word chars (\w = letter/digit/underscore), total 3-16 characters.
        string userPattern = @"^[A-Za-z_]\w{2,15}$";
        Console.WriteLine("-- Username --");
        Console.WriteLine($"\"user_1\": {Regex.IsMatch("user_1", userPattern)}"); // True
        Console.WriteLine($"\"1user\" : {Regex.IsMatch("1user",  userPattern)}"); // False
        Console.WriteLine($"\"ab\"    : {Regex.IsMatch("ab",     userPattern)}"); // False
        Console.WriteLine();

        // ── TODO 3: Hex color code ────────────────────────────────────────────
        // # followed by exactly 6 hex digits (case-insensitive via [A-Fa-f0-9]).
        string hexPattern = @"^#[0-9A-Fa-f]{6}$";
        Console.WriteLine("-- Hex Color --");
        Console.WriteLine($"\"#1A2B3C\" : {Regex.IsMatch("#1A2B3C",  hexPattern)}"); // True
        Console.WriteLine($"\"#GGGGGG\" : {Regex.IsMatch("#GGGGGG",  hexPattern)}"); // False
        Console.WriteLine($"\"1A2B3C\"  : {Regex.IsMatch("1A2B3C",   hexPattern)}"); // False
        Console.WriteLine();

        // ── TODO 4: Password strength ─────────────────────────────────────────
        // Approach chosen: multiple separate IsMatch checks combined with &&.
        // Reason: lookahead-based single patterns work but are harder to read and
        // maintain; splitting into three readable predicates is clearer and each
        // rule can be updated independently without touching the others.
        string pwd1 = "password";   // no digit, no uppercase  -> False
        string pwd2 = "Password1";  // has digit AND uppercase  -> True
        string pwd3 = "pass1";      // too short                -> False

        bool IsStrongPassword(string pwd)
        {
            return pwd.Length >= 8
                && Regex.IsMatch(pwd, @"\d")          // at least one digit
                && Regex.IsMatch(pwd, @"[A-Z]");       // at least one uppercase
        }

        Console.WriteLine("-- Password Strength --");
        Console.WriteLine($"\"password\" : {IsStrongPassword(pwd1)}");  // False
        Console.WriteLine($"\"Password1\": {IsStrongPassword(pwd2)}");  // True
        Console.WriteLine($"\"pass1\"    : {IsStrongPassword(pwd3)}");  // False
        Console.WriteLine();

        // ── TODO 5: Single-terminator sentence ───────────────────────────────
        // [^.!?]+ matches any characters that are NOT punctuation terminators,
        // then exactly one [.!?] at the end.  Anchored with ^ and $.
        string sentPattern = @"^[^.!?]+[.!?]$";
        Console.WriteLine("-- Sentence Terminator --");
        Console.WriteLine($"\"Hello there.\" : {Regex.IsMatch("Hello there.", sentPattern)}"); // True
        Console.WriteLine($"\"Wait...\"      : {Regex.IsMatch("Wait...",      sentPattern)}"); // False
        Console.WriteLine($"\"Really?\"      : {Regex.IsMatch("Really?",      sentPattern)}"); // True
        Console.WriteLine();

        // ── BONUS: ValidateSignup ─────────────────────────────────────────────
        Console.WriteLine("-- Bonus: ValidateSignup --");
        PrintSignupErrors("user_1", "Password1");  // valid
        PrintSignupErrors("1user",  "pass1");       // two errors
    }

    /// <summary>
    /// Returns a list of validation error messages for the given username and password.
    /// An empty list means the credentials are fully valid.
    /// </summary>
    public static List<string> ValidateSignup(string username, string password)
    {
        var errors = new List<string>();

        if (!Regex.IsMatch(username, @"^[A-Za-z_]\w{2,15}$"))
            errors.Add("Username must be 3-16 chars, start with a letter/underscore, and contain only letters/digits/underscores.");

        if (password.Length < 8)
            errors.Add("Password must be at least 8 characters long.");

        if (!Regex.IsMatch(password, @"\d"))
            errors.Add("Password must contain at least one digit.");

        if (!Regex.IsMatch(password, @"[A-Z]"))
            errors.Add("Password must contain at least one uppercase letter.");

        return errors;
    }

    private static void PrintSignupErrors(string username, string password)
    {
        var errors = ValidateSignup(username, password);
        if (errors.Count == 0)
            Console.WriteLine($"  ({username} / {password}) -> Valid!");
        else
            foreach (var e in errors)
                Console.WriteLine($"  ({username} / {password}) -> Error: {e}");
    }
}
