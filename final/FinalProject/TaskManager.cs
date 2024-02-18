public class TaskManager
{
    private List<TaskList> _taskLists = new List<TaskList>();

    public void Init()
    {
        TaskList urgent = new TaskList("Urgent Tasks");
        _taskLists.Add(urgent);

        TaskList completed = new TaskList("Completed Tasks");
        _taskLists.Add(completed);

        TaskList today = new TaskList("Today");
        _taskLists.Add(today);

        Menu menu = new Menu();
        string option;

        menu.DisplayMenu();

        while((option = Console.ReadLine()) != "7")
        {
            switch (option)
            {
                case "1":
                    this.CreateTask();
                    break;

                case "2":
                    this.DeleteTask();
                    break;

                case "3":
                    this.CreateList();
                    break;

                case "4":
                    this.DeleteList();
                    break;

                case "5":
                    this.MarkTaskAsCompleted();
                    break;

                case "6":
                    this.DisplayTaskList();
                    break;
                
                default:
                    Console.WriteLine("\nInvalid value. Enter a valid option.\n");
                    break;
            }

            menu.DisplayMenu();
        }
    }   

    public void CreateTask()
    { 
        Console.WriteLine("\nThe available lists are: ");
        this.DisplayListsNames();
        Console.Write("In which list would you like to create the task? ");
        int listIndex = int.Parse(Console.ReadLine()) - 1;

        Console.Write("The types of Tasks are:\n    1. Regular Task\n    2. Urgent Task\n    3. Recurrent Task\nWhich type of task would you like to create? ");
        string taskType = Console.ReadLine();

        Console.Write("Describe in a few words yur task: ");
        string taskDescription = Console.ReadLine();

        switch (taskType)
        {
            case "1":
                RegularTask regularTask = new RegularTask(taskDescription);
                _taskLists[listIndex].SetTask(regularTask);
                break;

            case "2":
                Console.Write("What is the task priority order? ");
                int priorityOrder = int.Parse(Console.ReadLine());
                UrgentTask urgentTask = new UrgentTask(taskDescription, priorityOrder);
                _taskLists[listIndex].SetTask(urgentTask);
                break;

            case "3":
                RecurrentTask recurrentTask = new RecurrentTask(taskDescription);
                _taskLists[listIndex].SetTask(recurrentTask);
                break;

            default:
                Console.WriteLine("\nInvalid value. Enter a valid option.\n");
                this.CreateTask();
                break;
        }
    }

    public void DeleteTask()
    {
        // this.DisplayTaskList();
        Console.WriteLine("\nThe available lists are: ");
        this.DisplayListsNames();
        Console.Write("Which list do you want to see? ");
        int listIndex = int.Parse(Console.ReadLine()) - 1;
        TaskList list = _taskLists[listIndex];

        Console.WriteLine($"\nDisplaying to-do list [{list.Name}]:");
        list.DisplayTaskList();

        Console.Write("Which task do you want to remove? ");
        int taskIndex = int.Parse(Console.ReadLine()) - 1;

        list.RemoveTask(list.GetTask(taskIndex));
    }

    public void CreateList()
    {
        Console.Write("\nWhat is the name of the list? ");
        string listName = Console.ReadLine();

        TaskList taskList = new TaskList(listName);
        _taskLists.Add(taskList);
    }

    public void DeleteList()
    {   
        Console.WriteLine("\nThe available lists are: ");
        this.DisplayListsNames();
        Console.Write("Which list do you want to remove? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        _taskLists.Remove(_taskLists[index]);
    }

    public void MarkTaskAsCompleted()
    {

    }

    public void DisplayTaskList()
    {
        Console.WriteLine("\nThe available lists are: ");
        this.DisplayListsNames();
        Console.Write("Which list do you want to see? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine($"\nDisplaying to-do list [{_taskLists[index].Name}]:");
        _taskLists[index].DisplayTaskList();
    }

    public void DisplayListsNames()
    {
        foreach (TaskList taskList in _taskLists)
        {
            Console.WriteLine($"    {_taskLists.IndexOf(taskList) + 1}. {taskList.Name}");
        }
    }
}