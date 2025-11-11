using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");

        Console.WriteLine();


        // First Constructor
        Fraction fraction1 = new Fraction();
        Console.WriteLine("Using the First Constructor: No Argument");
        Console.WriteLine($"Fraction: {fraction1.GetFraction()}");
        Console.WriteLine($"Decimal Value: {fraction1.GetDecimalValue()}");

        // Second Constructor
        Fraction fraction2 = new Fraction(6);
        Console.WriteLine("\nUsing the Second Constructor: One Argument");
        Console.WriteLine(fraction2.GetFraction());
        Console.WriteLine(fraction2.GetDecimalValue());

        // Third Constructor
        Fraction fraction3 = new Fraction(6, 7);
        Console.WriteLine("\nUsing the Third Constructor: Two Arguments");
        Console.WriteLine(fraction3.GetFraction());
        Console.WriteLine(fraction3.GetDecimalValue());

        // Using Setters and Getters
        Fraction fraction4 = new Fraction();
        fraction4.SetNumerator(3);
        fraction4.SetDenominator(4);
        Console.WriteLine("\nUsing Setters and Getters");
        Console.WriteLine($"Numerator: {fraction4.GetNumerator()}");
        Console.WriteLine($"Denominator: {fraction4.GetDenominator()}");
        Console.WriteLine($"Fraction: {fraction4.GetFraction()}");
        Console.WriteLine($"Decimal Value: {fraction4.GetDecimalValue()}");
    }
}