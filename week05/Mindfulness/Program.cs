using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        Console.WriteLine();

        string choice = ShowMenu();

        // Breathing Activity
        if (choice == "1")
        {
            // write the code here
        }

        // Reflecting Activity
        else if (choice == "2")
        {
            // write the code here
        }

        // Listing Activity
        else if (choice == "3")
        {
            // write the code here
        }

        // Quit
        else if (choice == "4")
        {
            // write the code here
        }

        // Wrong Input
        else
        {
            // write the code here
        }
    }

    static string ShowMenu()
    {
        Console.WriteLine("==============================================================================================");
        Console.WriteLine("\nWhat would you like to do?\n");


        // Shows the Menu
        Console.WriteLine
        ("Menu Options:\n   1. Breathing Activity\n    2. Reflecting Activity\n 3. Listing Activity\n   4. Quit");

        Console.WriteLine();
        Console.Write("\nType the NUMBER of your CHOICE. ");

        // Asks for the task
        string choice = Console.ReadLine();
        return choice;
    }
}