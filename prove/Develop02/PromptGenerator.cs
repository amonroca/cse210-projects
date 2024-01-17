using System;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>();
    public List<string> Prompts
    {
        get => _prompts;
        set => _prompts = value;
    }

    public string GetRandomPrompt()
    {
        return "";
    }
}