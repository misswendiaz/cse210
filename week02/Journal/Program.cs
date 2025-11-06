// ===EXceeding Requirements===
// -  added an error input message

using System;
using System.IO.Enumeration;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");

        // Creates the journal
        Journal journal = new Journal();

        string choice = ShowMenu();

        while (choice != "5")
        {
            // 1. Add Entry
            if (choice == "1")
            {
                Entry entry = new Entry();

                // Gets the current date
                DateTime now = DateTime.Now;
                entry._date = now.ToString("MMMM d, yyyy - HH:mm");
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
                Console.WriteLine("\nEntry added!");

                Console.WriteLine("==============================================================================================");
            }

            // 2. Show All Entries
            else if (choice == "2")
            {
                journal.ShowAllEntries();

                Console.WriteLine("==============================================================================================");
            }

            // 3. Save Journal
            else if (choice == "3")
            {
                Console.Write("File Name: ");
                journal._fileName = Console.ReadLine();
                journal.SaveJournal(journal._fileName);

                Console.WriteLine("==============================================================================================");
            }

            // 4. Load Journal
            else if (choice == "4")
            {
                Console.Write("File Name: ");
                journal._fileName = Console.ReadLine(); 
                journal.LoadJournal(journal._fileName);

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

        // 5. Quit
        

        
        
        

       
    }
    
    static string ShowMenu()
    {
        Console.WriteLine("==============================================================================================");
        Console.WriteLine("\nWhat would you like to do?\n");


        // Shows the Menu
        Console.WriteLine("1. Add Entry");
        Console.WriteLine("2. Show All Entries");
        Console.WriteLine("3. Save Journal");
        Console.WriteLine("4. Load Journal");
        Console.WriteLine("5. Quit");

        Console.WriteLine();

        // Asks for the task
        string choice = Console.ReadLine();
        return choice;
    }
}