using System;
using System.Collections.Generic;

public class Prompt
{
    // attributes (member variables)
    private List<string> _questions;
    private Random _random;

    // constructor
    public Prompt()
    {
        // initializes the random generator
        _random = new Random();

        // question list
        _questions = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What made me smile today?",
            "What is something I am grateful for today?",
            "What promptings/revelations have I received today?",
            "What did I do today that helped me draw closer to Him or be more like Him?",
            "What will make this day better?",
            "What went well today?"
        };
    }
    
    // behaviors (methods) - picks a random prompt question
    public string Pick()
    {
        int count = _questions.Count;
        int i = _random.Next(0, count);
        return _questions[i];
    }
}