public class RecurrentTask : Task
{
    public RecurrentTask(string description) : base(description) { }

    public override string GetTaskDetails()
    {
        return $"[RECURRENT] {base.Description}";
    }

    public override void Save(TaskList list)
    {
        RecurrentTaskDAO recurrentTaskDAO = new RecurrentTaskDAO();
        recurrentTaskDAO.Save(this, list);
    }

    public override void Delete(TaskList list, int taskIndex)
    {
        RecurrentTaskDAO recurrentTaskDAO = new RecurrentTaskDAO();
        recurrentTaskDAO.Delete(this, list, taskIndex);
    }

    public override void Update(TaskList list, int taskIndex)
    {
        RecurrentTaskDAO recurrentTaskDAO = new RecurrentTaskDAO();
        recurrentTaskDAO.Update(this, list, taskIndex);
    }
}