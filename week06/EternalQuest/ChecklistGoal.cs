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
    // getters
    // ------------------------------------------------------------------------------------------------------------------------
    public int GetBonus()
    {
        return _bonus;
    }

    // ------------------------------------------------------------------------------------------------------------------------
    // setters
    // ------------------------------------------------------------------------------------------------------------------------
    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void SetTarget(int target)
    {
        _target = target;
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public void SetBonus(int bonus)
    {
        _bonus = bonus;
    }

    // ------------------------------------------------------------------------------------------------------------------------
    // behaviors (methods)
    // ------------------------------------------------------------------------------------------------------------------------
    public override void RecordEvent()
    {
        _amountCompleted++;
        Console.WriteLine($"Progress recorded! ({_amountCompleted}/{_target})");

        if (_amountCompleted == _target)
        {
            Console.WriteLine($"Congratulations! You've completed the checklist goal! {_bonus} points earned!");
        }
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public override bool IsComplete()
    {
        return _amountCompleted == _target;
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public override string GetDetailsString()
    {
        string checkmark = IsComplete() ? "[x]" : "[ ]";
        return $"{checkmark} {GetName()}: {GetDescription()} - {GetPoints()} points (Completed: {_amountCompleted}/{_target}) | Completion Bonus: {_bonus}";
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public override string GetStringRepresentation()
    {
        string type = "Checklist Goal"; 
        string stringRepresentation = $"{type}|{GetName()}|{GetDescription()}|{GetPoints()}|{_target}|{_bonus}|{_amountCompleted}";
        return stringRepresentation;
    }
}