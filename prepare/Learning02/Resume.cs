using System;
// using Job;

public class Resume{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {this._name}");
        Console.WriteLine($"Jobs:");
        foreach (Job job in this._jobs)
        {
            job.Display();
        }
    }
}