using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");
        Console.WriteLine("=========================================================================");
        Console.WriteLine();


        List<Activity> activities = new List<Activity>();

        // Swimming
        DateTime swimmingDate = new DateTime(2025, 12, 8);
        TimeSpan swimmingStartTime = new TimeSpan(17, 00, 0);
        TimeSpan swimmingEndTime = new TimeSpan(18, 10, 0);
        int lapCount = 50;

        Swimming swimming = new Swimming(swimmingDate, swimmingStartTime, swimmingEndTime, lapCount);
        activities.Add(swimming);
        // EXPECTED OUTPUT: 08 Dec 2025 Swimming (70 mins) - Distance: 2.5 km, Speed: 2.14 kph, Pace: 28 min per km
        
        // Running
        DateTime runningDate = new DateTime(2025, 12, 9);
        TimeSpan runningStartTime = new TimeSpan(10, 15, 0);
        TimeSpan runningEndTime = new TimeSpan(10, 50, 0);
        double runningDistance = 10;
        
        Running running = new Running(runningDate, runningStartTime, runningEndTime, runningDistance);
        activities.Add(running);
        // EXPECTED OUTPUT: 09 Dec 2025 Running (35 mins) - Distance : 10 km, Speed: 17.14 kph, Pace: 3.5 min per km

        // Cycling
        DateTime cyclingDate = new DateTime(2025, 12, 10);
        TimeSpan cyclingStartTime = new TimeSpan(11, 30, 0);
        TimeSpan cyclingEndTime = new TimeSpan(15, 00, 0);
        double cyclingSpeed = 20;

        Cycling cycling = new Cycling(cyclingDate, cyclingStartTime, cyclingEndTime, cyclingSpeed);
        activities.Add(cycling);
        // EXPECTED OUTPUT: 10 Dec 2025 Cycling (210 mins) - Distance: 70 km, Speed: 20 kph, Pace: 3 min per km


        foreach (Activity activity in activities)
        {
            activity.GetSummary();
        }
    }
}