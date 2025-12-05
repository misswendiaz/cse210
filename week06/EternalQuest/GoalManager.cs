using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

public class GoalManager
{
    // ------------------------------------------------------------------------------------------------------------------------
    // attributes (member variables)
    // ------------------------------------------------------------------------------------------------------------------------
    private List<Goal> _goals;
    private int _score;

    // ------------------------------------------------------------------------------------------------------------------------
    // contructor
    // ------------------------------------------------------------------------------------------------------------------------
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // ------------------------------------------------------------------------------------------------------------------------
    // behaviors (methods)
    // ------------------------------------------------------------------------------------------------------------------------
    public void Start()
    {
        Console.Clear();

        while (true)
        {
            Console.WriteLine("\n==============================================================================================");
            ShowScore();
            Console.WriteLine("==============================================================================================\n");
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
                SaveGoals();
            }

            // Load Goals
            else if (choice == "3")
            {
                LoadGoals();
            }

            // Show All Goals
            else if (choice == "4")
            {
                ShowAllGoals();
            }

            // Show Ongoing Goals
            else if (choice == "5")
            {
                ShowAllOngoingGoals();
            }

            // Show Completed Goals
            else if (choice == "6")
            {
                ShowAllCompletedGoals();
            }

            // Mark a Goal as "Done"
            else if (choice == "7")
            {
                if (_goals.Count == 0)
                {
                    Console.WriteLine("There are no goals yet.");
                    return;
                }

                ShowAllGoals();

                Console.Write("Type the goal NUMBER that you want to mark as DONE: ");
                int goalIndex = int.Parse(Console.ReadLine());

                while (goalIndex < 1 || goalIndex > _goals.Count)
                {
                    WrongInput(1, _goals.Count);
                    Console.Write("Goal Number: ");
                    goalIndex = int.Parse(Console.ReadLine());
                }
                MarkAsDone(goalIndex);
            }

            // Mark a Goal as "Not Yet Done"
            else if (choice == "8")
            {
                if (_goals.Count == 0)
                {
                    Console.WriteLine("There are no goals yet.");
                    return;
                }

                MarkAsNotYetDone();
            }

            // Edit a Goal
            else if (choice == "9")
            {
                if (_goals.Count == 0)
                {
                    Console.WriteLine("There are no goals yet.");
                    return;
                }

                EditAGoal();
            }

            // Delete a Goal
            else if (choice == "10")
            {
                if (_goals.Count == 0)
                {
                    Console.WriteLine("There are no goals yet.");
                    return;
                }

                DeleteAGoal();
            }


            // Quit
            else if (choice == "11")
            {
                Quit();
            }

            // Wrong Input
            else
            {
                WrongInput(1, 11);
            }
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void ShowScore()
    {
        Console.WriteLine($"Score: {_score}");
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void CreateGoal()
    {
        string type = "";

        Console.Clear();
        Console.WriteLine("\nWhich type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Checklist Goal");
        Console.WriteLine("3. Eternal Goal");

        Console.Write("\nType: ");
        type = Console.ReadLine();

        while (type != "1" && type != "2" && type != "3")
        {
            Console.WriteLine("\nInvalid option! Please enter a number from 1 to 3.");
            Console.Write("\nType: ");
            type = Console.ReadLine();
        }

        Console.Write("\nGoal Name: ");
        string name = Console.ReadLine();

        Console.Write("\nGoal Description: ");
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

            Console.Write("\nCompletion Bonus Points: ");
            int bonus = int.Parse(Console.ReadLine());

            goal = new ChecklistGoal(name, description, points, target, bonus);
        }
        else if (type == "3")
        {
            goal = new EternalGoal(name, description, points);
        }

        _goals.Add(goal);
        Console.WriteLine("\nGoal created successfully!");
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void SaveGoals()
    {
        Console.Write("\nFile Name: ");
        string fileName = Console.ReadLine();

        Console.WriteLine($"\nSaving goals as {fileName} . . .");
        Console.WriteLine(".");
        Console.WriteLine(".");
        Console.WriteLine(".");

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine($"\n{fileName} saved!");
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void LoadGoals()
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
                _score = int.Parse(lines[0]);

                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];

                    string[] parts = line.Split("|");
                    string type = parts[0];

                    if (type == "Simple Goal")
                    {
                        string name = parts[1];
                        string description = parts[2];
                        int points = int.Parse(parts[3]);
                        bool isComplete = bool.Parse(parts[4]);
                        _goals.Add(new SimpleGoal(name, description, points, isComplete));
                    }
                    else if (type == "Checklist Goal")
                    {
                        string name = parts[1];
                        string description = parts[2];
                        int points = int.Parse(parts[3]);
                        int target = int.Parse(parts[4]);
                        int bonus = int.Parse(parts[5]);
                        int amountCompleted = int.Parse(parts[6]);
                        _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
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

    // ------------------------------------------------------------------------------------------------------------------------

    public void ListGoalNames()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{goal.GetName()}");
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void ShowAllGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
        }

        else
        {
            Console.WriteLine("\n===== GOAL LIST =====");
            ListGoalDetails();
            Console.WriteLine("======================\n");
        }

    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void ShowAllOngoingGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            if (!_goals[i].IsComplete())
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void ShowAllCompletedGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            if (_goals[i].IsComplete())
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void MarkAsDone(int goalIndex)
    {
        Goal goal = _goals[goalIndex - 1];

        int basePoints = goal.GetPoints();
        int bonusPoints = 0;

        goal.RecordEvent();

        if (goal is ChecklistGoal checklistGoal)
        {
            if (checklistGoal.IsComplete())
            {
                bonusPoints = checklistGoal.GetBonus();
            }
        }

        _score += basePoints + bonusPoints;

        Console.WriteLine($"Score: {_score}");
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void MarkAsNotYetDone()
    {
        ShowAllGoals();
        Console.Write("\nWhich goal do you need to mark as NOT YET DONE? ");
        int goalNumber = int.Parse(Console.ReadLine());

        Goal selectedGoal = _goals[goalNumber - 1];

        if (selectedGoal is EternalGoal)
        {
            Console.WriteLine("Eternal goals cannot be marked complete or incomplete.");
            return;
        }

        else if (selectedGoal is SimpleGoal simpleGoal)
        {
            simpleGoal.SetIsCompleted(false);
            Console.WriteLine($"\n{selectedGoal.GetName()} marked as NOT DONE");
        }
        else if (selectedGoal is ChecklistGoal checklistGoal)
        {
            checklistGoal.SetAmountCompleted(0);
            Console.WriteLine($"\n{selectedGoal.GetName()} marked as NOT DONE");
        }

        // Adjust Score
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void EditAGoal()
    {
        ShowAllGoals();

        // Asks for the specific goal to edit using the goal number
        Console.WriteLine("Type the goal number that you would like to EDIT. ");

        int goalNumber = int.Parse(Console.ReadLine());

        while (goalNumber < 1 || goalNumber > _goals.Count)
        {
            WrongInput(1, _goals.Count);
            Console.Write("Goal Number: ");
            goalNumber = int.Parse(Console.ReadLine());
        }

        int index = goalNumber - 1;
        Goal selectedGoal = _goals[index];

        Console.WriteLine("\n Which Goal Attribute would you like to edit?");
        Console.WriteLine("1. Goal Name");
        Console.WriteLine("2. Goal Description");
        Console.WriteLine("3. Points Earned Per Completion");
        Console.WriteLine("4. Goal Completion Status");

        if (selectedGoal is ChecklistGoal)
        {
            Console.WriteLine("5. Goal Frequency Target");
            Console.WriteLine("6. Goal Completion Count");
            Console.WriteLine("7. Goal Completion Bonus");
        }

        Console.Write("Goal Attribute: ");
        int attribute = int.Parse(Console.ReadLine());

        if (attribute == 1)
        {
            Console.Write("\nGoal Name: ");
            string name = Console.ReadLine();
            _goals[index].SetName(name);
        }

        else if (attribute == 2)
        {
            Console.Write("\nGoal Description: ");
            string description = Console.ReadLine();
            _goals[index].SetDescription(description);
        }

        else if (attribute == 3)
        {
            Console.Write("\nPoints: ");
            int points = int.Parse(Console.ReadLine());
            _goals[index].SetPoints(points);
        }

        else if (attribute == 4)
        {
            if (selectedGoal is EternalGoal)
            {
                Console.WriteLine("Eternal goals cannot be marked complete.");
                return;
            }

            Console.WriteLine("\nMark this goal as");
            Console.WriteLine("1. Done");
            Console.WriteLine("2. Not Yet Done");
            Console.Write("\nMark: ");

            int mark = int.Parse(Console.ReadLine());

            if (mark == 1)
            {
                if (selectedGoal is SimpleGoal simpleGoal)
                {
                    simpleGoal.SetIsCompleted(true);
                }

                else if (selectedGoal is ChecklistGoal checklistGoal)
                {
                    Console.Write("Number of Completed Instances: ");
                    int amountCompleted = int.Parse(Console.ReadLine());
                    checklistGoal.SetAmountCompleted(amountCompleted);
                }

                // Adjust Score
            }
            else if (mark == 2)
            {
                if (selectedGoal is SimpleGoal simpleGoal)
                {
                    simpleGoal.SetIsCompleted(false);
                }

                else if (selectedGoal is ChecklistGoal checklistGoal)
                {
                    Console.Write("Number of Completed Instances: ");
                    int amountCompleted = int.Parse(Console.ReadLine());
                    checklistGoal.SetAmountCompleted(amountCompleted);
                }

                // Adjust Score
            }
            else
            {
                WrongInput(1, 2);
            }
        }

        else if (selectedGoal is ChecklistGoal checklistGoal && attribute >= 5 && attribute <= 7)
        {
            if (attribute == 5)
            {
                Console.Write("\nHow many times does this goal need to be done to get a bonus? ");
                int target = int.Parse(Console.ReadLine());
                checklistGoal.SetTarget(target);
            }

            else if (attribute == 6)
            {
                Console.Write("\nHow many instances of this goal have you completed? ");
                int amountCompleted = int.Parse(Console.ReadLine());
                checklistGoal.SetAmountCompleted(amountCompleted);

                // Adjust Score
            }

            else if (attribute == 7)
            {
                Console.Write("\nCompletion Bonus Points: ");
                int bonus = int.Parse(Console.ReadLine());
                checklistGoal.SetBonus(bonus);
            }
        }


        else
        {
            WrongInput(1, 7);
        }


        Console.WriteLine($"\nGoal {_goals[index].GetName()} edited successfully!");


    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void DeleteAGoal()
    {
        ShowAllGoals();

        Console.Write("\nWhich goal do you want to DELETE? ");
        int goalNumber = int.Parse(Console.ReadLine());

        while (goalNumber < 1 || goalNumber > _goals.Count)
        {
            WrongInput(1, _goals.Count);
            Console.Write("\nGoal Number: ");
            goalNumber = int.Parse(Console.ReadLine());
        }

        int index = goalNumber - 1;

        Console.Write($"Are you sure you want to delete \"{_goals[index].GetName()}\"? (Y/N): ");
        string delete = Console.ReadLine().ToUpper();

        if (delete == "Y")
        {
            _goals.RemoveAt(index);
            Console.WriteLine("\nGoal deleted successfully.");
        }
        else
        {
            Console.WriteLine("\nDeletion canceled.");
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void Quit()
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

    // ------------------------------------------------------------------------------------------------------------------------

    public void WrongInput(int start, int end)
    {
        Console.WriteLine($"\nInvalid option! Please enter a number from {start} to {end}.");

        Console.WriteLine("==============================================================================================");

        List<string> animationCharacters = new List<string>();
        animationCharacters.Add("(-.-)");
        animationCharacters.Add("(^.^)");
        animationCharacters.Add("(^-^)");
        animationCharacters.Add("(*-*)");
        animationCharacters.Add("(*o*)");
        animationCharacters.Add("(-.-)");
        animationCharacters.Add("(^.^)");
        animationCharacters.Add("(^-^)");
        animationCharacters.Add("(*-*)");
        animationCharacters.Add("(*o*)");

        foreach (string character in animationCharacters)
        {
            Console.Write($"\r{character}");
            Thread.Sleep(300);
            // Console.Write("\b \b\b \b\b \b\b \b\b \b");
        }
        Console.Write("\r     \r");
    }
}