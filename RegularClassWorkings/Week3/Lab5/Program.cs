using System;

public class Formatter
{
    public string Format(int value) => value.ToString();
    public string Format(double value) => value.ToString("F2");
    public string Format(int numerator, int denominator) => $"{numerator}/{denominator}";
}

public class Notifier
{
    public virtual void Send() => Console.WriteLine("Notifier: generic send");
    public void Log() => Console.WriteLine("Notifier: generic log");
}

public class EmailNotifier : Notifier
{
    public override void Send() => Console.WriteLine("EmailNotifier: sending email");
    public new void Log() => Console.WriteLine("EmailNotifier: logging to email log");
}

public struct Vector2
{
    public double X;
    public double Y;

    public Vector2(double x, double y) { X = x; Y = y; }

    public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.X + b.X, a.Y + b.Y);
    public static Vector2 operator *(Vector2 v, double s) => new Vector2(v.X * s, v.Y * s);
    public override string ToString() => $"({X}, {Y})";
}

class Program
{
    static void Main()
    {
        Formatter formatter = new Formatter();
        Console.WriteLine($"Format(7) -> \"{formatter.Format(7)}\"");
        Console.WriteLine($"Format(3.5) -> \"{formatter.Format(3.5)}\"");
        Console.WriteLine($"Format(3, 4) -> \"{formatter.Format(3, 4)}\"");
        Console.WriteLine();

        EmailNotifier email = new EmailNotifier();
        Notifier notifier = email;

        Console.WriteLine("-- through EmailNotifier variable --");
        email.Send();
        email.Log();

        Console.WriteLine("-- through Notifier variable, same object --");
        notifier.Send();
        notifier.Log();
        Console.WriteLine();

        Vector2 v1 = new Vector2(1, 2);
        Vector2 v2 = new Vector2(3, 4);
        Console.WriteLine($"{v1} + {v2} = {v1 + v2}");
        Console.WriteLine($"{v1} * 3 = {v1 * 3}");
    }
}
