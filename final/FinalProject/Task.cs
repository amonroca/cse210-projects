using System;
using System.Collections.Generic;
using LiteDB;

public abstract class Task
{
    private string _description;
    private bool _isCompleted;
    private ObjectId _id;

    public string Description
    {
        get => _description;
        set => _description = value;
    }

    public bool IsCompleted
    {
        get => _isCompleted;
        set => _isCompleted = value;
    }

    public ObjectId Id
    {
        get => _id;
        set => _id = value;
    }

    public Task(string description)
    {
        this._description = description;
        _isCompleted = false;
        _id = ObjectId.NewObjectId();
    }

    public void MarkAsCompleted()
    {
        _isCompleted = true;
    }

    public abstract string GetTaskDetails();
    public abstract void Save(TaskList list);
    public abstract void Delete(TaskList list, int taskIndex);
    public abstract void Update(TaskList list, int taskIndex);
}