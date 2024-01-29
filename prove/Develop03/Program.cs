// I have created a library of scriptures using LiteDB, a serverless non-relational database, and the program is choosing one at random to present to the user.

using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureDAO s = new ScriptureDAO();
        List<Scripture> scripturesList = s.Load();

        Random randomScripture = new Random();

        Scripture scripture = scripturesList[randomScripture.Next(scripturesList.Count)];

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");

        while (!scripture.IsCompletelyHidden() && Console.ReadLine().ToLower() != "quit")
        {
            scripture.HideRandomWords(3);

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
        }
    }
}