using System;

public class Rectangle : Shape
{
    // attributes (member variables)
    private double _length;
    private double _width;

    // constructors
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    // behaviors (methods)
    public override double GetArea()
    {
        double area = _length * _width;
        return area;
    }
}