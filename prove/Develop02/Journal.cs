using System;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    public List<Entry> Entries
    {
        get => _entries;
        set => _entries = value;
    }

    public void AddEntry(Entry entry)
    {

    }
    public void DisplayAll()
    {

    }
    public void SaveToFile(string file)
    {

    }
    public void LoadFromFile(string file)
    {

    }
}