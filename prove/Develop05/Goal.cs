public abstract class Goal
{
    private string _shortName, _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description})";
    }
    public abstract string GetStringRepresentation();
}