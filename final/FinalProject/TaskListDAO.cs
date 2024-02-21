using LiteDB;

public class TaskListDAO
{
    public void Save(TaskList list)
    {
        using(var db = new LiteDatabase("ToDoList.db"))
        {
            var col = db.GetCollection<TaskList>("task_list");

            col.Insert(list);
        }
    }

    public void Delete(TaskList list)
    {
        using(var db = new LiteDatabase("ToDoList.db"))
        {
            var col = db.GetCollection<TaskList>("task_list");

            var remove = new BsonValue(list.Id);

            col.Delete(remove);
        }
    }

    public List<TaskList> LoadAllLists()
    {   
        List<TaskList> taskLists = new List<TaskList>();
        using(var db = new LiteDatabase("ToDoList.db"))
        {
            var col = db.GetCollection<TaskList>("task_list");
            var results = col.Query().Select(x => new { x.Id, x.Name, x.ToDoList }).ToList();

            foreach (var r in results)
            {
                TaskList list = new TaskList(r.Name);
                list.Id = r.Id;
                list.ToDoList = r.ToDoList;
                
                taskLists.Add(list);
            }
        }
        return taskLists;
    }
}