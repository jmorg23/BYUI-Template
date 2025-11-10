using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
            "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.")
    {

    }

    protected override void RunActivity(DateTime startTime)
    {
        bool inhale = true;

        while (TimeRemaining(startTime))
        {
            Console.WriteLine(inhale ? "\nBreathe in..." : "\nBreathe out...");

            for (int i = 4; i >= 1; i--)
            {
                Console.Write($"\r{i}   ");
                Thread.Sleep(1000);
            }
            Console.Write("\r     \r");

            inhale = !inhale;
        }
    }
}
