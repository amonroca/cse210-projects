public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description){}
    
    public void Run()
    {
        base.DisplayStartingMessage();
        Console.WriteLine();
        Console.Write("How long in seconds, would you like for your session? ");
        base.Duration = int.Parse(Console.ReadLine());

        Console.Clear();

        Console.WriteLine("Get ready...");
        base.ShowSpinner(10);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(base.Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreath in...");
            base.ShowCountDown(4);

            Console.WriteLine();

            Console.Write("Now breath out...");
            base.ShowCountDown(4);

            Console.WriteLine();
        }

        base.ShowSpinner(10);

        base.DisplayEndingMessage();
        base.ShowSpinner(10);
    }
}