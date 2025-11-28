using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        Console.WriteLine();

        string choice = ShowMenu();


        while (true)
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

            // Grounding Activity - best in audio
            else if (choice == "4")
            {
                GroundingActivity groundingActivity = new GroundingActivity();
                groundingActivity.RunGroundingActivity();
            }

            // Deep Seeing Activity - best in audio
            else if (choice == "5")
            {
                DeepSeeingActivity deepSeeingActivity = new DeepSeeingActivity();
                deepSeeingActivity.RunDeepSeeingActivity();
            }

            // Deep Listening Activity - best in audio
            else if (choice == "6")
            {
                DeepListeningActivity deepListeningActivity = new DeepListeningActivity();
                deepListeningActivity.RunDeepListeningActivity();
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
                Console.Clear();
                Console.WriteLine("\nInvalid option! Please enter a number from 1 to 7.");

                Console.WriteLine("==============================================================================================");

                choice = ShowMenu();
                continue;
            }


            // Shows the option to run the Mindfulness Program again
            if (!Repeat())
            {
                Console.WriteLine("\nExiting the Mindfulness Program. . .");
                // Counts down
                for (int i = 3; i >= 1; i--)
                {
                    Console.WriteLine(".");
                    // Pauses for 1 second = 1000 milliseconds
                    Thread.Sleep(1000);
                    // https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread.sleep?view=net-9.0
                }

                // Thank you and Goodbye messages
                Console.WriteLine("Thank you!");
                Console.WriteLine("Goodbye!");
                Environment.Exit(0);
            }

            Console.Clear();
            choice = ShowMenu();
            continue;
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
        Console.WriteLine("5. Deep Seeing Activity");
        Console.WriteLine("6. Deep Listening Activity");
        Console.WriteLine("7. Quit");

        Console.WriteLine();
        Console.Write("\nType the NUMBER of your CHOICE. ");

        // Asks for the task
        string choice = Console.ReadLine();
        return choice;
    }

    static bool Repeat()
    {
        while (true)
        {
            // Shows option to run the Mindfulness Program again
            Console.Write("\nDo you want to try another mindfulness activity? (Y/N) ");
            string again = Console.ReadLine().Trim().ToUpper();

            if (again == "Y")
            {
                return true;
            }

            else if (again == "N")
            {
                return false;
            }

            else
            {
                Console.Clear(); 
                Console.WriteLine("Invalid input! Please type Y or N.");
            }
        }
    }
}