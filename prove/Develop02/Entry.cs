

class Entry
{
    public string _date;
    public string _contents;
    public string _name;

    public int _index;

    public Entry(int index)
    {
        _date = DateTime.Now.ToShortDateString();
        _contents = "";
        _name = "";
        _index = index;
    }


    public Entry(string contents)
    {
        _date = contents.Split('\n')[0];
        _contents = contents;
        _name = "";
        _index = 0;
    }

}