using System;

public class Activity
{
    // attributes (member variables)
    protected string _activityName;
    protected string _activityDescription;
    protected int _activityDuration;

    // constructors
    public Activity()
    {
        
    }

    // behaviors (methods)
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_activityName} Activity!\n");
        Console.WriteLine(_activityDescription);
        Console.Write("\nHow long (in seconds) should the session be? ");
        _activityDuration = int.Parse(Console.ReadLine());

        Console.Clear();

        Console.WriteLine("Get ready. . .");
    }

    public void ShowCountdownTimer(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void ShowAnimation(int seconds)
    {
        List<string> animationCharacters = new List<string>();
        animationCharacters.Add("|");
        animationCharacters.Add("/");
        animationCharacters.Add("—");
        animationCharacters.Add("\\");
        animationCharacters.Add("|");
        animationCharacters.Add("/");
        animationCharacters.Add("—");
        animationCharacters.Add("\\");

        foreach (string character in animationCharacters)
        {
            Console.Write(character);
            Thread.Sleep(1000 * seconds);
            Console.Write("\b \b");
        }
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\nWell done!\nYou have completed {_activityDuration} seconds of the {_activityName} Activity.");
    }
}