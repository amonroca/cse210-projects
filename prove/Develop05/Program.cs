/* I have added a lot of things to this program. First I've created a new class (Menu) to make handling the menu easier, especially if you want to add new options 
(in fact I've added a new option to the menu). Secondly, I've created four new classes ( SompleGoalDAO, EternalGoalDAO, ChecklistGoalDAO, and ScoreDAO) 
to handle the database access, since I'm using a LiteDB database to store the goals and their properties, as well as to store the user score. 
Third, I've created a score log feature through which it is possible to check the log of the score the user has earned by the accomplishment of the goals. 
Finally, I've added several state validations to avoid nullPointer and other runtime exceptions.
I had a lot of work and spent much more time than I had available to build this simple program, so I would like to ask a favor who will grade this assignment, 
please, provide reasonable feedback rather than only set the rubric. Sometimes is difficult to know what exactly is wrong without an explanation. 
If you provide good feedback most likely I will be capable of avoiding the same mistake in the next assignment. */

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}