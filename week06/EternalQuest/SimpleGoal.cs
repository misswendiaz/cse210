using System;

public class SimpleGoal : Goal
{
    // attributes (member variables)
    private bool _isComplete;

    // constructor
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    // behaviors (methods)
    public override void RecordEvent()
    {
        // code here
    }

    public override bool IsComplete()
    {
        // code here
        return _isComplete; // edit code
    }

    public override string GetStringRepresentation()
    {
        // code here
        return "code";
    }
}