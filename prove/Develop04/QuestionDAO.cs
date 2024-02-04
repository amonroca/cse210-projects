using LiteDB;

public class QuestionDAO
{
    public List<Question> GetReflectingActivityQuestions()
    {
        List<Question> questions = new List<Question>();
        using(var db = new LiteDatabase("Mindfulness.db"))
        {
            var col = db.GetCollection<Question>("questions");

            var results = col.Query().Select(x => new { x.IsActive, x.Text }).ToList();

            foreach (var r in results)
            {   Question question = new Question(r.IsActive, r.Text);
                questions.Add(question);
            }
        }

        return questions;
    }
}