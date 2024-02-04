public class ReflectingActivity : Activity
{
    private List<Prompt> _prompts = new List<Prompt>();
    private List<Question> _questions = new List<Question>();

    public ReflectingActivity(string name, string description) : base(name, description)
    {
        PromptDAO promptDAO = new PromptDAO();
        _prompts = promptDAO.GetReflectingActivityPrompts();

        QuestionDAO questionDAO = new QuestionDAO();
        _questions = questionDAO.GetReflectingActivityQuestions();
    }

    public void Run()
    {
        base.DisplayStartingMessage();
        Console.WriteLine();
        Console.Write("How long in seconds, would you like for your session? ");
        base.Duration = int.Parse(Console.ReadLine());

        Console.Clear();

        Console.WriteLine("Get ready...");
        base.ShowSpinner(10);

        Console.WriteLine("\nConsider the following prompt:\n");
        this.DisplayPrompt();

        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this esperience.");
        Console.Write("You may begin in: ");
        base.ShowCountDown(5);

        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base.Duration);

        while (DateTime.Now < endTime)
        {
            this.DisplayQuestions();
            base.ShowSpinner(10);
            Console.WriteLine();
        }

        base.DisplayEndingMessage();
        base.ShowSpinner(10);
    }

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_prompts.Count);

        return _prompts[index].Text;
    }

    public string GetRandomQuestion()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_questions.Count);
        return _questions[index].Text;
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($"--- {this.GetRandomPrompt()} ---");
    }

    public void DisplayQuestions()
    {
        Console.Write($"> {this.GetRandomQuestion()}");
    }
}