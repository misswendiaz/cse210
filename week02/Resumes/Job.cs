using System;

public class Job
{
    // attributes (member variablles)
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    // constructor
    public Job()
    {

    }

    // behaviors (methods)
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}