using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("blue", 2.2);
        // Console.WriteLine($"square color: {square.GetColor()} square area: {square.GetArea()}");

        Rectangle rectangle = new Rectangle("red", 5, 3.5);
        // Console.WriteLine($"rectangle color: {rectangle.GetColor()} rectangle area: {rectangle.GetArea()}");

        Circle circle = new Circle ("yellow", 6.3);
        // Console.WriteLine($"circle color: {circle.GetColor()} circle area: {circle.GetArea()}");

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"The {shape.GetColor()} shape has an area of {shape.GetArea()}.");
        }
    }
}