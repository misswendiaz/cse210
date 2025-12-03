using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello World! This is the Shapes Project.");
        Console.WriteLine();
        Console.WriteLine("===========================================");

        Square square = new Square("blue", 5);
        // string squareColor = square.GetColor();
        // double squareArea = square.GetArea();
        // Console.WriteLine($"This {squareColor} square has an area of {squareArea} square units.");

        Rectangle rectangle = new Rectangle("green", 3, 4);
        // string rectangleColor = rectangle.GetColor();
        // double rectangleArea = rectangle.GetArea();
        // Console.WriteLine($"This {rectangleColor} rectangle has an area of {rectangleArea} square units.");

        Circle circle = new Circle("red", 10);
        // string circleColor = circle.GetColor();
        // double circleArea = circle.GetArea();
        // Console.WriteLine($"This {circleColor} circle has an area of {circleArea} square units.");

        List<Shape> list = new List<Shape>();
        list.Add(square);
        list.Add(rectangle);
        list.Add(circle);

        foreach (Shape shape in list)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"This {color} {shape} has an area of {area} square units.");
        }

    }
}