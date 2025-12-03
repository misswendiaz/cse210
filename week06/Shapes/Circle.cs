using System;

public class Circle : Shape
{
    // attributes (member variables)
    private double _radius;

    // constructors
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // behaviors (methods)
    public override double GetArea()
    {
        double area = Math.PI * Math.Pow(_radius, 2);
        return area;
    }
}