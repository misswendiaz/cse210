using System;
// for the timer
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

        // Welcome message
        Console.WriteLine("\nWelcome to Scripture Memorizer!");
        Console.WriteLine("Choose the scripture passage that you want to memorize.");

        // Shows the list of scripture passages

        // Receives the response

        // Asks for the number of words to be hidden every time ENTER is pressed
        Console.Write("\nEnter the NUMBER of WORDS to be HIDDEN every time the ENTER key is pressed: ");
        string hideQuantityString = Console.ReadLine();

        // Converts the number of words to be hidden from string to int
        int hideQuantity = int.Parse(hideQuantityString);


        Reference reference = new Reference("Moses", 1, 39);
        string text = "For behold, this is my work and my glory; to bring to pass the immortality and eternal life of man.";

        Scripture scripture = new Scripture(reference, text);

        // Shows the full scripture passage
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();

        while (true)
        {
            // Asks for the next step
            Console.WriteLine("\nPress ENTER to continue or type QUIT to close the Scripture Memorizer.");
            string response = Console.ReadLine();

            // Detects pressing the "Enter" key without typying anything
            if (string.IsNullOrEmpty(response))
            // https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorempty?view=net-9.0
            {
                // Checks if all the words are already hidden
                if (scripture.IsCompletelyHidden())
                {
                    // Safely exits the program
                    Console.WriteLine("\nCongratulations! You now memorized the scripture passage!");
                    Console.WriteLine("Exiting the Scripture Memorizer. . .");
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
                    // https://www.geeksforgeeks.org/c-sharp/c-sharp-program-to-demonstrate-the-use-of-exit-method-of-environment-class/
                    Environment.Exit(0);
                }

                Console.WriteLine("Continuing...");
                Console.WriteLine("Prepare!");
                Console.WriteLine("Memorize the scripture passage.");
                Console.WriteLine("Some words will be hidden in. . .");

                // Counts down
                for (int i = 5; i >= 1; i--)
                {
                    Console.WriteLine($"{i}. . .");
                    // Pauses for 1 second = 1000 milliseconds
                    Thread.Sleep(1000);
                    // https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread.sleep?view=net-9.0
                }

                // Clears the console
                Console.Clear();

                // Hides some words
                scripture.HideWords(hideQuantity);

                // Displays the scripture passage with some hidden words
                Console.WriteLine(scripture.GetDisplayText());



            }
            else if (response.Trim().ToUpper() == "QUIT")
            {
                Console.WriteLine("Exiting the Scripture Memorizer. . .");
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
                break;
            }
            else
            {
                Console.WriteLine($"You typed: '{response}'.");
                Console.WriteLine("Please press ENTER to continue or type QUIT to exit.");
            }
        }


    }
}

// Improvements
// 1. Option to choose and load a scripture mastery
// 2. Option to add a scripture mastery manually
// 3. Option to indicate the number of words to hide
// 4. Option to play again
// 5. Option to unhide words

// Main Menu Options
// 1. Choose scripture mastery
    // a. Indicate the number of words to hide
    // b. Randomly select the number of words to hide

// 2. Randomly choose a scripture mastery
    // a. Indicate the number of words to hide
    // b. Randomly select the number of words to hide

// 3. Manually encode the scripture mastery
    // = one verse
        // - book : string
        // - chapter : int
        // - verse : int
        // - passage : text
    // = multip-verse
        // - book : string
        // - chapter : int
        // - start verse : int
        // - end verse : int
        // - passage : string
    
    // a. Indicate the number of words to hide
    // b. Randomly select the number of words to hide

// === While Playing ===
    // 1. Press ENTER to continue
    // 2. Press BACKSPACE to unhide recently hidden words
    // 3. Press ESC to quit
