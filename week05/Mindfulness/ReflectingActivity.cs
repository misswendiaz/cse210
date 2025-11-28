using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    // attributes (member variables)
    private List<string> _reflectionPrompts;
    private List<string> _followUpQuestions;
    private Random _random;

    // constructors
    public ReflectingActivity()
    {
        _activityName = "Reflecting";
        _activityDescription = "This activity will help you reflect on times in your life when you have shown strength and resilience.\nThis will help you recognize the power you have and how you can use it in other aspects of your life.\nNOTE: This activity takes at least 20 seconds.";
        
        // initializes the random generator
        _random = new Random();

        // reflection prompts list
        _reflectionPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        // follow up questions list
        _followUpQuestions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was completed?",
            "What made this time different than other times when you were not as successful?",
            "What is you favorite about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    // behaviors (methods)
    public void RunReflectingActivity()
    {
        // Shows the starting message
        DisplayStartingMessage();
        ShowAnimation(3);

        // Shows a random reflection prompt
        PickReflectionPrompt();
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine("========================================================================================================================");
        DisplayReflectionPrompt();
        Console.WriteLine("========================================================================================================================");
        Console.WriteLine("\nWhen you have something in mind, press ENTER to continue.");

        // Waits for the enter key to be pressed
        string enterKey = Console.ReadLine();

        if (string.IsNullOrEmpty(enterKey))
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_activityDuration);

            Console.Clear();

            // Shows random follow up questions
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience:");

            while (DateTime.Now < endTime)
            {
                PickFollowUpQuestion();
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                DisplayFollowUpQuestion();
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                ShowAnimation(5);
            }
        }

        // Shows the ending message
        DisplayEndingMessage();
    }

    public string PickReflectionPrompt()
    {
        int reflectionPromptsCount = _reflectionPrompts.Count;
        int randomReflectionPromptIndex = _random.Next(0, reflectionPromptsCount);
        return _reflectionPrompts[randomReflectionPromptIndex];
    }

    public void DisplayReflectionPrompt()
    {
        Console.WriteLine(PickReflectionPrompt());
    }

    public string PickFollowUpQuestion()
    {
        int followUpQuestionsCount = _followUpQuestions.Count;
        int randomFollowUpQuestionIndex = _random.Next(0, followUpQuestionsCount);
        return _followUpQuestions[randomFollowUpQuestionIndex];
    }

    public void DisplayFollowUpQuestion()
    {
        Console.WriteLine(PickFollowUpQuestion());
    }
}