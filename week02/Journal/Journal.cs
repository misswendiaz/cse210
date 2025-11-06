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

    // constructor
    public Journal()
    {
        _entries = new List<Entry>();
    }

    // behaviors (methods)
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
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
        Console.WriteLine("Saving file...");

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }

        Console.WriteLine("\nFile saved!");
    }

    public void LoadJournal(string fileName)
    {
        Console.WriteLine($"Loading file [{fileName}]...");

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