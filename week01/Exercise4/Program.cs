using System;

using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        // Creates an empty list
        List<float> numbers = new List<float>();

        // Asks for a list of numbers
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        Console.Write("Enter a number: ");
        string entry = Console.ReadLine();

        // Converts the string to a float
        float numeric = float.Parse(entry);

        while (numeric != 0)
        {
            // Adds the numbers in the list
            numbers.Add(numeric);

            // Asks for another number
            Console.Write("Enter a number: ");
            entry = Console.ReadLine();

            // Converts the string to a float
            numeric = float.Parse(entry);
        }

        Console.WriteLine("\n Your list:");

        // Prints the list
        foreach (float number in numbers)
        {
            Console.WriteLine(number);
        }

        // Gets the total of the numbers in the list
        float sum = 0;
        foreach (float number in numbers)
        {
            sum = sum + number;
        }

        // Gets the average
        float average = sum / numbers.Count;

        // Identifies the largest number
        float max = -999999999999999;

        foreach (float number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        // Identifies the smallest positive number
        float minPositive = 999999999999999;

        foreach (float number in numbers)
        {
            if (number > 0 && number < minPositive)
            {
                minPositive = number;
            }
        }

        // Prints the sum, average, largest number, the smallest positive number
        Console.WriteLine($"\nSum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Largest Number: {max}");
        Console.WriteLine($"Smallest Positive Number: {minPositive}");


        // Arranges the numbers in the list in ascending order
        numbers.Sort();

        // Prints the list in ascending order
        Console.WriteLine("\nAscending Order:");
        foreach (float number in numbers)
        {
            Console.WriteLine(number);
        }

        // Arranges the numbers in the list in descending order
        numbers.Reverse();

        // Prints the list in descending order
        Console.WriteLine("\nDescending Order:");
        foreach (float number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}