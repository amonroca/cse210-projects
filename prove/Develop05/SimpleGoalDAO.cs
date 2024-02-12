using LiteDB;

public class SimpleGoalDAO
{
    public void Save(SimpleGoal goal)
    {
        using(var db = new LiteDatabase("EternalQuest.db"))
        {
            var col = db.GetCollection("simple_goal");

            if (goal.Id is not null)
            {
                col.Update(new BsonDocument{ ["_id"] = goal.Id, ["CreateDate"] = goal.CreateDate, ["ShortName"] = goal.ShortName, ["Description"] = goal.Description, ["Points"] = goal.Points, ["IsComplete"] = goal.IsCompleted });
            }
            else
            {
                col.Insert(new BsonDocument{ ["CreateDate"] = goal.CreateDate, ["ShortName"] = goal.ShortName, ["Description"] = goal.Description, ["Points"] = goal.Points, ["IsComplete"] = goal.IsCompleted });
            }
        }
    }

    public List<SimpleGoal> Load()
    {
        List<SimpleGoal> simpleGoals = new List<SimpleGoal>();
        using(var db = new LiteDatabase("EternalQuest.db"))
        {
            var col = db.GetCollection("simple_goal");

            var results = col.Query().Select("$").ToList();

            foreach (var r in results)
            {
                simpleGoals.Add(new SimpleGoal(r["ShortName"], r["Description"], r["Points"]) { Id = r["_id"], CreateDate = r["CreateDate"], IsCompleted = r["IsComplete"] });
            }
        }

        return simpleGoals;
    }
}