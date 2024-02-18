using System;
using System.Collections.Generic;

public abstract class Task
{
    private string _description;
    private bool _isCompleted;

    public string Description
    {
        get => _description;
        set => _description = value;
    }

    private bool IsCompleted
    {
        get => _isCompleted;
        set => _isCompleted = value;
    }

    public Task(string description)
    {
        this._description = description;
        _isCompleted = false;
    }

    public void MarkAsCompleted()
    {
        _isCompleted = true;
    }

    public abstract string GetTaskDetails();
    public abstract void Save(TaskList list);
    public abstract void Delete();
}