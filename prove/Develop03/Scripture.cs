

public class Scripture
{
    private List<Word> _words = new List<Word>();

    public Scripture(string scripture)
    {

        string[] wordsCon = scripture.Split(" ");
        foreach (string s in wordsCon)
        {
            _words.Add(new Word(s));
        }


    }

    public void Display()
    {
        foreach (Word w in _words)
        {
            Console.Write(w.GetWord() + " ");
        }

    }
    
    public bool Next()
    {
        Random r = new Random();
        List<int> tried = new List<int>();

        while (tried.Count < _words.Count)
        {

            int i;
            while (tried.Contains(i = r.Next(_words.Count)));
            tried.Add(i);
            if (!_words[i].IsHidden())
            {
                _words[i].hide();
                return true;
            }
        }
        return false;

    }
}