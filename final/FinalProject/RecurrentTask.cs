public class RecurrentTask : Task
{
    public RecurrentTask(string description) : base(description) { }

    public override string GetTaskDetails()
    {
        return $"[RECURRENT] {base.Description}";
    }

    public override void Save(TaskList list)
    {

    }

    public override void Delete()
    {

    }
}