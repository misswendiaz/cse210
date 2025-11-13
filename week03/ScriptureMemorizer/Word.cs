using System;

public class Word
// Keeps track of a single word and whether it is shown or hidden
{
    // attributes (member variables)
    private string _text;
    private bool _isHidden;


    // constructors
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }


    // behaviors (methods)
    public void Hide()
    // Hides the word
    {
        _isHidden = true;
    }

    public void Show()
    // Shows the word
    {
        _isHidden = false;
    }

    public bool IsHidden()
    // Checks if the word is hidden or not
    {
        return _isHidden;
    }

    public bool ContainsLetter()
    {
        foreach (char c in _text)
        {
            if (char.IsLetter(c))
                return true;
        }

        return false;
    }

    public string GetWord()
    {
        if (_isHidden)
        {
            // Replaace each letter with underscore
            string underscore = "";
            foreach (char c in _text)
            {
                if (char.IsLetter(c))
                // https://learn.microsoft.com/en-us/dotnet/api/system.char.isletter?view=net-9.0
                {
                    underscore += "_";
                }
                else
                {
                    underscore += c;
                }
            }

            return underscore.Trim();
        }
        else
        {
            return _text;
        }
    }
}