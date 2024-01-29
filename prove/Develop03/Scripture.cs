public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        foreach (string w in text.Split(' '))
        {
            Word word = new Word(w);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        int count = 0;

        while (count < numberToHide && !this.IsCompletelyHidden())
        {
            Random randomSelector = new Random();
            int index = randomSelector.Next(_words.Count);

            Word wordToHide = _words[index];

            if (!wordToHide.IsHidden())
            {
                wordToHide.Hide();
                wordToHide.Text = wordToHide.Text.Replace(wordToHide.Text, new string('_', wordToHide.Text.Length));
                count++;
            }
            else
            {
                continue;
            }
        }
    }

    public string GetDisplayText()
    {
        string text = "";
        _words.ForEach(element => text += element.Text + " ");
        return _reference.GetDisplayText() + text;
    }

    public bool IsCompletelyHidden()
    {
        if (_words.Exists(x => x.IsHidden() == false))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}