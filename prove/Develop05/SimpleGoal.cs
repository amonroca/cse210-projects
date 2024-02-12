public class SimpleGoal : Goal
{
    private bool _isComplete;

    public bool IsCompleted
    {
        get => _isComplete;
        set => _isComplete = value;
    }

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"\nCongratulations! You have earned {base.Points}!");
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return "";
    }

    public override void SaveGoal()
    {
        SimpleGoalDAO simpleGoalDAO = new SimpleGoalDAO();
        simpleGoalDAO.Save(this);
    }
}