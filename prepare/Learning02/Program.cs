using System;

class Program
{
    static void Main(string[] args)
    {
        Job firstJob = new Job();
        firstJob._jobTitle = "Software Engineer";
        firstJob._company = "Microsoft";
        firstJob._startYear = 2019;
        firstJob._endYear = 2022;
        // firstJob.Display();
        Job secondJob = new Job();
        secondJob._jobTitle = "Manager";
        secondJob._company = "Apple";
        secondJob._startYear = 2022;
        secondJob._endYear = 2023;
        // secondJob.Display();

        Resume myResume = new Resume();
        myResume._name = "Allison Rose";
        myResume._jobs.Add(firstJob);
        myResume._jobs.Add(secondJob);

        myResume.Display();
    }
}