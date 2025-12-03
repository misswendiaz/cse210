using System;
using System.ComponentModel;

public abstract class Goal
{
    // attributes (member variables)
    private string _shortName;
    private string _description;
    private int _points;

    // constructor
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // behaviors (methods)
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailString()
    {
        // code here
        return "string";
    }
    public abstract string GetStringRepresentation();
}