using System;

public class Square : Shape
{
    // attributes (member variables)
    private double _side;

    // constructors
    public Square(string color, double side) : base (color)
    {
        _side = side;
    }

    // behaviors (methods)
    public override double GetArea()
    {
        double area = Math.Pow(_side, 2);
        return area;
    }
}