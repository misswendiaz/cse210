using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");

        string choice = ShowMenu();

        while (choice != "5")
        {
            // 1. Write
            if (choice == "1")
            {

            }

            // 2. Display
            else if (choice == "2")
            {

            }

            // 3. Load
            else if (choice == "3")
            {

            }

            // 4. Save
            else if (choice == "4")
            {

            }

            // Wrong Input
            else
            {
                // use try catch here
            }
        }

        // 5. Quit
        

        
        
        

       
    }
    
    static string ShowMenu()
    {
        Console.WriteLine("\nWhat would you like to do?\n");


        // Shows the Menu
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Show");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");

        Console.WriteLine();

        // Asks for the task
        string choice = Console.ReadLine();
        return choice;
    }
}