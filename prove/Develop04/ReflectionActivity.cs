using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you were nice.",
        "Think of a time when you did something that was hard.",
        "Think of a time when you helped someone in need.",
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different from other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?"
    };

    public ReflectionActivity() 
        : base("Reflection Activity",
            "This will help you reflect about yourself.")
    {
        
    }

    protected override void RunActivity(DateTime startTime)
    {
        Console.WriteLine("\n--- Reflection Prompt ---");
        Console.WriteLine(_prompts[_rng.Next(_prompts.Count)]);
        Console.WriteLine("\nTake a moment to think...");
        Countdown(5);

        while (TimeRemaining(startTime))
        {
            Console.WriteLine("\n> " + _questions[_rng.Next(_questions.Count)]);
            Spinner(6);
        }
    }
}
