using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
            Console.WriteLine("\n========================================================================================================");
            ShowScore();
            Console.WriteLine("========================================================================================================\n");
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
                MarkAsDone();
            }

            // Mark a Goal as "Not Yet Done"
            else if (choice == "8")
            {
                MarkAsNotYetDone();
            }

            // Edit a Goal
            else if (choice == "9")
            {
                EditAGoal();
            }

            // Delete a Goal
            else if (choice == "10")
            {
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

        int points;
        while (true)
        {
            Console.Write("\nPoints: ");
            string pointsString = Console.ReadLine();

            if (int.TryParse(pointsString, out points) && points > 0)
            // https://learn.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=net-10.0
            {
                break;
            }
            Console.WriteLine("Invalid input! Please enter a valid non-negative integer.");
        }

        

        Goal goal = null;

        if (type == "1")
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (type == "2")
        {
            int target;
            while (true)
            {
                Console.Write("\nRequired Number of Occurrence: ");
                string targetString = Console.ReadLine();
                if (int.TryParse(targetString, out target) && target > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid input! Please enter a valid positive integer.");
            }

            int bonus;
            while (true)
            {
                Console.Write("\nCompletion Bonus Points: ");
                string bonusString = Console.ReadLine();
                if (int.TryParse(bonusString, out bonus) && bonus > 0)
                {
                    break;
                }
                Console.WriteLine("Invalid input! Please enter a valid positive integer.");
            }

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
            Console.WriteLine("\n============================================= GOAL LIST ================================================");
            ListGoalDetails();
            Console.WriteLine("========================================================================================================\n");
        }

    }

    // ------------------------------------------------------------------------------------------------------------------------
    public List<Goal> GetOngoingGoals()
    {
        List<Goal> ongoingGoals = new List<Goal>();
        foreach (Goal goal in _goals)
        {
            if (!goal.IsComplete())
            {
                ongoingGoals.Add(goal);
            }
        }
        return ongoingGoals;
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void ShowAllOngoingGoals()
    {
        List<Goal> ongoingGoals = GetOngoingGoals();
        
        if (ongoingGoals.Count == 0)
        {
            Console.WriteLine("No ongoing goals yet.");
        }
        else
        {
            Console.WriteLine("\n========================================= ONGOING GOAL LIST ============================================");
            for (int i = 0; i < ongoingGoals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ongoingGoals[i].GetDetailsString()}");
            }
            Console.WriteLine("========================================================================================================\n");
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------
    public List<Goal> GetCompletedGoals()
    {
        List<Goal> completedGoals = new List<Goal>();
        foreach (Goal goal in _goals)
        {
            if (goal.IsComplete())
            {
                completedGoals.Add(goal);
            }
        }
        return completedGoals;
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void ShowAllCompletedGoals()
    {
        List<Goal> completedGoals = GetCompletedGoals();

        if (completedGoals.Count == 0)
        {
            Console.WriteLine("No completed goals yet.");
        }
        else
        {
            Console.WriteLine("\n======================================== COMPLETED GOAL LIST ============================================");
            for (int i = 0; i < completedGoals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {completedGoals[i].GetDetailsString()}");
            }
            Console.WriteLine("========================================================================================================\n");
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void MarkAsDone()
    {
        ShowAllOngoingGoals();
        List<Goal> ongoingGoals = GetOngoingGoals();

        if (ongoingGoals.Count == 0)
        {
            return;
        }

        else
        {
            int goalNumber;
            while (true)
            {
                Console.Write("Type the goal NUMBER that you want to mark as DONE: ");
                string goalNumberString = Console.ReadLine();
                if (int.TryParse(goalNumberString, out goalNumber) && goalNumber > 0)
                {
                    while (goalNumber < 1 || goalNumber > ongoingGoals.Count)
                    {
                        WrongInput(1, ongoingGoals.Count);
                        Console.Write("Goal Number: ");
                        goalNumber = int.Parse(Console.ReadLine());
                    }

                    int index = goalNumber - 1;

                    Goal goal =ongoingGoals[index];

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

                    ShowAllGoals();
                    break;
                }
                
                WrongInput(1, ongoingGoals.Count);
            }

            
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void MarkAsNotYetDone()
    {
        ShowAllCompletedGoals();
        List<Goal> completedGoals = GetCompletedGoals();

        if (completedGoals.Count == 0)
        {
            return;
        }

        else
        {
            int goalNumber;
            while (true)
            {
                Console.Write("\nWhich goal do you need to mark as NOT YET DONE? ");
                string goalNumberString = Console.ReadLine();
                if (int.TryParse(goalNumberString, out goalNumber) && goalNumber > 0)
                {
                    while (goalNumber < 1 || goalNumber > completedGoals.Count)
                    {
                        WrongInput(1, completedGoals.Count);
                        Console.Write("Goal Number: ");
                        goalNumber = int.Parse(Console.ReadLine());
                    }

                    int index = goalNumber - 1;

                    Goal selectedGoal = completedGoals[index];

                    if (selectedGoal is EternalGoal)
                    {
                        Console.WriteLine("Eternal goals cannot be marked complete or incomplete.");
                        return;
                    }

                    else if (selectedGoal is SimpleGoal simpleGoal)
                    {
                        simpleGoal.SetIsCompleted(false);
                        Console.WriteLine($"\n{selectedGoal.GetName()} marked as NOT DONE");

                        // Adjust score
                        _score = _score - simpleGoal.GetPoints();
                    }
                    else if (selectedGoal is ChecklistGoal checklistGoal)
                    {
                        int currentAmountCompleted = checklistGoal.GetAmountCompleted();

                        Console.Write("Number of Completed Instances: ");
                        int amountCompleted = int.Parse(Console.ReadLine());

                        // Adjust score
                        int amountDifference = currentAmountCompleted - amountCompleted;

                        if (checklistGoal.IsComplete())
                        {
                            int pointDeduction = amountDifference * checklistGoal.GetPoints();
                            int bonusDeduction = checklistGoal.GetBonus();
                            _score = _score - (pointDeduction + bonusDeduction);
                        }
                        else
                        {
                            int pointDeduction = amountDifference * checklistGoal.GetPoints();
                            _score = _score - pointDeduction;
                        }

                        checklistGoal.SetAmountCompleted(amountCompleted);
                        Console.WriteLine($"\n{selectedGoal.GetName()} marked as NOT DONE");
                    }

                    ShowAllGoals();
                    break;
                }

                WrongInput(1, completedGoals.Count);
            }
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void EditAGoal()
    {
        ShowAllGoals();

        if (_goals.Count == 0)
        {
            return;
        }

        else
        {
            // Asks for the specific goal to edit using the goal number
            Console.Write("Type the goal number that you would like to EDIT. ");

            int goalNumber = int.Parse(Console.ReadLine());

            while (goalNumber < 1 || goalNumber > _goals.Count)
            {
                WrongInput(1, _goals.Count);
                Console.Write("Goal Number: ");
                goalNumber = int.Parse(Console.ReadLine());
            }

            int index = goalNumber - 1;
            Goal selectedGoal = _goals[index];

            {
                Console.WriteLine("\n Which Goal Attribute would you like to edit?");
                Console.WriteLine("1. Goal Name");
                Console.WriteLine("2. Goal Description");
                Console.WriteLine("3. Points Earned Per Completion");

                int maxAttributeCount = 3;

                if (selectedGoal is ChecklistGoal)
                {
                    Console.WriteLine("4. Goal Required Number of Occurrence");
                    Console.WriteLine("5. Goal Completion Count");
                    Console.WriteLine("6. Goal Completion Bonus");
                    maxAttributeCount = 6;
                }

                int attribute;
                while (true)
                {
                    Console.Write("\n Goal Attribute: ");
                    string attributeString = Console.ReadLine();
                    if (int.TryParse(attributeString, out attribute) && attribute > 0 && attribute <= maxAttributeCount)
                    {
                        if (attribute == 1)
                        {
                            Console.Write("\nNew Goal Name: ");
                            string name = Console.ReadLine();
                            _goals[index].SetName(name);
                        }

                        else if (attribute == 2)
                        {
                            Console.Write("\nNew Goal Description: ");
                            string description = Console.ReadLine();
                            _goals[index].SetDescription(description);
                        }

                        else if (attribute == 3)
                        {
                            int points;
                            while (true)
                            {
                                Console.Write("\nNew Point Reward: ");
                                string pointsString = Console.ReadLine();
                                if (int.TryParse(pointsString, out points) && points > 0)
                                {
                                    _goals[index].SetPoints(points);
                                    break;
                                }
                                Console.WriteLine("Invalid input! Please enter a positive integer.");
                            }
                            
                        }

                        else if (selectedGoal is ChecklistGoal checklistGoal && attribute >= 4 && attribute <= 6)
                        {
                            if (attribute == 4)
                            {
                                int target;
                                while (true)
                                {
                                    Console.Write("\nNew Required Number of Occurrence: ");
                                    string targetString = Console.ReadLine();
                                    if (int.TryParse(targetString, out target) && target > 0)
                                    {
                                        checklistGoal.SetTarget(target);

                                        if (checklistGoal.IsComplete())
                                        {
                                            _score = _score + checklistGoal.GetBonus();
                                        }
                                        break;
                                    }
                                    Console.WriteLine("Invalid input! Please enter a positive integer.");

                                }
                                
                            }

                            else if (attribute == 5)
                            {
                                int updatedCompletedCount;
                                while (true)
                                {
                                    Console.Write("\nNew Completion Count: ");
                                    string updatedCompletedCountString = Console.ReadLine();
                                    if (int.TryParse(updatedCompletedCountString, out updatedCompletedCount) && updatedCompletedCount >= 0)
                                    {
                                        // Adjust Score
                                        int currentCompletedCount = checklistGoal.GetAmountCompleted();
                                        int countDifference = Math.Abs(currentCompletedCount - updatedCompletedCount);
                                        int pointsDifference = countDifference * checklistGoal.GetPoints();
                                        int bonus = checklistGoal.GetBonus();

                                        if (currentCompletedCount < updatedCompletedCount)
                                        {
                                            checklistGoal.SetAmountCompleted(updatedCompletedCount);
                                            if (checklistGoal.IsComplete())
                                            {
                                                _score = _score + pointsDifference + bonus;
                                            }
                                            else
                                            {
                                                _score = _score + pointsDifference;
                                            }
                                        }
                                        else
                                        {
                                            if (checklistGoal.IsComplete())
                                            {
                                                _score = _score - (pointsDifference + bonus);
                                            }
                                            else
                                            {
                                                _score = _score - pointsDifference;
                                            }
                                            checklistGoal.SetAmountCompleted(updatedCompletedCount);
                                        }
                                        break;
                                    }
                                    Console.WriteLine("Invalid input! Please enter a non-negative integer.");
                                }
                            }

                            else if (attribute == 6)
                            {
                                int bonus;
                                while (true)
                                {
                                    Console.Write("\nNew Completion Bonus Points: ");
                                    string bonusString = Console.ReadLine();
                                    if (int.TryParse(bonusString, out bonus) && bonus > 0)
                                    {
                                        checklistGoal.SetBonus(bonus);
                                        break;
                                    }
                                    Console.WriteLine("Invalid input! Please enter a positive integer.");
                                }
                            }
                        }
                        Console.WriteLine($"\nGoal {_goals[index].GetName()} edited successfully!");

                        ShowAllGoals();
                        break;
                    }
                    WrongInput(1, maxAttributeCount);
                }
            }
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void DeleteAGoal()
    {
        ShowAllGoals();

        if (_goals.Count == 0)
        {
            return;
        }

        else
        {
            int goalNumber;
            while (true)
            {
                Console.Write("\nGoal Number: ");
                string goalNumberString = Console.ReadLine();
                if (int.TryParse(goalNumberString, out goalNumber) && goalNumber > 0 && goalNumber <= _goals.Count)
                {
                    int index = goalNumber - 1;

                    Console.Write($"\nAre you sure you want to delete \"{_goals[index].GetName()}\"? (Y/N): ");
                    string delete = Console.ReadLine().ToUpper();

                    while (delete != "Y")
                    {
                        if (delete == "N")
                        {
                            Console.WriteLine("\nDeletion canceled."); 
                            break;
                        }
                        else
                        {
                            Console.Write("\nInvalid input! Please enter Y or N. ");
                            delete = Console.ReadLine().ToUpper();
                        }
                    }

                    if (delete == "Y")
                    {
                        _goals.RemoveAt(index);
                        Console.WriteLine("\nGoal deleted successfully.");
                    }

                    ShowAllGoals();
                    break;
                }
                WrongInput(1, _goals.Count);
            }
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void Quit()
    {
        Console.WriteLine("\nWarning: Exiting this program without saving will LOSE all UNSAVED CHANGES.");

        string exitUpper;
        do
        {
            Console.Write("\nDo you want to proceed? (Y/N): ");
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

        Console.WriteLine("========================================================================================================");
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void WrongInput(int start, int end)
    {
        Console.WriteLine($"\nInvalid option! Please enter a number from {start} to {end}.");

        Console.WriteLine("========================================================================================================");

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