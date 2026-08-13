using System;
using System.Collections.Generic;
using System.Linq;

public enum ShapeKind { Circle, Rectangle, Triangle }

public abstract class Shape
{
    public ShapeKind Kind { get; protected set; }
    public abstract double Area();
    public abstract double Perimeter();
    public override string ToString() => $"{Kind}: Area={Area():F2}, Perimeter={Perimeter():F2}";
}

public class Circle : Shape
{
    public double Radius { get; }
    public Circle(double radius) { Radius = radius; Kind = ShapeKind.Circle; }
    public override double Area() => Math.PI * Radius * Radius;
    public override double Perimeter() => 2 * Math.PI * Radius;
}

public class Rectangle : Shape
{
    public double Width { get; }
    public double Height { get; }
    public Rectangle(double width, double height) { Width = width; Height = height; Kind = ShapeKind.Rectangle; }
    public override double Area() => Width * Height;
    public override double Perimeter() => 2 * (Width + Height);
}

public class Triangle : Shape
{
    public double A { get; }
    public double B { get; }
    public double C { get; }
    public Triangle(double a, double b, double c) { A = a; B = b; C = c; Kind = ShapeKind.Triangle; }
    public override double Area() { double s = (A + B + C) / 2; return Math.Sqrt(s * (s - A) * (s - B) * (s - C)); }
    public override double Perimeter() => A + B + C;
}

public struct BoundingBox
{
    public double Width;
    public double Height;
    public BoundingBox(double width, double height) { Width = width; Height = height; }
    public static BoundingBox operator *(BoundingBox box, double factor) => new BoundingBox(box.Width * factor, box.Height * factor);
}

public static class ShapeMath
{
    public static double TotalArea(IEnumerable<Shape> shapes) => shapes.Sum(s => s.Area());
    public static double TotalArea(IEnumerable<Shape> shapes, ShapeKind onlyKind) => shapes.Where(s => s.Kind == onlyKind).Sum(s => s.Area());
}

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape> { new Circle(3), new Rectangle(4, 6), new Triangle(3, 4, 5) };

        foreach (Shape shape in shapes)
            Console.WriteLine(shape);

        Console.WriteLine();
        Console.WriteLine($"Total area (all shapes): {ShapeMath.TotalArea(shapes):F2}");
        Console.WriteLine($"Total area (circles only): {ShapeMath.TotalArea(shapes, ShapeKind.Circle):F2}");
        Console.WriteLine();

        BoundingBox box = new BoundingBox(4, 3);
        BoundingBox scaled = box * 2;
        Console.WriteLine($"Scaled bounding box (4 x 3) * 2 -> ({scaled.Width:0}, {scaled.Height:0})");
    }
}
