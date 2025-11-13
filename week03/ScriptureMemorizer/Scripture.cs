using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;

public class Scripture
// Keeps track of both the reference and the text of the scripture passage
// Can hide words and get the rendered display of text
{
    // attributes (member variables)
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    // constructor
    public Scripture(Reference reference, string text)
    // Splits up the text into words
    // Creates the list with the words
    {
        _reference = reference;
                
        // Converts text into List<Word>
        MatchCollection matches = Regex.Matches(text, @"[\w\w']+|[-.,;:!?]");

        _words = new List<Word>();
        foreach (Match match in matches)
        {
            _words.Add(new Word(match.Value));
        }

        _random = new Random();
    }
    
    // behaviors (methods)
    public void HideWords(int hideQuantity)
    // Hides random words
    {
        // // Get all the words that can be hidden
        // List<Word> hideableWords = _words.FindAll(word => !word.IsHidden() && word.ContainsLetter());

        // // Adjust hideQuantity hidealableWords.Count is less than hideQuantity
        // hideQuantity = Math.Min(hideQuantity, hideableWords.Count);

        // // Hide words
        // for (int i = 0; i < hideQuantity; i++)
        // {
        //     int index = _random.Next(hideableWords.Count);
        //     hideableWords[index].Hide();

        //     // Removes the indices of the hidden words
        //     hideableWords.RemoveAt(index);
        // }
        
        
        
        // Get the indices of visible words
        List<int> visibleIndices = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndices.Add(i);
            }
        }

        // Hides everything if the visible words are less than the number of words to hide
        if (hideQuantity > visibleIndices.Count)
        {
            hideQuantity = visibleIndices.Count;
        }

        // Hides the specified number of words randomly
        for (int i = 0; i < hideQuantity; i++)
        {
            int randomIndex = _random.Next(visibleIndices.Count);
            int wordToHide = visibleIndices[randomIndex];

            _words[wordToHide].Hide();

            // Removes the index of hidden words
            visibleIndices.RemoveAt(randomIndex);
        }
    }

    public string GetDisplayText()
    // Gets the text to be displayed (may include hidden words replaced by underscores)
    {
        string reference = _reference.GetReference();
        string text = "";

        foreach (Word word in _words)
        {
            text += word.GetWord() + " ";
        }

        return reference + "\n" + text;
    }

    public bool IsCompletelyHidden()
    // Checks if the scripture passage is completely hidden
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}