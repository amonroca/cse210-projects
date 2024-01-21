using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>();
    public List<string> Prompts
    {
        get => _prompts;
        set => _prompts = value;
    }

/*     public PromptGenerator()
    {
        Prompts.Add("Who was the most interesting person I interacted with today?");
        Prompts.Add("What was the best part of my day?");
        Prompts.Add("How did I see the hand of the Lord in my life today?");
        Prompts.Add("What was the strongest emotion I felt today?");
        Prompts.Add("If I had one thing I could do over today, what would it be?");
    } */

    public PromptGenerator()
    {
        PromptDAO p = new PromptDAO();
        Prompts = p.Load();
    }

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        int index = randomGenerator.Next(Prompts.Count);

        return Prompts[index];
    }
}