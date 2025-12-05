using System;

class Program
{
    static void Main(string[] args)
    {
        bool runAgain = true;

        while (runAgain)
        {
            Console.Clear();
            Console.WriteLine("Hello World! This is the EternalQuest Project.");
            Console.WriteLine();

            try
            {
                GoalManager goalManager = new GoalManager();
                goalManager.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("\nA critical error occured:");
                Console.WriteLine(e.Message);
                Console.WriteLine("\nThe program will now exit. . .");
            }
        }
    }
}