using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        // Asks for the user's grade percentage
        Console.Write("Type your grade percentage without the % symbol. ");

        string gradePercentage = Console.ReadLine();

        // Converts the user's input to a float
        float grade = float.Parse(gradePercentage);

        float remainder = grade % 10;

        // Determines the corresponding letter grade
        string letterGrade;

        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade < 90 && grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade < 80 && grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade < 70 && grade >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        // Determines the sign
        string sign;

        if (remainder >= 7 && letterGrade != "A" && letterGrade != "F")
        {
            sign = "+";
        }
        else if (remainder < 3 && letterGrade != "F")
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        Console.WriteLine($"Letter Grade: {letterGrade}{sign}");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("See you next term!");
        }
        


    }
}