public class RegularTask : Task
{
    private DateTime _dueDate;

    public DateTime DueDate
    {
        get => _dueDate;
        set => _dueDate = value;
    }
    public RegularTask(string description) : base(description) { }
    public RegularTask(string description, DateTime dueDate) : base(description) 
    {
        _dueDate = dueDate;
    }

    public override string GetTaskDetails()
    {
        return $"[REGULAR] {base.Description} {(_dueDate != DateTime.MinValue ? "- Due date:" : "")} {(_dueDate != DateTime.MinValue ? _dueDate.ToString("MM/dd/yyyy") : "")}";
    }

    public override void Save(TaskList list)
    {
        RegularTaskDAO regularTaskDAO = new RegularTaskDAO();
        regularTaskDAO.Save(this, list);
    }

    public override void Delete(TaskList list, int taskIndex)
    {
        RegularTaskDAO regularTaskDAO = new RegularTaskDAO();
        regularTaskDAO.Delete(this, list, taskIndex);
    }

    public override void Update(TaskList list, int taskIndex)
    {
        RegularTaskDAO regularTaskDAO = new RegularTaskDAO();
        regularTaskDAO.Update(this, list, taskIndex);
    }
}