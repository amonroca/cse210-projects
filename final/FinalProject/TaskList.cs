using LiteDB;

public class TaskList
{
    private string _name;
    private List<Task> _toDoList = new List<Task>();
    private ObjectId _id;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public List<Task> ToDoList
    {
        get => _toDoList;
        set => _toDoList = value;
    }

    public ObjectId Id
    {
        get => _id;
        set => _id = value;
    }

    public TaskList(string name)
    {
        _name = name;
        _id = ObjectId.NewObjectId();
    }

    public Task GetTask(int index)
    {
        return _toDoList[index];
    }

    public void SetTask(Task task)
    {
        _toDoList.Add(task);
    }

/*     public void RemoveTask(Task task)
    {
        _toDoList.Remove(task);
    } */

    public void DisplayTaskList()
    {
        if (_toDoList.Count > 0)
        {
            foreach (Task task in _toDoList)
            {
                Console.WriteLine($"{_toDoList.IndexOf(task) + 1}. {task.GetTaskDetails()}");
            }
        }
        else
        {
            Console.WriteLine($"There is no task in the list to display");
        }
    }

    public void Save()
    {
        TaskListDAO taskListDAO = new TaskListDAO();
        taskListDAO.Save(this);
    }

    public void Delete()
    {
        TaskListDAO taskListDAO = new TaskListDAO();
        taskListDAO.Delete(this);
    }
}