using System;
using System.Collections.Generic;

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
        Entries.Add(entry);
    }
    public void DisplayAll()
    {
        if(Entries.Count == 0)
        {
            Console.WriteLine("Nothing to see here. Add an entry, or load one before trying to display it.\n");
        }
        else
        {
            foreach (Entry e in Entries)
            {
                e.Display();
            }
        }
    }
    public void Save()
    {
        EntryDAO e = new EntryDAO();
        e.Save(Entries);
    }
    public void Load()
    {
        EntryDAO e = new EntryDAO();
        Entries = e.Load();
    }
}