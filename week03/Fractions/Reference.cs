public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int VerseStart { get; }
    public int? VerseEnd { get; }

    // Single verse
    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verse;
        VerseEnd = null;
    }

    // Verse range
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    public override string ToString()
    {
        if (VerseEnd.HasValue)
            return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
        else
            return $"{Book} {Chapter}:{VerseStart}";
    }
}