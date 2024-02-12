using LiteDB;

public class ChecklistGoalDAO
{
    public void Save(ChecklistGoal goal)
    {
        using(var db = new LiteDatabase("EternalQuest.db"))
        {
            var col = db.GetCollection("checklist_goal");

            if (goal.Id is not null)
            {
                col.Update(new BsonDocument{ ["_id"] = goal.Id, ["CreateDate"] = goal.CreateDate, ["ShortName"] = goal.ShortName, ["Description"] = goal.Description, ["Points"] = goal.Points, ["AmountCompleted"] = goal.AmountCompleted, ["Target"] = goal.Target, ["Bonus"] = goal.Bonus });
            }
            else
            {
                col.Insert(new BsonDocument{ ["CreateDate"] = goal.CreateDate, ["ShortName"] = goal.ShortName, ["Description"] = goal.Description, ["Points"] = goal.Points, ["AmountCompleted"] = goal.AmountCompleted, ["Target"] = goal.Target, ["Bonus"] = goal.Bonus });
            }
        }
    }

    public List<ChecklistGoal> Load()
    {
        List<ChecklistGoal> checklistGoals = new List<ChecklistGoal>();
        using(var db = new LiteDatabase("EternalQuest.db"))
        {
            var col = db.GetCollection("checklist_goal");

            var results = col.Query().Select("$").ToList();

            foreach (var r in results)
            {
                checklistGoals.Add(new ChecklistGoal(r["ShortName"], r["Description"], r["Points"], r["Target"], r["Bonus"]) { Id = r["_id"], CreateDate = r["CreateDate"], AmountCompleted = r["AmountCompleted"] });
            }
        }

        return checklistGoals;
    }
}