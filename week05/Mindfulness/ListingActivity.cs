using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    // attributes (member variables)
    private int _itemCount;
    private List<string> _listPrompts;

    private Random _random;

    // constructors
    public ListingActivity()
    {
        _activityName = "Listing";
        _activityDescription = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        // initializes the random generator
        _random = new Random();

        // question list
        _listPrompts = new List<string>
        {
            "Who are the people that you appreciate?",
            "What are your personal strengths?",
            "Who are the people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    // behaviors (methods)
    public void RunListingActivity()
    {
        // Shows the starting message
        DisplayStartingMessage();
        ShowAnimation(3);

        // Shows a random listing prompt
        Console.WriteLine("List as many responses you can to the following prompt:\n");
        Console.WriteLine("========================================================================================================================");
        Console.WriteLine(PickListingPrompt());
        Console.WriteLine("========================================================================================================================");
        Console.Write("\nYou may begin in: ");
        Console.WriteLine();
        
        ShowCountdownTimer(5);

        List<string> itemList = GetItemList();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_activityDuration);
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            itemList.Add(item);
        }

        // Display item count
        _itemCount = itemList.Count();
        Console.WriteLine($"\nYou listed {_itemCount} items.");
        ShowAnimation(5);

        // Shows the ending message
        DisplayEndingMessage();
    }

    public string PickListingPrompt()
    {
        int listPromptsCount = _listPrompts.Count;
        int randomListPromptIndex = _random.Next(0, listPromptsCount);
        return _listPrompts[randomListPromptIndex];
    }

    public List<string> GetItemList()
    {
        List<string> itemList = new List<string>();
        return itemList;
    }
}