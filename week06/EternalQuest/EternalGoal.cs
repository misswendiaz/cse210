using System;

public class EternalGoal : Goal
{
    // attributes (member variables)

    // constructor
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
       // code here
    }

    // behaviors (methods)
    public override void RecordEvent()
    {
        // code here
    }

    public override bool IsComplete()
    {
        // code here
        return false; // edit code
    }

    public override string GetStringRepresentation()
    {
        // code here
        return "code";
    }
}