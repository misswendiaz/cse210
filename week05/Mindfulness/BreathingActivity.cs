using System;
using System.Threading;

public class BreathingActivity : Activity
{
    // attributes (member variables)

    // constructors
    public BreathingActivity()
    {
        _activityName = "Breathing";
        _activityDescription = "This activity will help you relax by walking you through breathing in and out slowly.\nClear your mind and focus on your breathing.\nNOTE: Each cycle lasts 10 SECONDS.";
    }

    // behaviors (methods)
    public void RunBreathingActivity()
    {
        DisplayStartingMessage();
        ShowAnimation(5);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_activityDuration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe IN . . . ");
            ShowCountdownTimer(5);

            Console.Write("\nBreathe OUT . . . ");
            ShowCountdownTimer(5);
            Console.WriteLine();
        }

        Console.Clear(); 
        DisplayEndingMessage();
    }

}