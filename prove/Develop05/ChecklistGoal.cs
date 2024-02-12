public class ChecklistGoal : Goal
{
    private int _amountCompleted, _target, _bonus;

    public int AmountCompleted
    {
        get => _amountCompleted;
        set => _amountCompleted = value;
    }

    public int Target
    {
        get => _target;
        set => _target = value;
    }

    public int Bonus
    {
        get => _bonus;
        set => _bonus = value;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;

        if (IsComplete())
        {
            base.Points += _bonus;
        }

        Console.WriteLine($"\nCongratulations! You have earned {base.Points}!");

    }

    public override bool IsComplete()
    {
        if (_amountCompleted >= _target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetDetailsString()
    {
        string goalString = $"{base.ShortName} ({base.Description}) -- Currently completed: {_amountCompleted}/{_target}";
        string checkboxString = "[ ] ";

        if (IsComplete())
        {
            checkboxString = "[X] ";
        }
        
        return checkboxString + goalString;
    }

    public override string GetStringRepresentation()
    {
        return "";
    }

    public override void SaveGoal()
    {
        ChecklistGoalDAO checklistGoalDAO = new ChecklistGoalDAO();
        checklistGoalDAO.Save(this);
    }
}