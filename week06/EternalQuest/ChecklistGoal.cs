using System;

public class ChecklistGoal : Goal
{
    // attributes (member variables)
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // constructor
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // behaviors (methods)
    public override void RecordEvent()
    {
        // code here
    }

    public override bool IsComplete()
    {
        // code here
        return false; //edit code
    }

    public override string GetDetailString()
    {
        // code here
        return "code";
    }

    public override string GetStringRepresentation()
    {
        string type = "Checklist Goal"; 
        string stringRepresentation = $"{type} | {_name} | {_description} | {_points} | {_target} | {_bonus} | {_amountCompleted}";
        return stringRepresentation;
    }
}