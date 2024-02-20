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
        Console.WriteLine("\nREMINDER: You are not allowed to create tasks in the Completed Tasks list.");
        Console.WriteLine("You are allowed to cread an Urgent Task only in the Urgent Tasks list.");
        Console.WriteLine("You are allowed to create a Recurrent Task only in the Today to-do list.");
        Console.WriteLine("The available lists are: ");
        this.DisplayListsNames();
        Console.Write("In which list would you like to create the task? ");
        int listIndex = int.Parse(Console.ReadLine()) - 1;
        TaskList taskList = _taskLists[listIndex];

        if (taskList.Name == "Completed Tasks")
        {
            Console.WriteLine("\nYou are not allowed to create tasks in that list. Please Select another one.");
        }
        else
        {
            Console.Write("The types of the task are:\n    1. Regular Task\n    2. Urgent Task\n    3. Recurrent Task\nWhich type of task would you like to create? ");
            string taskType = Console.ReadLine();

            if (taskList.Name == "Urgent Tasks" && taskType != "2")
            {
                Console.WriteLine("\nYou are allowed to create only Urgent Tasks in the Urgent Tasks list.");
            }
            else if (taskList.Name != "Urgent Tasks" && taskType == "2")
            {
                Console.WriteLine("\nYou are allowed to create Urgent Tasks only in the Urgent Tasks list.");
            }
            else if (taskList.Name != "Today" && taskType == "3")
            {
                Console.WriteLine("\nYou are allowed to create Recurrent Tasks only in the Today to-do list.");
            }
            else
            {
                Console.Write("Describe in a few words yur task: ");
                string taskDescription = Console.ReadLine();

                switch (taskType)
                {
                    case "1":
                        Console.Write("Would you like to set a due date for this task (yes/no)? ");
                        string isScheduled = Console.ReadLine().ToLower();

                        if (isScheduled == "yes")
                        {
                            Console.Write("What is the task due date? ");
                            DateTime dueDate = DateTime.Parse(Console.ReadLine());
                            RegularTask regularTask = new RegularTask(taskDescription, dueDate);
                            _taskLists[listIndex].SetTask(regularTask);
                        }
                        else
                        {
                            RegularTask regularTask = new RegularTask(taskDescription);
                            _taskLists[listIndex].SetTask(regularTask);
                        }

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
        }
    }

    public void DeleteTask()
    {
        Console.WriteLine("\nREMINDER: You are not allowed to delete tasks from Completed Tasks list.");
        Console.WriteLine("The available lists are: ");
        this.DisplayListsNames();
        Console.Write("Which list do you want to see? ");
        int listIndex = int.Parse(Console.ReadLine()) - 1;
        TaskList list = _taskLists[listIndex];

        if (list.Name != "Completed Tasks")
        {
            Console.WriteLine($"\nDisplaying to-do list [{list.Name}]:");
            list.DisplayTaskList();

            if (list.ToDoList.Count > 0)
            {
                Console.Write("Which task do you want to remove? ");
                int taskIndex = int.Parse(Console.ReadLine()) - 1;

                list.RemoveTask(list.GetTask(taskIndex));
            }
            else
            {
                Console.WriteLine("\nPlease, select another list.");
            }
        }
        else
        {
            Console.WriteLine("\nYou not allowed to remove tasks from that list. Please, select another one.");
        }
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
        Console.WriteLine();
        Console.WriteLine("\nREMINDER: You are not allowed to remove the following lists:\n    1. Urgent Tasks\n    2. Completed Tasks\n    3. Today");

        if (_taskLists.Count > 3)
        {
            Console.WriteLine("The available lists are: ");
            this.DisplayListsNames();
            Console.Write("Which list do you want to remove? ");
            int index = int.Parse(Console.ReadLine()) - 1;
            TaskList taskList = _taskLists[index];

            if ((taskList.Name != "Urgent Tasks") && (taskList.Name != "Completed Tasks") && taskList.Name != "Today")
            {
                _taskLists.Remove(taskList);
            }
            else
            {
                Console.WriteLine("\nYou are not allowed to remove that list.");
            }
        }
        else
        {
            Console.WriteLine("There is no lists you are allowed to remove.");
        }
    }

    public void MarkTaskAsCompleted()
    {
        Console.WriteLine("\nThe available lists are: ");
        this.DisplayListsNames();
        Console.Write("Which list do you want to see? ");
        int listIndex = int.Parse(Console.ReadLine()) - 1;
        TaskList list = _taskLists[listIndex];

        Console.WriteLine($"\nDisplaying to-do list [{list.Name}]:");
        list.DisplayTaskList();

        Console.Write("Which task did you complete? ");
        int taskIndex = int.Parse(Console.ReadLine()) - 1;

        Task task = list.GetTask(taskIndex);
        task.MarkAsCompleted();

        _taskLists.Find(x => x.Name == "Completed Tasks").SetTask(task);
        // task is not RecurrentTask ? list.RemoveTask(list.GetTask(taskIndex)) : Console.Write("");
        if (task is not RecurrentTask)
        {
            list.RemoveTask(list.GetTask(taskIndex));
        }
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