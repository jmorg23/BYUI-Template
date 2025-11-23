public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override bool IsComplete() => false;

    public override int RecordEvent()
    {
        return _points; // always gives points
    }

    public override string GetSaveData()
    {
        return $"EternalGoal:{_name}|{_description}|{_points}";
    }
}
