using LiteDB;

public class PromptDAO
{
    public List<Prompt> GetReflectingActivityPrompts()
    {
        List<Prompt> prompts = new List<Prompt>();
        using(var db = new LiteDatabase("Mindfulness.db"))
        {
            var col = db.GetCollection<Prompt>("prompts");

            var results = col.Query().Where(x => x.RelatedActivity.Equals("Reflecting Activity")).Select(x => new { x.RelatedActivity, x.IsActive, x.Text }).ToList();

            foreach (var r in results)
            {   Prompt prompt = new Prompt(r.RelatedActivity, r.IsActive, r.Text);
                prompts.Add(prompt);
            }
        }

        return prompts;
    }

    public List<Prompt> GetListingActivityPrompts()
    {
        List<Prompt> prompts = new List<Prompt>();
        using(var db = new LiteDatabase("Mindfulness.db"))
        {
            var col = db.GetCollection<Prompt>("prompts");

            var results = col.Query().Where(x => x.RelatedActivity.Equals("Listing Activity")).Select(x => new { x.RelatedActivity, x.IsActive, x.Text }).ToList();

            foreach (var r in results)
            {   Prompt prompt = new Prompt(r.RelatedActivity, r.IsActive, r.Text);
                prompts.Add(prompt);
            }
        }

        return prompts;
    }
}