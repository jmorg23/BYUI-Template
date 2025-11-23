public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract bool IsComplete();
    public abstract int RecordEvent();
    public abstract string GetSaveData();

    public virtual string GetDetails()
    {
        string check = IsComplete() ? "[X]" : "[ ]";
        return $"{check} {_name} ({_description})";
    }
}
