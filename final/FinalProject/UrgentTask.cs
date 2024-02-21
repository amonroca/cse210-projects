public class UrgentTask : Task
{
    private int _priorityOrder;

    public int PriorityOrder
    {
        get => _priorityOrder;
        set => _priorityOrder = value;
    }
    public UrgentTask(string description, int priorityOrder) : base(description) 
    {
        _priorityOrder = priorityOrder;
    }

    public override string GetTaskDetails()
    {
        return $"[URGENT] [PRIORITY #{_priorityOrder}] {base.Description}";
    }

    public override void Save(TaskList list)
    {
        UrgentTaskDAO urgentTaskDAO = new UrgentTaskDAO();
        urgentTaskDAO.Save(this, list);
    }

    public override void Delete(TaskList list, int taskIndex)
    {
        UrgentTaskDAO urgentTaskDAO = new UrgentTaskDAO();
        urgentTaskDAO.Delete(this, list, taskIndex);
    }

    public override void Update(TaskList list, int taskIndex)
    {
        UrgentTaskDAO urgentTaskDAO = new UrgentTaskDAO();
        urgentTaskDAO.Update(this, list, taskIndex);
    }
}