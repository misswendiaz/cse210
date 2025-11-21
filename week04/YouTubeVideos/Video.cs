using System;
using System.Collections.Generic;

public class Video
{
    // attributes (member variables)
    private string _title;
    private string _producer;
    private int _length;
    private List<Comment> _comments;

    // constructor
    public Video(string title, string producer, int length)
    {
        _title = title;
        _producer = producer;
        _length = length;
        _comments = new List<Comment>();
    }

    // behaviors (methods)
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int CountComments()
    {
        int commentCount = _comments.Count;
        return commentCount;
    }

    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Producer: {_producer}");
        Console.WriteLine($"Length: {_length}");
        int commentCount = CountComments();
        Console.Write($"Number of Comments: {commentCount}\n");
        Console.WriteLine("\nComments:\n");

        foreach (Comment comment in _comments)
        {
            comment.ShowComment();
        }
    }
}