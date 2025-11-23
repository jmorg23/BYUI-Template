class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        int choice = 0;

        while (choice != 7)
        {
            Console.WriteLine("\nEternal Quest Menu");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save");
            Console.WriteLine("6. Load");
            Console.WriteLine("7. Quit");
            Console.Write("Choose: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateGoal(manager);
                    break;

                case 2:
                    manager.ListGoals();
                    break;

                case 3:
                    manager.RecordGoal();
                    break;

                case 4:
                    manager.DisplayScore();
                    break;

                case 5:
                    Console.Write("File name: ");
                    manager.Save(Console.ReadLine());
                    break;

                case 6:
                    Console.Write("File name: ");
                    manager.Load(Console.ReadLine());
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nWhich type of goal?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int pts = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            manager.AddGoal(new SimpleGoal(name, desc, pts));
        }
        else if (choice == 2)
        {
            manager.AddGoal(new EternalGoal(name, desc, pts));
        }
        else if (choice == 3)
        {
            Console.Write("Times needed: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            manager.AddGoal(new ChecklistGoal(name, desc, pts, target, bonus));
        }
    }
}
