using System;

public class GroundingActivity : Activity
{
    // attributes (member variables)

    // constructors
    public GroundingActivity()
    {
        _activityName = "Grounding";
        _activityDescription = "This activity will help you stay in the present moment, which calms the nervous system, reduces feelings of anxiety and overwhelm, and improves emotional regulation.\nNOTE: One cycle takes around 50 seconds.";
    }
    
    // behaviors (methods)
    public void RunGroundingActivity()
    {
        // Shows the starting message
        DisplayStartingMessage();
        ShowAnimation(3);

        // Walk through in the breathing activity
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_activityDuration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nTake a few slow, deep breaths.\nInhale through your nose and exhale through your mouth, focusing on the sensation of your breath.\n");
            ShowAnimation(18);
            Console.WriteLine();

            Console.WriteLine("\nLook around your environment and name FIVE (5) different things you can see.\nBe specific, like 'a red lamp' or 'a dusty bookshelf'.\n");
            ShowAnimation(10);
            Console.WriteLine();

            Console.WriteLine("\nBring your attention to FOUR (4) things you can physically feel.\nThis could be the texture of your clothes, the chair you're sitting on, or the warmth of your own hands.\n");
            ShowAnimation(8);
            Console.WriteLine();

            Console.WriteLine("\nListen to your surroundings and identify THREE (3) distinct sounds.\nThis might include a clock ticking, traffic outside, or the hum of a computer.\n");
            ShowAnimation(6);
            Console.WriteLine();

            Console.WriteLine("\nPay attention to the scents around you.\nIf you can't smell anything, think of TWO (2) smells you like, such as pine trees or freshly baked bread.\n");
            ShowAnimation(4);
            Console.WriteLine();

            Console.WriteLine("\nFocus on ONE (1) thing you can taste in the moment.\nIf you're not eating or drinking, consider the taste of toothpaste, gum, or even air.\n");
            ShowAnimation(2);
            Console.WriteLine();

            Console.WriteLine("\nTake one final deep breath to re-center yourself before returning to your day.\n");
            ShowAnimation(6);
            Console.WriteLine();
        }

        Console.Clear();

        // Shows the ending message
        DisplayEndingMessage();
    }
}