using System;

public class Fraction
{
    //attributes (member variables)
    private int _numerator;
    private int _denominator;

    // constructors
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int number)
    {
        _numerator = number;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    // setters
    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }

    public void SetDenominator(int denominator)
    {
        _denominator = denominator;
    }

    // getters
    public int GetNumerator()
    {
        return _numerator;
    }

    public int GetDenominator()
    {
        return _denominator;
    }


    // behaviors (methods)
    public string GetFraction()
    {
        return _numerator + "/" + _denominator;
    }

    public double GetDecimalValue()
    {
        return (double)_numerator / (double)_denominator;
    }
}