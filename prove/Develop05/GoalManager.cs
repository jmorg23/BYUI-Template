using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void DisplayScore()
    {
        Console.WriteLine($"\nYour current score: {_score}\n");
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        int i = 1;
        foreach (var g in _goals)
        {
            Console.WriteLine($"{i}. {g.GetDetails()}");
            i++;
        }
    }

    public void AddGoal(Goal g)
    {
        _goals.Add(g);
    }

    public void RecordGoal()
    {
        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int points = _goals[index].RecordEvent();
        _score += points;

        Console.WriteLine($"You earned {points} points!");
    }

    public void Save(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.WriteLine(_score);
            foreach (var g in _goals)
            {
                sw.WriteLine(g.GetSaveData());
            }
        }
    }

    public void Load(string filename)
    {
        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');
            string type = parts[0];
            string[] data = parts[1].Split('|');

            switch (type)
            {
                case "SimpleGoal":
                    AddGoal(new SimpleGoal(data[0], data[1],
                        int.Parse(data[2]), bool.Parse(data[3])));
                    break;

                case "EternalGoal":
                    AddGoal(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    break;

                case "ChecklistGoal":
                    AddGoal(new ChecklistGoal(
                        data[0], data[1], int.Parse(data[2]),
                        int.Parse(data[4]), int.Parse(data[3]), int.Parse(data[5])));
                    break;
            }
        }
    }
}
