public class Menu
{
    private Dictionary<string, string> _options = new Dictionary<string, string>();

    public Dictionary<string, string> Options
    {
        get => _options;
        set => _options = value;
    }

    public Menu()
    {
        _options.Add("1", Constants.MENU_OPTION_ONE);
        _options.Add("2", Constants.MENU_OPTION_TWO);
        _options.Add("3", Constants.MENU_OPTION_THREE);
        _options.Add("4", Constants.MENU_OPTION_FOUR);
    }
    public void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");

        foreach (KeyValuePair<string, string> kvp in _options)
        {
            Console.WriteLine($"\t{kvp.Key}. {kvp.Value}");
        }
    }
}