public class Menu
{
    private List<string> _options = new List<string>();

    public Menu()
    {
        _options.Add("1. Create New Goal");
        _options.Add("2. List Goals");
        _options.Add("3. Save Goals");
        _options.Add("4. Load Goals");
        _options.Add("5. Record Event");
        _options.Add("6. View Score Log");
        _options.Add("7. Quit");
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");

        foreach (string option in _options)
        {
            Console.WriteLine($"    {option}");
        }

        Console.Write("Select a choice from the menu: ");
    }
}