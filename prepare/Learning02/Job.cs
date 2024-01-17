using System;

public class Job
{
    public string _company, _jobTitle;
    public int _startYear, _endYear;

    public void Display()
    {
        Console.WriteLine($"{this._jobTitle} ({this._company}) {this._startYear}-{this._endYear}");
    }
}