using LiteDB;

public class EternalGoalDAO
{
    public void Save(EternalGoal goal)
    {
        using(var db = new LiteDatabase("EternalQuest.db"))
        {
            var col = db.GetCollection("eternal_goal");

            if (goal.Id is not null)
            {
                col.Update(new BsonDocument{ ["_id"] = goal.Id, ["CreateDate"] = goal.CreateDate, ["ShortName"] = goal.ShortName, ["Description"] = goal.Description, ["Points"] = goal.Points });
            }
            else
            {
                col.Insert(new BsonDocument{ ["CreateDate"] = goal.CreateDate, ["ShortName"] = goal.ShortName, ["Description"] = goal.Description, ["Points"] = goal.Points });
            }
        }
    }

    public List<EternalGoal> Load()
    {
        List<EternalGoal> eternalGoals = new List<EternalGoal>();
        using(var db = new LiteDatabase("EternalQuest.db"))
        {
            var col = db.GetCollection("eternal_goal");

            var results = col.Query().Select("$").ToList();

            foreach (var r in results)
            {
                eternalGoals.Add(new EternalGoal(r["ShortName"], r["Description"], r["Points"]) { Id = r["_id"], CreateDate = r["CreateDate"] });
            }
        }

        return eternalGoals;
    }
}