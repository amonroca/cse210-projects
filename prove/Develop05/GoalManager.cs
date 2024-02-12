public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        Menu menu = new Menu();
        string option;

        this.DisplayPlayerInfo();
        menu.DisplayMenu();

        while((option = Console.ReadLine()) != "7")
        {
            switch (option)
            {
                case "1":
                    this.CreateGoal();
                    break;

                case "2":
                    this.ListGoalDetails();
                    break;

                case "3":
                    this.SaveGoals();
                    break;

                case "4":
                    this.LoadGoals();
                    break;

                case "5":
                    this.RecordEvent();
                    break;

                case "6":
                    this.ViewScoreLog();
                    break;
                
                default:
                    Console.WriteLine("\nInvalid value. Enter a valid option.\n");
                    break;
            }

            this.DisplayPlayerInfo();
            menu.DisplayMenu();
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nThe goals are:");
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{_goals.IndexOf(goal) + 1}. {goal.ShortName}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count > 0)
        {
            Console.WriteLine("\nThe goals are:");
            foreach (Goal goal in _goals)
            {
                Console.WriteLine($"{_goals.IndexOf(goal) + 1}. {goal.GetDetailsString()}");
            }
        }
        else
        {
            Console.WriteLine("\nThere are no goals to list. Try to load or create a new one.");
        }
    }

    public void CreateGoal()
    {
        Console.Write("The types of Goals are:\n    1. Simple Goal\n    2. Eternal Goal\n    3. Checklist Goal\nWhich type of goal would you like to create? ");
        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string goalDescription = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int goalPoints = int.Parse(Console.ReadLine());

        switch (goalType)
        {
            case "1":
                SimpleGoal simpleGoal = new SimpleGoal(goalName, goalDescription, goalPoints);
                simpleGoal.CreateDate = DateTime.Now;
                _goals.Add(simpleGoal);
                break;

            case "2":
                EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, goalPoints);
                eternalGoal.CreateDate = DateTime.Now;
                _goals.Add(eternalGoal);
                break;

            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int targetGoal = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonusGoal = int.Parse(Console.ReadLine());
                ChecklistGoal checklistGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, targetGoal, bonusGoal);
                checklistGoal.CreateDate = DateTime.Now;
                _goals.Add(checklistGoal);
                break;

            default:
                Console.WriteLine("\nInvalid value. Enter a valid option.\n");
                this.CreateGoal();
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count > 0)
        {
            this.ListGoalNames();
            Console.Write("Which goal did you accomplish? ");
            int goalIndex = int.Parse(Console.ReadLine()) - 1;

            ScoreDAO scoreDAO = new ScoreDAO();
            Goal goal = _goals[goalIndex];

            goal.RecordEvent();
            
            int points = goal.Points;
            int currentScore = _score;

            currentScore += points;
            scoreDAO.Save(goal, _score, currentScore);
            _score = currentScore;
            
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("\nThere are no goals to record an event. Try to load or create a new one.");
        }
    }

    public void SaveGoals()
    {
        if (_goals.Count > 0)
        {
            foreach (Goal goal in _goals)
            {
                goal.SaveGoal();
            }

            Console.WriteLine("\nGoals saved successfully.");
        }
        else
        {
            Console.WriteLine("\nThere are no goals to be saved. Try to load or create a new one.");
        }
    }

    public void LoadGoals()
    {
        SimpleGoalDAO simpleGoalDAO = new SimpleGoalDAO();
        EternalGoalDAO eternalGoalDAO = new EternalGoalDAO();
        ChecklistGoalDAO checklistGoalDAO = new ChecklistGoalDAO();
        ScoreDAO scoreDAO = new ScoreDAO();

        _goals.AddRange(simpleGoalDAO.Load());
        _goals.AddRange(eternalGoalDAO.Load());
        _goals.AddRange(checklistGoalDAO.Load());

        if (_goals.Count > 0)
        {
            _goals.Sort((x, y) => DateTime.Compare(x.CreateDate, y.CreateDate));
            _score = scoreDAO.LoadCurrentScore();

            Console.WriteLine($"\n{_goals.Count} goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("\nThere are no goals to load. Try to create a new one");
        }
    }

    public void ViewScoreLog()
    {
        ScoreDAO scoreDAO = new ScoreDAO();
        List<string> scoreLog = new List<string>();
        scoreLog.AddRange(scoreDAO.LoadScoreLog());

        if (scoreLog.Count > 0)
        {
            Console.WriteLine("\n|----------------------------------------- LOG BEGINNING --------------------------------------|\n");
        
            foreach (string log in scoreLog)
            {
                Console.WriteLine(log);
            }

            Console.WriteLine("\n|-------------------------------------------- LOG END -----------------------------------------|");
        }
        else
        {
            Console.WriteLine("\nThere are no logs to show.");
        }
    }
}