using System;
using System.Globalization;
using System.Text;

static class StringToolkit
{
    public static string Reverse(string input)
    {
        char[] characters = input.ToCharArray();

        Array.Reverse(characters);

        return new string(characters);
    }

    public static int CountChar(string text, char searchChar)
    {
        int count = 0;

        foreach (char c in text)
        {
            if (c == searchChar)
            {
                count++;
            }
        }

        return count;
    }

    public static string RemoveDuplicates(string input)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in input)
        {
            if (!result.ToString().Contains(c))
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    public static bool IsPalindrome(string input)
    {
        string cleaned = input
            .Replace(" ", "")
            .ToLower();

        string reversed = Reverse(cleaned);

        return cleaned == reversed;
    }

    public static string ToTitleCase(string input)
    {
        TextInfo textInfo =
            CultureInfo.CurrentCulture.TextInfo;

        return textInfo.ToTitleCase(input.ToLower());
    }

    public static string ExtractNumbers(string input)
    {
        StringBuilder numbers = new StringBuilder();

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                numbers.Append(c);
            }
        }

        return numbers.ToString();
    }
}

class Lab3
{
    public static void Run()
    {
        Console.WriteLine(
            $"Reverse(\"Hello\") -> \"{StringToolkit.Reverse("Hello")}\""
        );

        Console.WriteLine(
            $"CountChar(\"banana\", 'a') -> " +
            $"{StringToolkit.CountChar("banana", 'a')}"
        );

        Console.WriteLine(
            $"RemoveDuplicates(\"mississippi\") -> " +
            $"\"{StringToolkit.RemoveDuplicates("mississippi")}\""
        );

        Console.WriteLine(
            $"IsPalindrome(\"race car\") -> " +
            $"{StringToolkit.IsPalindrome("race car")}"
        );

        Console.WriteLine(
            $"ToTitleCase(\"hello training team\") -> " +
            $"\"{StringToolkit.ToTitleCase("hello training team")}\""
        );

        Console.WriteLine(
            $"ExtractNumbers(\"Order #4521, qty 3\") -> " +
            $"\"{StringToolkit.ExtractNumbers("Order #4521, qty 3")}\""
        );
    }
}