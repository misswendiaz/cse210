using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello World! This is the Homework Project.");
        Console.WriteLine();

        // First Assignment - testing the base class
        Assignment assignment1 = new Assignment("Samuel Bennett", "Multiplication");
        assignment1.GetSummary();

        Console.WriteLine();

        // Second Assignment - testing the MathAssignment derived class
        MathAssignment assignment2 = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3", "Problems 8-19");
        assignment2.GetSummary();
        assignment2.GetHomeworkList();

        Console.WriteLine();

        // Third Assignment - testing the WritingAssignment derived class
        WritingAssignment assignment3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        assignment3.GetSummary();
        assignment3.GetWritingInformation();

        Console.WriteLine();
    }
}