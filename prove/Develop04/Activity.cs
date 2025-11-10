using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;

    protected Random _rng = new Random();

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"=== {_name} ===");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration for this activity (in seconds): ");

        _durationSeconds = AskForPositiveInt();

        Console.WriteLine("\nGet ready...");
        Spinner(3);

        DateTime startTime = DateTime.Now;
        RunActivity(startTime);

        Console.WriteLine("\nWell done!");
        Console.WriteLine($"You completed the {_name} for {_durationSeconds} seconds.");
        Spinner(3);

        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }

    protected int Duration => _durationSeconds;

    protected bool TimeRemaining(DateTime startTime)
    {
        return (DateTime.Now - startTime).TotalSeconds < _durationSeconds;
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"Starting in {i}...");
            Thread.Sleep(1000);
            Console.Write("\r" + new string(' ', 20) + "\r");
        }
    }

    protected void Spinner(int seconds)
    {
        char[] chars = { '|', '/', '-', '\\' };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int counter = 0;

        while (DateTime.Now < end)
        {
            Console.Write(chars[counter] + " ");
            Thread.Sleep(250);
            Console.Write("\r ");
            counter++;
            if (counter >= 3)
            {
                counter = 0;
            }
        }
        Console.Write("\r  \r");
    }

    private int AskForPositiveInt()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int val) && val > 0)
                return val;

            Console.Write("Please enter a positive number: ");
        }
    }

    protected abstract void RunActivity(DateTime startTime);
}
