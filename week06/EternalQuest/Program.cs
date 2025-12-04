using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello World! This is the EternalQuest Project.");
        Console.WriteLine();

        GoalManager goalManager = new GoalManager();
        goalManager.Start();

    }
}