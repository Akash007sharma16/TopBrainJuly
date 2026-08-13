using System;

class Lab1
{
    public static void Run()
    {
        string original = " Hello, Training Team! ";

        string trimmed = original.Trim();

        Console.WriteLine(
            "ReferenceEquals(original, trimmed): " +
            object.ReferenceEquals(original, trimmed)
        );

        Console.WriteLine(
            "Contains \"Training\": " +
            trimmed.Contains("Training")
        );

        Console.WriteLine(
            "StartsWith trimmed \"Hello\": " +
            trimmed.StartsWith("Hello")
        );

        Console.WriteLine(
            "Index of first comma: " +
            trimmed.IndexOf(',')
        );

        string replaced = trimmed.Replace(
            "Training Team",
            "Engineering Team"
        );

        Console.WriteLine(
            "\"Training Team\" replaced -> " + replaced
        );

        string[] words = trimmed.Split(
            new char[] { ' ', ',' },
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }

        Console.WriteLine(
            "IsNullOrWhiteSpace(null): " +
            string.IsNullOrWhiteSpace(null)
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\"\"): " +
            string.IsNullOrWhiteSpace("")
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\" \"): " +
            string.IsNullOrWhiteSpace(" ")
        );

        Console.WriteLine(
            "IsNullOrWhiteSpace(\"ok\"): " +
            string.IsNullOrWhiteSpace("ok")
        );
    }
}
