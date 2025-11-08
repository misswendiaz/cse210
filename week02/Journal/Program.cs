// ===EXceeding Requirements===
// -  added an error input message

using System;
using System.IO.Enumeration;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");

        // Creates the journal
        Journal journal = new Journal();

        string choice = ShowMenu();

        while (true)
        {
            // 1. Add an Entry
            if (choice == "1")
            {
                Entry entry = new Entry();

                // Gets the current date
                DateTime now = DateTime.Now;
                entry._date = now.ToString("MMMM dd, yyyy - HH:mm");
                Console.WriteLine($"Date: {entry._date}");

                // Initializes the prompt question
                Prompt question = new Prompt();
                entry._prompt = question.Pick();
                Console.WriteLine("\nPrompt:");
                Console.WriteLine(entry._prompt);

                // Asks for the entry
                Console.WriteLine("\nEntry:");
                entry._response = Console.ReadLine();

                // Adds the entry to the list of entries
                journal.AddEntry(entry);

                Console.WriteLine("==============================================================================================");
            }

            // 2. Edit an Entry
            else if (choice == "2")
            {
                // Asks for the specific entry to edit using the date
                Console.WriteLine("Type the entry date and time that you would like to EDIT. (e.g. November 08, 2025 - 16:52)");
                string dateTime = Console.ReadLine();

                // Validates the date format
                // https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tryparseexact
                DateTime dateValue;
                while (!DateTime.TryParseExact(dateTime, "MMMM dd, yyyy - HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateValue))
                {
                    Console.WriteLine("\nInvalid date and time format! Please use the correct format (e.g. November 08, 2025 - 16:52).");
                    dateTime = Console.ReadLine();
                }

                // Checks if the date exists in the journal
                // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.exists
                bool exists = journal._entries.Exists(entry => entry._date == dateTime);
                if (exists)
                {
                    journal.EditEntry(dateTime);
                }
                else
                {
                    Console.WriteLine("Entry not found!");
                }
            }
            // 3. Delete an Entry
            else if (choice == "3")
            {
                // Asks for the specific entry to edit using the date
                Console.WriteLine("Type the entry date and time that you would like to DELETE. (e.g. November 08, 2025 - 16:52)");
                string dateTime = Console.ReadLine();

                // Validates the date format
                // https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tryparseexact
                DateTime dateValue;
                while (!DateTime.TryParseExact(dateTime, "MMMM dd, yyyy - HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateValue))
                {
                    Console.WriteLine("\nInvalid date and time format! Please use the correct format (e.g. November 08, 2025 - 16:52).");
                    dateTime = Console.ReadLine();
                }

                // Checks if the date exists in the journal
                // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.exists
                bool exists = journal._entries.Exists(entry => entry._date == dateTime);
                if (exists)
                {
                    Console.WriteLine("\nWarning: This action CANNOT be undone! (Deleted entries are IRRECOVERABLE.)");
                    Console.Write($"Are you sure you want to DELETE the entry from {dateTime}? (Y/N): ");

                    string confirmation = Console.ReadLine();
                    string confirmationUpper = confirmation.ToUpper();

                    // Validates the confirmation response
                    while (confirmationUpper != "Y")
                    {
                        if (confirmationUpper == "N")
                        {
                            break;
                        }
                        else
                        {
                            Console.Write($"\nAre you sure you want to DELETE the entry from {dateTime}? (Y/N): ");
                            confirmation = Console.ReadLine();
                            confirmationUpper = confirmation.ToUpper();
                        }
                    }

                    if (confirmationUpper == "Y")
                    {
                        // Deletes the entry
                        journal.DeleteEntry(dateTime);
                    }
                }
                else
                {
                    Console.WriteLine("Entry not found!");
                }
            }

            // // 4. Show All Entries
            else if (choice == "4")
            {
                journal.ShowAllEntries();

                Console.WriteLine("==============================================================================================");
            }

            // 5. Save Journal
            else if (choice == "5")
            {
                Console.Write("File Name: ");
                journal._fileName = Console.ReadLine();

                Console.WriteLine("\nWarning: If a file with this name already exists, it will be OVERWRITTEN.");
                Console.Write("Do you want to proceed? (Y/N): ");

                string confirmation = Console.ReadLine();
                string confirmationUpper = confirmation.ToUpper();

                // Validates the confirmation response
                while (confirmationUpper != "Y")
                {
                    if (confirmationUpper == "N")
                    {
                        break;
                    }
                    else
                    {
                        Console.Write($"\nAre you sure you want to SAVE this journal as {journal._fileName}? (Y/N): ");
                        confirmation = Console.ReadLine();
                        confirmationUpper = confirmation.ToUpper();
                    }
                }

                if (confirmationUpper == "Y")
                {
                    // Saves the journal
                    journal.SaveJournal(journal._fileName);
                }

                Console.WriteLine("==============================================================================================");
            }

            // 6. Load Journal
            else if (choice == "6")
            {
                Console.Write("File Name: ");
                journal._fileName = Console.ReadLine();
                journal.LoadJournal(journal._fileName);

                Console.WriteLine("==============================================================================================");
            }

            // 7. Quit
            else if (choice == "7")
            {

                Console.WriteLine("\nWarning: Exiting this program without saving will LOSE all UNSAVED CHANGES.");

                string exitUpper;
                do
                {
                    Console.Write("Do you want to proceed? (Y/N): ");
                    string exit = Console.ReadLine();
                    exitUpper = exit.ToUpper();

                    if (exitUpper == "N")
                    {
                        Console.WriteLine("\nReturning to the main menu. . .");

                        // Exits the Quit block without ending the program
                        break;
                    }
                    else if (exitUpper != "Y")
                    {
                        Console.WriteLine("\nInvalid input! Please enter Y or N.");
                    }

                }
                while (exitUpper != "Y");

                if (exitUpper == "Y")
                {
                    Console.WriteLine("\nExiting program. . .");
                    Console.WriteLine(".");
                    Console.WriteLine(".");
                    Console.WriteLine(".");
                    Console.WriteLine("Goodbye! (^.^)");

                    // Safely exits the program
                    // https://www.geeksforgeeks.org/c-sharp/c-sharp-program-to-demonstrate-the-use-of-exit-method-of-environment-class/
                    Environment.Exit(0);
                }

                Console.WriteLine("==============================================================================================");
            }

            // Wrong Input
            else
            {
                Console.WriteLine("\nInvalid option! Please enter a number from 1 to 5.");

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
        Console.WriteLine("1. Add an Entry");
        Console.WriteLine("2. Edit an Entry");
        Console.WriteLine("3. Delete an Entry");
        Console.WriteLine("4. Show All Entries");
        Console.WriteLine("5. Save Journal");
        Console.WriteLine("6. Load Journal");
        Console.WriteLine("7. Quit");

        Console.WriteLine();

        // Asks for the task
        string choice = Console.ReadLine();
        return choice;
    }
}