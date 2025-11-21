using System;

public class Comment
{
    // attributes (member variables)
    private string _author;
    private string _text;

    // constructor
    public Comment(string author, string text)
    {
        _author = author;
        _text = text;
    }

    // behaviors (methods)
    public void ShowComment()
    {
        Console.WriteLine($"{_text}\n- {_author}\n");
    }
}