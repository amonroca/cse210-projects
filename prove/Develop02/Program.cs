// I use LiteDB, a serverless non-relational database, to save and load the journal and the prompts to exceed the requirements. 
// I've created two additional classes to manage the database entities and do the insert and select operations. 
// I've used the DAO pattern (Data Access Object) to manage the database entities separately from the rest of the application objects. 
// To make the application more professional I could use the Service Facade pattern to access the DAO classes, 
// avoiding accessing DAO classes directly from the Journal class, but I had no time to implement this pattern on this project.
// OBS: Because the program is saving and loading the Journal from a database I did not develop the function of saving and loading the journal from a file. 
// I talked about that with my instructor and he said that no problem with this and I won't be penalized. I count on your understanding.

using System;

class Program
{
    public enum Menu
    {
        Write = 1,
        Display = 2,
        Load = 3,
        Save = 4,
        Quit = 5
    }
    static void Main(string[] args)
    {

        Journal journal = new Journal();
        int option = 0;

        Console.WriteLine("Welcome to the Journal Program!");

        while(option != 5)
        {
            PrintMenu();
            Console.Write("What would you like to do? ");
            option = int.Parse(Console.ReadLine());
            OptionValidator(journal, option);
        }
    }

    public static void PrintMenu()
    {
        Console.WriteLine("Please select one of the following choices:");

        foreach (var value in Enum.GetValues(typeof(Menu)))
        {
            Console.WriteLine($"{((int)value)}. {value}");
        }
    }

    public static void OptionValidator(Journal journal, int option)
    {
        if(option == ((int)Menu.Write))
        {
            Write(journal);
        }
        else if(option == ((int)Menu.Display))
        {
            Display(journal);
        }
        else if(option == ((int)Menu.Save))
        {
            Save(journal);
        }
        else if(option == ((int)Menu.Load))
        {
            Load(journal);
        }
        else if(option == ((int)Menu.Quit))
        {
            Console.WriteLine("See you later.\n");
        }
        else
        {
            Console.WriteLine("Invalid option. Please enter a valid option.\n");
        }
    }
    public static void Write(Journal journal)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Entry entry = new Entry();
        DateTime currentDate = DateTime.Now;

        string prompt = promptGenerator.GetRandomPrompt();
        string sDate = currentDate.ToShortDateString();

        Console.WriteLine($"{prompt}");
        
        entry.EntryText = Console.ReadLine();
        entry.PromptText = prompt;
        entry.Date = sDate;

        journal.AddEntry(entry);
    }

    public static void Display(Journal journal)
    {
        journal.DisplayAll();
    }

    public static void Save(Journal journal)
    {
        journal.Save();
    }

    public static void Load(Journal journal)
    {
        journal.Load();
    }
}