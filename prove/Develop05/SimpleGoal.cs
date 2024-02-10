public class SimpleGoal : Goal
{
    private bool _isComplete;

    public bool IsCompleted
    {
        get => _isComplete;
        set => _isComplete = value;
    }

    public SimpleGoal(string name, string description, int points) : base(name, description, points){}

    public override void RecordEvent()
    {}

    public override bool IsComplete()
    {
        return true;
    }

    public override string GetStringRepresentation()
    {
        return "";
    }
}