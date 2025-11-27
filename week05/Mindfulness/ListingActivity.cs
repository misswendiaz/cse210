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
        // write the code here
    }

    public string PickListPrompt()
    {
        int listPromptsCount = _listPrompts.Count;
        int randomListPromptIndex = _random.Next(0, listPromptsCount);
        return _listPrompts[randomListPromptIndex];
    }

    public List<string> GetItemList()
    {
        List<string> itemList = new List<string>();
        // write code here
        return itemList;
    }
}