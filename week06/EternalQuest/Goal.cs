using System;

public abstract class Goal
{
    // attributes (member variables)
    protected string _name;
    protected string _description;
    protected int _points;

    // constructor
    public Goal(string name, string description, int points)
    {
        _name = name;
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