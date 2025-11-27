using System;

public class Activity
{
    // attributes (member variables)
    private string _activityName;
    private string _activityDescription;
    private int _activityDuration;

    // constructors
    public Activity()
    {
        // write the code here
    }

    // behaviors (methods)
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_activityName}!\n");
        Console.WriteLine(_activityDescription);
        Console.WriteLine("\nHow long (in seconds) should the session be?\n");
    }

    public void GetReady(int seconds)
    {
        Console.WriteLine("Get ready. . .");
        // write the countdown timer code here
    }

    public void GetReadyAnimation(int seconds)
    {
        // write the code here
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\nWell done!\nYou have completed {_activityDuration} seconds of the {_activityName}.");
    }
}