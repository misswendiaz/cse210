using System;
using System.Diagnostics.Contracts;

public class Entry
{
    // attributes (member variables)
    public string _date;
    public string _prompt;
    public string _response;

    // constructor
    public Entry()
    {
        
    }

    // behaviors (methods)
    public void DisplayEntry()
    {
        Console.WriteLine("-----------------------------------------------------------------------------------------");
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine("-----------------------------------------------------------------------------------------");
    }
}