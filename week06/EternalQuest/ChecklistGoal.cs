using System;

public class ChecklistGoal : Goal
{
    // ------------------------------------------------------------------------------------------------------------------------
    // attributes (member variables)
    // ------------------------------------------------------------------------------------------------------------------------
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // ------------------------------------------------------------------------------------------------------------------------
    // constructors
    // ------------------------------------------------------------------------------------------------------------------------
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // ------------------------------------------------------------------------------------------------------------------------
    // behaviors (methods)
    // ------------------------------------------------------------------------------------------------------------------------
    public override void RecordEvent()
    {
        // code here
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public override bool IsComplete()
    {
        // code here
        return false; //edit code
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public override string GetDetailsString()
    {
        return $"[ ] {GetName()}: {GetDescription()} - {GetPoints()} points (Completed: {_amountCompleted}/{_target}) | Completion Bonus: {_bonus}";
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public override string GetStringRepresentation()
    {
        string type = "Checklist Goal"; 
        string stringRepresentation = $"{type} | {GetName()} | {GetDescription()} | {GetPoints()} | {_target} | {_bonus} | {_amountCompleted}";
        return stringRepresentation;
    }
}