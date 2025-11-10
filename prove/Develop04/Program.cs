using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Mindful Moments");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1) Start Breathing Activity");
            Console.WriteLine("2) Start Reflection Activity");
            Console.WriteLine("3) Start Listing Activity");
            
            Console.WriteLine("4) Quit");
            Console.Write("\nChoose an option (1-4): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Start();
                    break;
                case "2":
                    new ReflectionActivity().Start();
                    break;
                case "3":
                    new ListingActivity().Start();
                    break;
                case "4":
                    Console.WriteLine("Goodbye — take care!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
