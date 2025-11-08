// ===Exceeding Requirements===
// - added try catch error in LoadJournal

using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // attributes (member variables)
    public string _fileName;
    public List<Entry> _entries;
    public Entry _entry;

    // constructor
    public Journal()
    {
        _entries = new List<Entry>();
    }

    // behaviors (methods)
    public void AddEntry(Entry entry)
    {
        Console.WriteLine("\nAdding entry . . .");
        Console.WriteLine(".");
        Console.WriteLine(".");
        Console.WriteLine(".");
        _entries.Add(entry);
        Console.WriteLine("Entry added!");
    }

    // Edit Entry
    public void EditEntry(string dateTime)
    {
        // Finds the entry with a matching date
        // https://code-maze.com/csharp-update-list-item/
        Entry entryToEdit = _entries.Find(entry => entry._date == dateTime);
        if (entryToEdit != null)
        {

            // Shows the current entry
            Console.WriteLine($"\nCurrent Entry:");
            Console.WriteLine(entryToEdit._date);
            Console.WriteLine(entryToEdit._prompt);
            Console.WriteLine(entryToEdit._response);
            Console.WriteLine();


            Console.WriteLine($"\nEditing Entry from: {entryToEdit._date}...");

            // Gets the prompt for the desired entry
            Console.WriteLine($"Prompt: {entryToEdit._prompt}");

            // Updates entry response
            Console.WriteLine("Updated Response: ");
            string updatedResponse = Console.ReadLine();

            entryToEdit._response = updatedResponse;

            Console.WriteLine($"\nUpdating {entryToEdit._date}. . .");
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine($"\nEntry from {entryToEdit._date} has been updated successfully!");

            // Shows the updated entry
            Console.WriteLine($"\nCurrent Entry:");
            Console.WriteLine(entryToEdit._date);
            Console.WriteLine(entryToEdit._prompt);
            Console.WriteLine(entryToEdit._response);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Entry not found!");
        }
    }

    public void DeleteEntry(string dateTime)
    {
        // Finds the entry with a matching date
        // https://code-maze.com/csharp-update-list-item/
        Entry entryToDelete = _entries.Find(entry => entry._date == dateTime);
        if (entryToDelete != null)
        {

            Console.WriteLine($"\nDeleting {dateTime} entry . . .");
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine("."); 
            _entries.Remove(entryToDelete);
            Console.WriteLine();
            Console.WriteLine($"{entryToDelete._date} entry has been deleted.");
        }
        else
        {
            Console.WriteLine("Entry not found!");
        }
    }

    public void ShowAllEntries()
    {
        try
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("\nNo entries to display!");
            }
            else
            {
                Console.WriteLine("\n===JOURNAL ENTRIES===\n");
                foreach (Entry entry in _entries)
                {
                    entry.DisplayEntry();
                }
                Console.WriteLine($"\nTotal Entries: {_entries.Count}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nAn error occured while displaying the entries:");
            Console.WriteLine(ex.Message);
        }
    }

    public void SaveJournal(string fileName)
    {
        Console.WriteLine($"\nSaving journal as {fileName} . . .");
        Console.WriteLine(".");
        Console.WriteLine(".");
        Console.WriteLine(".");

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }

        Console.WriteLine($"\n{fileName} saved!");
    }

    public void LoadJournal(string fileName)
    {
        Console.WriteLine($"\nLoading {fileName} . . .");
        Console.WriteLine(".");
        Console.WriteLine(".");
        Console.WriteLine(".");

        try
        {
            // Check if the file exists
            if (File.Exists(fileName))
            {
                // Clears the current list before loading
                _entries.Clear();

                // Reads all lines
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        Entry entry = new Entry();
                        entry._date = parts[0];
                        entry._prompt = parts[1];
                        entry._response = parts[2];
                        _entries.Add(entry);
                    }
                }

                Console.WriteLine($"\n{_entries.Count} entries loaded from {fileName}!");
            }
            else
            {
                Console.WriteLine($"Error: The file \"{fileName}\" was not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while loading the file:");
            Console.WriteLine(ex.Message);
        }
    }

}