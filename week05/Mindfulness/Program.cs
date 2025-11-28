using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        Console.WriteLine();

        string choice = ShowMenu();


        while(true)
        {
            // Breathing Activity
            if (choice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.RunBreathingActivity();

            }

            // Reflecting Activity
            else if (choice == "2")
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.RunReflectingActivity();
            }

            // Listing Activity
            else if (choice == "3")
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.RunListingActivity();
            }

            // Grounding Activity
            else if (choice == "4")
            {
                GroundingActivity groundingActivity = new GroundingActivity();
                groundingActivity.RunGroundingActivity();
            }

            // Deep Seeing Activity
            else if (choice == "5")
            {
                // write the code here
            }

            // Deep Listening Activity
            else if (choice == "6")
            {
                // write the code here
            }

            // Quit
            else if (choice == "7")
            {
                Console.WriteLine("\nExiting the Mindfulness Program. . .");
                // Counts down
                for (int i = 3; i >= 1; i--)
                {
                    Console.WriteLine(".");
                    Thread.Sleep(1000);
                }

                // Thank you and Goodbye messages
                Console.WriteLine("Thank you!");
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
            }

            // Wrong Input
            else
            {
                Console.WriteLine("\nInvalid option! Please enter a number from 1 to 7.");

                Console.WriteLine("==============================================================================================");
            }

            Console.WriteLine();
            choice = ShowMenu();
            Console.WriteLine();
        }
    }

    static string ShowMenu()
    {
        Console.WriteLine("==============================================================================================");
        Console.WriteLine("\nWhat would you like to do?\n");


        // Shows the Menu
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflecting Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Grounding Activity");
        // The 5-4-3-2-1 Grounding Technique: Bring yourself to the present moment by identifying five things you can see, four things you can feel, three things you can hear, two things you can smell, and one thing you can taste.
        Console.WriteLine("5. Deep Seeing Activity");
        // Deep Seeing/Listening: Pick an everyday object or a sound and focus all your attention on it for a few minutes, noticing details you might typically miss.
        Console.WriteLine("6. Deep Listening Activity");
        Console.WriteLine("7. Quit");

        Console.WriteLine();
        Console.Write("\nType the NUMBER of your CHOICE. ");

        // Asks for the task
        string choice = Console.ReadLine();
        return choice;
    }
}