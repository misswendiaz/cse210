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
    public void Reflect()
    {
        // write the code here
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
        return _reflectionPrompts[randomFollowUpQuestionIndex];
    }

    public void DisplayFollowUpQuestion()
    {
        Console.WriteLine(PickFollowUpQuestion());
    }
}