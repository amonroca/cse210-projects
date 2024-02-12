public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points){}

    public override void RecordEvent()
    {
        Console.WriteLine($"\nCongratulations! You have earned {base.Points}!");
    }

    public override bool IsComplete()
    {
        return false;
    } 

    public override string GetStringRepresentation()
    {
        return "";
    }

    public override void SaveGoal()
    {
        EternalGoalDAO eternalGoalDAO = new EternalGoalDAO();
        eternalGoalDAO.Save(this);
    }
}