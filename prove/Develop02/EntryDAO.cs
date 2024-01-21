using System;
using System.Collections.Generic;
using LiteDB;
public class EntryDAO
{
    public void Save(List<Entry> entries)
    {
        using(var db = new LiteDatabase("Journal.db"))
        {
            var col = db.GetCollection<Entry>("entries");

            foreach (Entry e in entries)
            {
                col.Insert(e);
            }
        }

        Console.WriteLine($"Journal saved successfully, {entries.Count} entries were recorded on the database.\n");
    }

    public List<Entry> Load()
    {
        List<Entry> entries = new List<Entry>();
        using(var db = new LiteDatabase("Journal.db"))
        {
            var col = db.GetCollection<Entry>("entries");

            var results = col.Query().Select(x => new { x.Date, x.PromptText, x.EntryText }).ToList();

            foreach (var r in results)
            {
                Entry entry = new Entry();
                
                entry.Date = r.Date;
                entry.PromptText = r.PromptText;
                entry.EntryText = r.EntryText;

                entries.Add(entry);
            }
        }

        Console.WriteLine($"Journal loaded successfully, {entries.Count} entries were retrieved from the database.\n");

        return entries;
    }
}