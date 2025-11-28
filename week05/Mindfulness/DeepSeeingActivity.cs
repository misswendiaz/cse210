using System;

public class DeepSeeingActivity : Activity
{
    // attributes (member variables)

    // constructors
    public DeepSeeingActivity()
    {
        _activityName = "Deep Seeing";
        _activityDescription = "This activity will help you train your mind to focus on the present by observing surroundings without judgment.\nNOTE: One cycle of this activity takes 40 seconds.";
    }

    // behaviors (methods)
    public void RunDeepSeeingActivity()
    {
        // Shows the starting message
        DisplayStartingMessage();
        ShowAnimation(3);

        // Walk through in the breathing activity
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_activityDuration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Find a place with a view, such as a window or a spot outdoors.");
            Console.WriteLine();
            ShowAnimation(10);

            Console.WriteLine("Choose an object to focus (e.g., a leaf, a flower, a shadow).");
            Console.WriteLine();
            ShowAnimation(5);

            Console.WriteLine("Look closely at the object, noticing its details.");
            Console.WriteLine();
            ShowAnimation(5);

            Console.WriteLine("Avoid mentally labelling or categorizing what you see (e.g., instead of thinking 'tree', notice the specific texture of the bark, the variety of green shades, the way the leaves move in the wind).");
            Console.WriteLine();
            ShowAnimation(5);

            Console.WriteLine("Pay attention to the COLORS, PATTERNS, TEXTURES, and SHAPES as if you are seeing them for the first time.");
            Console.WriteLine();
            ShowAnimation(5);

            Console.WriteLine("Be OBSERVANT, not critical or analytical.\nSimply allow the visual information to enter your awareness.");
            Console.WriteLine();
            ShowAnimation(5);

            Console.WriteLine("If your mind wanders, gently bring your attention back to the visual details of your chosen object.");
            Console.WriteLine();
            ShowAnimation(5);
        }

        // Shows the ending message
        DisplayEndingMessage();
    }
}