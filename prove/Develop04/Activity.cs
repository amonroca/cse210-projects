public class Activity
{
    private string _name, _description;
    private int _duration;

    public Activity( string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Description
    {
        get => _description;
        set => _description = value;
    }

    public int Duration
    {
        get => _duration;
        set => _duration = value;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n\n{_description}");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        
        this.ShowSpinner(10);

        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
    }

    public void ShowSpinner(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = Constants.animationStrings[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i >= Constants.animationStrings.Length)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}