public class RegularTask : Task
{
    private DateTime _dueDate;
    public RegularTask(string description) : base(description) { }
    public RegularTask(string description, DateTime dueDate) : base(description) 
    {
        _dueDate = dueDate;
    }

    public override string GetTaskDetails()
    {
        return $"[REGULAR] {base.Description}";
    }

    public override void Save(TaskList list)
    {

    }

    public override void Delete()
    {

    }
}