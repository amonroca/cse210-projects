public class Prompt
{
    private string _relatedActivity, _text;
    private bool _isActive;

    public string RelatedActivity
    {
        get => _relatedActivity;
        set => _relatedActivity = value;
    }

    public string Text
    {
        get => _text;
        set => _text = value;
    }

    public bool IsActive
    {
        get => _isActive;
        set => _isActive = value;
    }

    public Prompt(string relatedActivity, bool isActive, string text)
    {
        _relatedActivity = relatedActivity;
        _isActive = isActive;
        _text = text;
    }
}