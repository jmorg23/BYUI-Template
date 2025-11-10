using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() 
        : base("Listing Activity",
            "This will help you reflect on the good things in your life by listing as many as you can.")
    {
        
    }

    protected override void RunActivity(DateTime startTime)
    {
        Console.WriteLine("\n--- Listing Prompt ---");
        Console.WriteLine(_prompts[_rng.Next(_prompts.Count)]);

        Console.WriteLine("\nTake a few seconds to think...");
        Countdown(5);

        List<string> items = new List<string>();
        Console.WriteLine("\nList items (press Enter after each):");

        while (TimeRemaining(startTime))
        {
            Console.Write("> ");
            string entry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry))
                items.Add(entry);
        }

        Console.WriteLine($"\nYou listed {items.Count} items:");
        foreach (var item in items)
            Console.WriteLine($"- {item}");
    }
}
