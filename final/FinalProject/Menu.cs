public class Menu
{
    private List<string> _options = new List<string>();

    public Menu()
    {
        _options.Add("1. Create New Task");
        _options.Add("2. Remove Task");
        _options.Add("3. Create New List");
        _options.Add("4. Remove List");
        _options.Add("5. Mark Task As Completed");
        _options.Add("6. View Task List");
        _options.Add("7. Quit");
    }

    public void DisplayMenu()
    {
        Console.WriteLine("\nMenu Options:");

        foreach (string option in _options)
        {
            Console.WriteLine($"    {option}");
        }

        Console.Write("Select a choice from the menu: ");
    }
}