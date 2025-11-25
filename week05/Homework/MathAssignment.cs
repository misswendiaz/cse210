using System;

public class MathAssignment : Assignment
{
    // attributes (member variables)
    private string _textbookSection;
    private string _problems;

    // constructors
    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // behaviors (methods)
    public void GetHomeworkList()
    {
        Console.WriteLine($"{_textbookSection} {_problems}");
    }
}