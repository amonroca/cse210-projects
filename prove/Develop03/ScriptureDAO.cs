using LiteDB;
public class ScriptureDAO
{
    public class ScriptureEntity
    {
        private string _book, _text;
        private int _chapter, _verse, _endVerse;

        public string Book
        {
            get => _book;
            set => _book = value;
        }

        public string Text
        {
            get => _text;
            set => _text = value;
        }

        public int Chapter
        {
            get => _chapter;
            set => _chapter = value;
        }

        public int Verse
        {
            get => _verse;
            set => _verse = value;
        }

        public int EndVerse
        {
            get => _endVerse;
            set => _endVerse = value;
        }
    }

    public List<Scripture> Load()
    {
        List<Scripture> scriptures = new List<Scripture>();
        using(var db = new LiteDatabase("Memorizer.db"))
        {
            var col = db.GetCollection<ScriptureEntity>("scriptures");

            var results = col.Query().Select(x => new { x.Book, x.Text, x.Chapter, x.Verse, x.EndVerse }).ToList();

            foreach (var r in results)
            {   Reference reference = new Reference(r.Book, r.Chapter, r.Verse, r.EndVerse);
                Scripture scripture = new Scripture(reference, r.Text);
                scriptures.Add(scripture);
            }
        }

        return scriptures;
    }
}