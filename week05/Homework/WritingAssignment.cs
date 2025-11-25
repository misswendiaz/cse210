using System;

public class WritingAssignment : Assignment
{
    // attributes (member variables)
    private string _title;

    // constructors
    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }

    // behaviors (methods)
    public string GetWritingInformation()
    {
        return $"{_title} by {GetStudentName()}";
    }
}