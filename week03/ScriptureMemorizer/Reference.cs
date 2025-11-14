using System;

public class Reference
// Keeps track of the book, chapter, and verse information
{
    // attributes (member variables)
    private string _book;
    private int _chapter;
    private int _verse;
    private int? _endVerse;
    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types

    // constructors
    public Reference(string book, int chapter, int verse)
    // For Scripture Passages with Single Verse
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = null;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    // For Scripture Passages with Multiple Verses
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // getters
    public string Book => _book;
    public int Chapter => _chapter;
    public int StartVerse => _verse;
    public int? EndVerse => _endVerse;


    // behaviors (methods)
    public string GetReference()
    // Combines the book, chapter, and verse(or verses)
    {
        if (_endVerse.HasValue)
        // https://learn.microsoft.com/en-us/dotnet/api/system.nullable-1.hasvalue?view=net-9.0
        {
            string reference = $"{_book} {_chapter}:{_verse}-{_endVerse}";
            return reference;
        }
        else
        {
            string reference = $"{_book} {_chapter}:{_verse}";
            return reference;
        }
        
        
    }
}