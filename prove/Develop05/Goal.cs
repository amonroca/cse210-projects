using LiteDB;

public abstract class Goal
{
    private string _shortName, _description;
    private int _points;
    private ObjectId _id;
    private DateTime _createDate;

    public string ShortName
    {
        get => _shortName;
        set => _shortName = value;
    }

    public string Description
    {
        get => _description;
        set => _description = value;
    }

    public int Points
    {
        get => _points;
        set => _points = value;
    }

    public ObjectId Id
    {
        get => _id;
        set => _id = value;
    }

    public DateTime CreateDate
    {
        get => _createDate;
        set => _createDate = value;
    }

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
        string goalString = $"{_shortName} ({_description})";
        string checkboxString = "[ ] ";

        if (IsComplete())
        {
            checkboxString = "[X] ";
        }

        return checkboxString + goalString;
    }
    public abstract string GetStringRepresentation();
    public abstract void SaveGoal();
}