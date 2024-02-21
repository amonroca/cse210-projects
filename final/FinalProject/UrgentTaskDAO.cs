using LiteDB;

public class UrgentTaskDAO
{
    public void Save(UrgentTask task, TaskList list)
    {
        using(var db = new LiteDatabase("ToDoList.db"))
        {
            var ut = db.GetCollection<UrgentTask>("urgent_task");
            var tl = db.GetCollection<TaskList>("task_list");

            ut.Insert(task);

            var taskList = tl.Query().Where(x => x.Id.Equals(list.Id)).Select(x => new { x.Id, x.Name, x.ToDoList }).FirstOrDefault();
            taskList.ToDoList.Add(task);
            TaskList newList = new TaskList(taskList.Name);
            newList.Id = taskList.Id;
            newList.ToDoList = taskList.ToDoList;

            tl.Update(newList);
        }
    }

    public void Delete(UrgentTask task, TaskList list, int taskIndex)
    {
        using(var db = new LiteDatabase("ToDoList.db"))
        {
            var ut = db.GetCollection<UrgentTask>("urgent_task");
            var tl = db.GetCollection<TaskList>("task_list");
            var remove = new BsonValue(task.Id);

            ut.Delete(remove);

            var taskList = tl.Query().Where(x => x.Id.Equals(list.Id)).Select(x => new { x.Id, x.Name, x.ToDoList }).FirstOrDefault();
            taskList.ToDoList.RemoveAt(taskIndex);
            TaskList newList = new TaskList(taskList.Name);
            newList.Id = taskList.Id;
            newList.ToDoList = taskList.ToDoList;

            tl.Update(newList);
        }
    }

    public void Update(UrgentTask task, TaskList list, int taskIndex)
    {
        using(var db = new LiteDatabase("ToDoList.db"))
        {
            var ut = db.GetCollection<UrgentTask>("urgent_task");
            var tl = db.GetCollection<TaskList>("task_list");

            ut.Update(task);

            var taskListAdd = tl.Query().Where(x => x.Name.Equals("Completed Tasks")).Select(x => new { x.Id, x.Name, x.ToDoList }).FirstOrDefault();
            taskListAdd.ToDoList.Add(task);
            TaskList newListAdd = new TaskList(taskListAdd.Name);
            newListAdd.Id = taskListAdd.Id;
            newListAdd.ToDoList = taskListAdd.ToDoList;

            tl.Update(newListAdd);

            var taskListDel = tl.Query().Where(x => x.Id.Equals(list.Id)).Select(x => new { x.Id, x.Name, x.ToDoList }).FirstOrDefault();
            taskListDel.ToDoList.RemoveAt(taskIndex);
            TaskList newListDel = new TaskList(taskListDel.Name);
            newListDel.Id = taskListDel.Id;
            newListDel.ToDoList = taskListDel.ToDoList;

            tl.Update(newListDel);
        }
    }
}