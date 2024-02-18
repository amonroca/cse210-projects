public class UrgentTask : Task
{
    private int _priorityOrder;
    public UrgentTask(string description, int priorityOrder) : base(description) 
    {
        _priorityOrder = priorityOrder;
    }

    public override string GetTaskDetails()
    {
        return $"[URGENT] [PRIORITY #{_priorityOrder}]{base.Description}";
    }

    public override void Save(TaskList list)
    {

    }

    public override void Delete()
    {

    }
}