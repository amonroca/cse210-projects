public class Question
{
    private bool _isActive;
    private string _text;

    public bool IsActive
    {
        get => _isActive;
        set => _isActive = value;
    }

    public string Text
    {
        get => _text;
        set => _text = value;
    }

    public Question(bool isActive, string text)
    {
        _isActive = isActive;
        _text = text;
    }
}