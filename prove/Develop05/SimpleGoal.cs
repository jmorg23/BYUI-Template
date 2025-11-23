public class SimpleGoal : Goal
{
    private bool _complete;

    public SimpleGoal(string name, string description, int points, bool complete = false)
        : base(name, description, points)
    {
        _complete = complete;
    }

    public override bool IsComplete() => _complete;

    public override int RecordEvent()
    {
        if (!_complete)
        {
            _complete = true;
            return _points;
        }
        return 0;
    }

    public override string GetSaveData()
    {
        return $"SimpleGoal:{_name}|{_description}|{_points}|{_complete}";
    }
}
