using System;
using System.Collections.Generic;

public class Box<T>
{
    private T _value;
    public Box(T value) { _value = value; }
    public T GetValue() => _value;
    public void Replace(T newValue) { _value = newValue; }
    public static Box<T2> CreateEmpty<T2>() where T2 : new() => new Box<T2>(new T2());
}

public class Pair<TFirst, TSecond>
{
    public TFirst First { get; set; }
    public TSecond Second { get; set; }
    public Pair(TFirst first, TSecond second) { First = first; Second = second; }
    public override string ToString() => $"({First}, {Second})";
}

public class SortedBox<T> where T : IComparable<T>
{
    private readonly List<T> _items = new();
    public void Add(T item) { _items.Add(item); _items.Sort(); }
    public IEnumerable<T> Items => _items;
}

class Program
{
    static void Main()
    {
        Box<int> intBox = new Box<int>(42);
        Box<string> stringBox = new Box<string>("Hello");
        Box<DateTime> dateBox = new Box<DateTime>(new DateTime(2026, 8, 12));

        Console.WriteLine($"Box<int>: {intBox.GetValue()}");
        Console.WriteLine($"Box<string>: {stringBox.GetValue()}");
        Console.WriteLine($"Box<DateTime>: {dateBox.GetValue():yyyy-MM-dd}");

        Pair<string, int> pair = new Pair<string, int>("Age", 30);
        Console.WriteLine($"Pair: {pair}");

        SortedBox<int> sortedBox = new SortedBox<int>();
        sortedBox.Add(5); sortedBox.Add(1); sortedBox.Add(3);
        Console.WriteLine($"SortedBox after adding 5, 1, 3: {string.Join(", ", sortedBox.Items)}");
    }
}
