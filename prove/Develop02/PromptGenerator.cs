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