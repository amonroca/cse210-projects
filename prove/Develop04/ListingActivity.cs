public class ListingActivity : Activity
{
    private int _count;
    private List<Prompt> _prompts = new List<Prompt>();

    public ListingActivity(string name, string description) : base(name, description)
    {
        PromptDAO promptDAO = new PromptDAO();
        _prompts = promptDAO.GetListingActivityPrompts();
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

        Console.Write("\nYou may begin in: ");
        base.ShowCountDown(5);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base.Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _count++;
        }

        Console.WriteLine($"You listed {_count} items!");

        base.DisplayEndingMessage();
        base.ShowSpinner(10);
    }

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(_prompts.Count);

        return _prompts[index].Text;
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($"--- {this.GetRandomPrompt()} ---");
    }
}