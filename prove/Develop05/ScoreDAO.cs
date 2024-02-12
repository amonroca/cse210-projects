
using LiteDB;
public class ScoreDAO
{
    public void Save(Goal goal, int lastScore, int currentScore)
    {
        using(var db = new LiteDatabase("EternalQuest.db"))
        {
            var col = db.GetCollection("score_log");

            col.Insert(new BsonDocument{ ["CreateDate"] = DateTime.Now, ["ShortName"] = goal.ShortName, ["Points"] = goal.Points, ["LastScore"] = lastScore, ["CurrentScore"] = currentScore });
        }
    }

    public int LoadCurrentScore()
    {
        int currentScore = 0;
        using(var db = new LiteDatabase("EternalQuest.db"))
        {
            var col = db.GetCollection("score_log");

            var result = col.Query().OrderByDescending("CreateDate").Select("CurrentScore").FirstOrDefault();

            if (result is not null)
            {
                currentScore = result["CurrentScore"];
            } 
        }

        return currentScore;
    }

    public List<string> LoadScoreLog()
    {
        List<string> scoreLog = new List<string>();
        using(var db = new LiteDatabase("EternalQuest.db"))
        {
            var col = db.GetCollection("score_log");

            var results = col.Query().Select("$").ToList();

            if (results is not null)
            {
                foreach (var r in results)
                {
                    DateTime dateTime = r["CreateDate"];
                    string log = $"Accomplishment date: {dateTime.ToString()} | Goal accomplished: {r["ShortName"]} | Points earned: {r["Points"]}";
                    scoreLog.Add(log);
                }
            }
        }

        return scoreLog;
    }
}