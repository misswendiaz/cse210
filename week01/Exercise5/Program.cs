using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");

        DisplayWelcome();
        string name = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int square = SquareNumber(favoriteNumber);
        DisplayResult(name, square);



    }

    // Welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Asks for the name
    static string PromptUserName()
    {
        Console.Write("Your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Asks for the favorite number
    static int PromptUserNumber()
    {
        Console.Write("Your favorite number: ");
        string response = Console.ReadLine();

        // Converts the response to a number
        int favoriteNumber = int.Parse(response);
        return favoriteNumber;
    }

    // Squares the number
    static int SquareNumber(int favoriteNumber)
    {
        int square = favoriteNumber * favoriteNumber;
        return square;
    }


    // Prints results
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }

}