using System;

public class Entry
{
    private string _date, _promptText, _entryText;
    public string Date
    {
        get => _date;
        set => _date = value;
    }
    public string PromptText
    {
        get => _promptText;
        set => _promptText = value;
    }
    public string EntryText
    {
        get => _entryText;
        set => _entryText = value;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date} - Prompt: {PromptText} \n{EntryText}\n");
    }
}