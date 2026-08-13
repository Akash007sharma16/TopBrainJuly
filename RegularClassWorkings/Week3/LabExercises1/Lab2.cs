using System;
using System.Diagnostics;
using System.Text;

class Lab2
{
    static string BuildWithString(int count)
    {
        string result = "";
        for (int i = 0; i < count; i++)
            result += i.ToString();
        return result;
    }

    static string BuildWithStringBuilder(int count)
    {
        StringBuilder result = new StringBuilder(count * 5);
        for (int i = 0; i < count; i++)
            result.Append(i.ToString());
        return result.ToString();
    }

    public static void Run()
    {
        int count = 50000;
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        BuildWithString(count);
        stopwatch.Stop();
        long stringTime = stopwatch.ElapsedMilliseconds;

        stopwatch.Restart();
        BuildWithStringBuilder(count);
        stopwatch.Stop();
        long stringBuilderTime = stopwatch.ElapsedMilliseconds;

        Console.WriteLine($"String concatenation ({count:N0} items): {stringTime} ms");
        Console.WriteLine($"StringBuilder ({count:N0} items): {stringBuilderTime} ms");
        if (stringBuilderTime > 0)
            Console.WriteLine($"StringBuilder is roughly {(double)stringTime / stringBuilderTime:F1}x faster");

        count = 200000;
        stopwatch.Restart();
        BuildWithString(count);
        stopwatch.Stop();
        stringTime = stopwatch.ElapsedMilliseconds;

        stopwatch.Restart();
        BuildWithStringBuilder(count);
        stopwatch.Stop();
        stringBuilderTime = stopwatch.ElapsedMilliseconds;

        Console.WriteLine();
        Console.WriteLine($"String concatenation ({count:N0} items): {stringTime} ms");
        Console.WriteLine($"StringBuilder ({count:N0} items): {stringBuilderTime} ms");
        if (stringBuilderTime > 0)
            Console.WriteLine($"StringBuilder is roughly {(double)stringTime / stringBuilderTime:F1}x faster");
    }
}
