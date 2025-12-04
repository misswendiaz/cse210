using System;
using System.Collections.Generic;
using System.Net.Sockets;

public class GoalManager
{
    // attributes (member variables)
    private List<Goal> _goals;
    private int _score;

    // contructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // behaviors (methods)
    public void Start()
    {
        Console.WriteLine("==============================================================================================");
        Console.WriteLine("\nWhat would you like to do?\n");


        // Shows the Menu
        Console.WriteLine("1. Create a New Goal");
        Console.WriteLine("2. Save Goals");
        Console.WriteLine("3. Load Goals");
        Console.WriteLine("4. Show All Goals");
        Console.WriteLine("5. Show All Ongoing Goals");
        Console.WriteLine("6. Show All Completed Goals");
        Console.WriteLine("7. Mark a Goal as DONE");
        Console.WriteLine("8. Mark a Goal as NOT YET DONE");
        Console.WriteLine("9. Edit a Goal");
        Console.WriteLine("10. Delete a Goal");
        Console.WriteLine("11. Quit");

        Console.WriteLine();

        // Asks for the task
        Console.Write("\nChoice: ");
        string choice = Console.ReadLine();
        Console.WriteLine();

        // Create a New Goal
        if (choice == "1")
        {
            CreateGoal();
        }

        // Save Goals
        else if (choice == "2")
        {
            Console.Write("\nFile Name: ");
            string fileName = Console.ReadLine();

            Console.WriteLine($"\nSaving goals as {fileName} . . .");
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine(".");

            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine($"\n{fileName} saved!");
        }

        // Load Goals
        else if (choice == "3")
        {
            Console.Write("\nFile Name: ");
            string fileName = Console.ReadLine();

            Console.WriteLine($"\nLoading {fileName} . . .");
            Console.WriteLine(".");
            Console.WriteLine(".");
            Console.WriteLine(".");

            try
            {
                // Check if the file exists
                if (File.Exists(fileName))
                {
                    // Clears the current list before loading
                    _goals.Clear();

                    // Reads all lines
                    string[] lines = File.ReadAllLines(fileName);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split("|");
                        string type = parts[0];

                        if (type == "Simple Goal")
                        {
                            string name = parts[1];
                            string description = parts[2];
                            int points = int.Parse(parts[3]);
                            bool isComplete = bool.Parse(parts[4]);
                            _goals.Add(new SimpleGoal(name, description, points));
                        }
                        else if (type == "Checklist Goal")
                        {
                            string name = parts[1];
                            string description = parts[2];
                            int points = int.Parse(parts[3]);
                            int target = int.Parse(parts[4]);
                            int bonus = int.Parse(parts[5]);
                            int amountCompleted = int.Parse(parts[6]);
                            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                        }
                        else if (type == "Eternal Goal")
                        {
                            string name = parts[1];
                            string description = parts[2];
                            int points = int.Parse(parts[3]);
                            _goals.Add(new EternalGoal(name, description, points));
                        }
                    }

                    Console.WriteLine($"\n{_goals.Count} entries loaded from {fileName}!");
                }
                else
                {
                    Console.WriteLine($"Error: The file \"{fileName}\" was not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while loading the file:");
                Console.WriteLine(ex.Message);
            }
        }

        // Show All Goals
        else if (choice == "4")
        {
            // code here
        }

        // Show Ongoing Goals
        else if (choice == "5")
        {
            // code here
        }

        // Show Completed Goals
        else if (choice == "6")
        {
            // code here
        }

        // Mark a Goal as "Done"
        else if (choice == "7")
        {
            // code here
        }

        // Mark a Goal as "Undone"
        else if (choice == "8")
        {
            // code here
        }

        // Edit a Goal
        else if (choice == "9")
        {
            // code here
        }

        // Delete a Goal
        else if (choice == "10")
        {
            // code here
        }


        // Quit
        else if (choice == "11")
        {
            Console.WriteLine("\nWarning: Exiting this program without saving will LOSE all UNSAVED CHANGES.");

            string exitUpper;
            do
            {
                Console.Write("Do you want to proceed? (Y/N): ");
                string exit = Console.ReadLine();
                exitUpper = exit.ToUpper();

                if (exitUpper == "N")
                {
                    Console.WriteLine("\nReturning to the main menu. . .");

                    // Exits the Quit block without ending the program
                    break;
                }
                else if (exitUpper != "Y")
                {
                    Console.WriteLine("\nInvalid input! Please enter Y or N.");
                }

            }
            while (exitUpper != "Y");

            if (exitUpper == "Y")
            {
                Console.WriteLine("\nExiting program. . .");
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine("Goodbye! (^.^)");

                // Safely exits the program
                Environment.Exit(0);
            }

            Console.WriteLine("==============================================================================================");
        }

        // Wrong Input
        else
        {
            Console.WriteLine("\nInvalid option! Please enter a number from 1 to 11.");

            Console.WriteLine("==============================================================================================");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Score: {_score}");
    }

    public void ListGoalNames()
    {
        // code here
    }

    public void ListGoalDetails()
    {
        // code here
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nWhich type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Checklist Goal");
        Console.WriteLine("3. Eternal Goal");

        Console.Write("\nType: ");
        string type = Console.ReadLine();

        Console.Write("\nGoal Name: ");
        string name = Console.ReadLine();

        Console.Write("\nGoal Description:");
        string description = Console.ReadLine();

        Console.Write("\nPoints: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        if (type == "1")
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (type == "2")
        {
            Console.Write("\nHow many times does this goal need to be done to get a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("\nBonus Points: ");
            int bonus = int.Parse(Console.ReadLine());

            goal = new ChecklistGoal(name, description, points, target, bonus);
        }
        else if (type == "3")
        {
            goal = new EternalGoal(name, description, points);
        }
        else
        {
            Console.WriteLine("\nInvalid option! Please enter a number from 1 to 3.");
            return;
        }
        
        _goals.Add(goal);
        Console.WriteLine("\nGoal created successfully!");
    }

    public void SaveGoals()
    {
        // code here
    }

    public void LoadGoals()
    {
        // code here
    }

    public void ShowAllGoals()
    {
        // code here
    }

    public void ShowAllOngoingGoals()
    {
        // code here
    }

    public void ShowAllCompletedGoals()
    {
        // code here
    }

    public void MarkAsDone()
    {
        // code here
    }

    public void MarkAsUndone()
    {
        // code here
    }

    public void DeleteAGoal()
    {
        // code here
    }
}