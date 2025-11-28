using System;

public class DeepListeningActivity : Activity
{
    // attributes (member variables)

    // constructor
    public DeepListeningActivity()
    {
        _activityName = "Deep Listening";
        _activityDescription = "This activity will help you focus on the present moment by concentrating on sounds, which reduces stress and anxiety and improves emotional regulation.\nNOTE: One cycle of this activity takes 50 seconds.";
    }

    // behaviors (methods)
    public void RunDeepListeningActivity()
    {
        // Shows the starting message
        DisplayStartingMessage();
        ShowAnimation(3);

        // Walk through in the breathing activity
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_activityDuration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Find a quiet place to sit comfortably or lie down.");
            Console.WriteLine();
            ShowAnimation(10);

            Console.WriteLine("Close your eyes and take a few deep, mindful breaths to center yourself in the present moment.");
            Console.WriteLine();
            ShowAnimation(15);

            Console.WriteLine("Tune in to the sounds around you, starting with the immediate environment (e.g., the hum of a refrigerator, a ticking clock) and expanding to external sounds (traffic, birds, wind).");
            Console.WriteLine();
            ShowAnimation(5);

            Console.WriteLine("Listen with CURIOSITY, noticing how each sound ARISES, LINGERS, and FADES AWAY, as if hearing it for the very first time.");
            Console.WriteLine();
            ShowAnimation(5);

            Console.WriteLine("Avoid labeling or judging the sounds as 'good' or 'bad'; simply OBSERVE them as they are.");
            Console.WriteLine();
            ShowAnimation(5);

            Console.WriteLine("Gently guide your attention back to the sounds whenever you notice your mind wandering into thoughts or worries.\nNoticing the wandering is part of the practice.");
            Console.WriteLine();
            ShowAnimation(5);

            Console.WriteLine("Slowly open your eyes and notice how you feel.");
            Console.WriteLine();
            ShowAnimation(5);
        }

        Console.Clear();

        // Shows the ending message
        DisplayEndingMessage();
    }
}