
public class Refrence
{
        private static List<Scripture> scriptures = new List<Scripture>();

    public static void Start()
    {
        Console.WriteLine("Hello and welconme to scripture memorizing 101. what would you like to study: \n1: 1 Nephi 3\n2: James 1");

        string[] lines;

        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                lines = File.ReadAllLines("1nephi3.txt");
                Console.WriteLine("We will start with 1 Nephi chapter 3!, what verse or verses would you like to learn(type 1-4 for verses 1 to 4, etc)");

                break;
            case 2:
                lines = File.ReadAllLines("james1.txt");
                Console.WriteLine("We will start with James chapter 1!, what verse or verses would you like to learn(type 1-4 for verses 1 to 4, etc)");


                break;
            default:
                Console.WriteLine("lets try this again!");
                return;

        }


        string option = Console.ReadLine();
        if (option.Contains("-"))
        {

            int firstVerse = int.Parse(option.Substring(0, option.IndexOf("-")));
            int lastVerse = int.Parse(option.Substring(option.IndexOf("-") + 1, option.Length - 2));

            if (lastVerse < firstVerse || lastVerse > lines.Length)
            {
                Console.WriteLine("invalid option");
                Start();
                return;
            }

            Console.WriteLine("getting scriptures from: " + firstVerse + " to " + lastVerse);
            for (int i = 0; i <= lastVerse - firstVerse; i++)
            {
                scriptures.Add(new Scripture(lines[(firstVerse - 1) + i]));

            }
        }
        else
        {
            if (int.Parse(option) > lines.Length)
            {
                Console.WriteLine("invalid option");
                Start();
                return;
            }
            else
            {
                Console.WriteLine("getting scripture: " + option);
                scriptures.Add(new Scripture(lines[int.Parse(option) - 1]));
            }
        }

        string userinput = "";
        Random r = new Random();
        bool done = false;
        do
        {




            foreach (Scripture s in scriptures)
            {


                s.Display();
                Console.WriteLine();

            }
            List<int> tried = new List<int>();
            int i;
            while (scriptures[i = r.Next(scriptures.Count)].Next() == false)
            {
                if (!tried.Contains(i))
                {
                    tried.Add(i);
                }
                if (tried.Count >= scriptures.Count)
                {
                    Console.WriteLine("good job! and goodbye!");
                    done = true;
                    break;

                }
            }
            if (done)
            {
                break;
            }
            Console.WriteLine("\nPress enter for next iteration or type q to quit!");
        } while ((userinput = Console.ReadLine()) != "q");
    }
}