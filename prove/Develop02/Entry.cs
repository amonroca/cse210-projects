using System;

public class Entry
{
    string _date, _promptText, _entryText;
    string Date
    {
        get => _date;
        set => _date = value;
    }
    string PromptText
    {
        get => _promptText;
        set => _promptText = value;
    }
    string EntryText
    {
        get => _entryText;
        set => _entryText = value;
    }

    public void Display()
    {
        
    }
}