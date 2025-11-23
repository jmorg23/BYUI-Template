public class ChecklistGoal : Goal
{
    private int _target;
    private int _current;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points,
        int target, int bonus, int current = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _current = current;
    }

    public override bool IsComplete() => _current >= _target;

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _current++;
            if (_current == _target)
                return _points + _bonus;

            return _points;
        }
        return 0;
    }

    public override string GetDetails()
    {
        string check = IsComplete() ? "[X]" : "[ ]";
        return $"{check} {_name} ({_description}) -- Completed {_current}/{_target}";
    }

    public override string GetSaveData()
    {
        return $"ChecklistGoal:{_name}|{_description}|{_points}|{_bonus}|{_target}|{_current}";
    }
}
