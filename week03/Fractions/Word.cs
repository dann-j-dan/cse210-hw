public class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public bool IsHidden() => _hidden;

    public void Hide() => _hidden = true;

    public string GetDisplayText()
    {
        return _hidden ? new string('_', _text.Length) : _text;
    }
}