using System;

public class SimpleGoal : Goal
{
    // ------------------------------------------------------------------------------------------------------------------------
    // attributes (member variables)
    // ------------------------------------------------------------------------------------------------------------------------
    private bool _isComplete;

    // ------------------------------------------------------------------------------------------------------------------------
    // constructors
    // ------------------------------------------------------------------------------------------------------------------------
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // ------------------------------------------------------------------------------------------------------------------------
    // behaviors (methods)
    // ------------------------------------------------------------------------------------------------------------------------
    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Congratulations! You earned {GetPoints()} points!");
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public override bool IsComplete()
    {
        // code here
        return _isComplete;
    }

    // ------------------------------------------------------------------------------------------------------------------------

    public override string GetStringRepresentation()
    {
        string type = "Simple Goal";
        string stringRepresentation = $"{type}|{GetName()}|{GetDescription()}|{GetPoints()}|{_isComplete}"; 
        return stringRepresentation;
    }
}