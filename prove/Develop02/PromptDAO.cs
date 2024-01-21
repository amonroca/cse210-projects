using System;
using System.Collections.Generic;
using LiteDB;

public class PromptDAO
{
    public class Prompt
    {
        private string _promptText;
        public string PromptText
        {
            get => _promptText;
            set => _promptText = value;
        }
    }

    public List<string> Load()
    {
        List<string> prompts = new List<string>();
        using(var db = new LiteDatabase("Journal.db"))
        {
            var col = db.GetCollection<Prompt>("prompts");

            var results = col.Query().Select(x => new { x.PromptText }).ToList();

            foreach (var r in results)
            {   
                prompts.Add(r.PromptText);
            }
        }

        return prompts;
    }
}