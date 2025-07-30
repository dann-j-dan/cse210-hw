using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplayText())));
    }

    public void HideRandomWords()
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        if (visibleWords.Count == 0) return;

        Random rnd = new Random();
        int wordsToHide = Math.Min(3, visibleWords.Count); // Hide up to 3 words at a time
        for (int i = 0; i < wordsToHide; i++)
        {
            var word = visibleWords[rnd.Next(visibleWords.Count)];
            word.Hide();
            visibleWords.Remove(word);
            if (visibleWords.Count == 0) break;
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}