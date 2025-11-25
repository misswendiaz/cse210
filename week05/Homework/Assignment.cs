using System;

public class Assignment
{
    // attributes (member variables)
    private string _studentName;
    private string _topic;

    // constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // getters
    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetTopic()
    {
        return _topic;
    }

    // setters
    public void SetStudentName(string studentName)
    {
        _studentName = studentName;
    }

    public void SetTopic(string topic)
    {
        _topic = topic;
    }
    
    // behaviors (methods)
    public void GetSummary()
    {
        Console.WriteLine($"{_studentName} - {_topic}");
    }
}