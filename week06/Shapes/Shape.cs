using System;
using System.Drawing;

public class Shape
{
    // attributes (member variables)
    private string _color;

    // constructors
    public Shape(string color)
    {
        _color = color;
    }

    // getters
    public string GetColor()
    {
        return _color;
    }

    // setters
    public void SetColor(string color)
    {
        _color = color;
    }

    // behaviors (methods)
    public virtual double GetArea()
    {
        return 0;
    }
}