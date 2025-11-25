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
    public string GetSummary()
    {
        return "{_studentName} - {_topic}";
    }
}