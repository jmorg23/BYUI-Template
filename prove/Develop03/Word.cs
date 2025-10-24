public class Word
{
    private string _word;
    private bool _hidden;

    public Word(string word)
    {
        _word = word;
    }
    public void hide()
    {
        _hidden = true;

    }

    public void show()
    {
        _hidden = false;
    }
    public bool IsHidden()
    {
        return _hidden;
    }
    public string GetWord()
    {
        string con = "";
        if (_hidden)
        {
            int letters = _word.Length;
            for (int i = 0; i < letters; i++)
            {
                con += '_';
            }
            return con;
        }
        else
        {
            return _word;
        }
    }
}