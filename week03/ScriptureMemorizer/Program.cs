using System;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;


// for the timer
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");

            // Welcome message
            Console.WriteLine("\nWelcome to Scripture Memorizer!");


            string book = "";
            int chapter = 0;
            int startVerse = 0;
            int? endVerse = null;
            string passage = "";

            // Menu
            string choice = "";

            while (true)
            {
                // Type
                if (choice == "1")
                {
                    // Asks for the reference
                    Console.WriteLine("\nType the REFEREBCE.");
                    Console.Write("Book: ");
                    book = Console.ReadLine();

                    Console.WriteLine();
                    Console.Write("Chapter: ");
                    chapter = int.Parse(Console.ReadLine());

                    Console.Write("Start Verse: ");
                    startVerse = int.Parse(Console.ReadLine());

                    Console.Write("End Verse (if there is none, just press ENTER): ");
                    string endVerseString = Console.ReadLine();

                    if (!string.IsNullOrEmpty(endVerseString))
                    // https://learn.microsoft.com/en-us/dotnet/api/system.string.isnullorempty?view=net-9.0
                    {
                        endVerse = int.Parse(endVerseString);
                    }

                    // Asks for the scripture passage
                    Console.WriteLine("Passage:");
                    passage = Console.ReadLine();

                    break;
                }

                // Choose
                else if (choice == "2")
                {
                    Console.WriteLine("Choose the scripture passage you want to memorize.");

                    // Shows a list of the scripture mastery
                    Passages passages = new Passages();
                    List<Reference> references = passages.GetAllReferences();
                    for (int i = 0; i < references.Count; i++)
                    {
                        Console.WriteLine($"[{i + 1}] {references[i].GetReference()}");
                    }

                    Console.Write("\nType the NUMBER of your CHOICE. ");
                    int scriptureIndex = int.Parse(Console.ReadLine()) - 1;

                    // Extracts the scripture mastery details from the choice
                    Reference chosenReference = references[scriptureIndex];
                    passage = passages.GetPassage(chosenReference);
                    book = chosenReference.Book;
                    chapter = chosenReference.Chapter;
                    startVerse = chosenReference.StartVerse;
                    endVerse = chosenReference.EndVerse;

                    break;
                }

                // Pick randomly
                else if (choice == "3")
                {
                    // Randomly chooses the scripture passage
                    Passages passages = new Passages();
                    var pickedPassage = passages.Pick();


                    // Extracts the reference from the randomly selected scripture mastery
                    Reference pickedReference = pickedPassage.Key;
                    passage = pickedPassage.Value;
                    book = pickedReference.Book;
                    chapter = pickedReference.Chapter;
                    startVerse = pickedReference.StartVerse;
                    endVerse = pickedReference.EndVerse;

                    break;
                }

                // Wrong input
                else
                {
                    Console.WriteLine("\nInvalid option! Please enter a number from 1 to 3.");

                    Console.WriteLine("==============================================================================================");
                }

                Console.WriteLine();
                choice = ShowMenu();
                Console.WriteLine();
            }


            // Asks for the number of words to be hidden every time ENTER is pressed
            Console.Write("\nEnter the MAXIMUM NUMBER of WORDS to be HIDDEN every time the ENTER key is pressed: ");
            string hideQuantityString = Console.ReadLine();

            // Converts the number of words to be hidden from string to int
            int hideQuantity = int.Parse(hideQuantityString);


            Reference reference;
            if (endVerse.HasValue)
            // https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1.hasvalue?view=net-10.0
            {
                reference = new Reference(book, chapter, startVerse, endVerse.Value);
            }
            else
            {
                reference = new Reference(book, chapter, startVerse);
            }

            Scripture scripture = new Scripture(reference, passage);

            // Shows the full scripture passage
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // Words-hiding loop
            while (true)
            {
                // Asks for the next step
                Console.WriteLine("\nPress ENTER to continue or type QUIT to close the Scripture Memorizer.");
                string response = Console.ReadLine();

                // Detects pressing the "Enter" key without typying anything
                if (string.IsNullOrEmpty(response))
                {
                    // Checks if all the words are already hidden
                    if (scripture.IsCompletelyHidden())
                    {
                        // Safely exits the program
                        Console.WriteLine("\nCongratulations! You now memorized the scripture passage!");

                        // Shows option to run the Scripture Memorizer again
                        Console.Write("\nDo you want to memorize another one or the same passage? (Y/N) ");
                        string again = Console.ReadLine().Trim().ToUpper();

                        // Validates the confirmation response
                        while (again != "Y")
                        {
                            if (again == "N")
                            {
                                Console.WriteLine("\nExiting the Scripture Memorizer. . .");
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
                            else
                            {
                                Console.Write("\nDo you want to memorize another one or the same passage? (Y/N) ");
                                again = Console.ReadLine().Trim().ToUpper();
                            }
                        }

                        if (again == "Y")
                        {
                            break;
                        }
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




    static string ShowMenu()
    {
        Console.WriteLine("==============================================================================================");
        Console.WriteLine("\nWhat would you like to do?\n");


        // Shows the Menu
        Console.WriteLine("1. Type the scripture mastery on my own.");
        Console.WriteLine("2. Choose a scripture mastery from a list.");
        Console.WriteLine("3. Randomly pick a scripture mastery from the list.");

        Console.WriteLine();
        Console.Write("\nType the NUMBER of your CHOICE. ");

        // Asks for the task
        string choice = Console.ReadLine();
        return choice;
    }

}

// Further Improvements in the Future
// 1. Option to add a scripture mastery manually
// 2. Option to unhide words
    // a. Press ENTER to continue
    // b. Press BACKSPACE to unhide recently hidden words
    // c. Press ESC to quit