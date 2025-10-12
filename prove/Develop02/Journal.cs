

using System.Diagnostics.Contracts;

class Journal
{

    public string _name;
    public string _date;
    public List<Entry> _entrys;

    public Journal(string name)
    {
        _date = "";
        _entrys = new List<Entry>();
        _name = name;
    }

    public void AddEntry(Entry entry)
    {
        _entrys.Add(entry);
    }   
    public void Open()
    {
        Console.WriteLine($"Date: {_date}");

        int choice = 0;
        while ((choice = PromptUser()) != 6)
        {
            if (choice == 1)
            {
                Console.WriteLine("Write your entry: ");
                _entrys.Add(new Entry(_entrys.Count));
                _entrys[_entrys.Count - 1]._contents = Console.ReadLine();
            }
            else if (choice == 2)
            {
                if (_entrys.Count == 0)
                {
                    Console.WriteLine("No entries to display.");
                    continue;
                }
                else if (_entrys.Count > 2)
                {
                    Console.WriteLine("Which entry do you want displayed: ");
                    int i = 0;
                    foreach (Entry entry in _entrys)
                    {
                        Console.Write($"Entry {i} : ");
                        Console.WriteLine($"{entry._name} at {entry._date}");
                        i++;
                    }

                    int entryChoice = int.Parse(Console.ReadLine());
                    if (entryChoice < 0 || entryChoice >= _entrys.Count)
                    {
                        Console.WriteLine("Invalid entry choice.");
                        continue;
                    }else
                    {
                        Console.WriteLine($"Date: {_entrys[entryChoice]._date}");
                        Console.WriteLine(_entrys[entryChoice]._contents);
                    }

                }
                else
                    foreach (Entry entry in _entrys)
                    {
                        Console.WriteLine($"Date: {entry._date}");
                        Console.WriteLine(entry._contents);
                    }
            }
            else if (choice == 3)
            {

                Console.WriteLine("Saving journal...");
                Driver.SaveJournalToFile(this);
                Console.WriteLine("Journal saved.");
            }
            else if (choice == 4)
            {

                Console.WriteLine("Enter new journal name:");
                _name = Console.ReadLine();
                Console.WriteLine($"Journal name updated to: {_name}");
            }
            else if (choice == 5)
            {
                Console.WriteLine("Exiting journal...");
                Driver.AskWhichJournalToLoad();

                break;
            }
            else if (choice != 6)
            {
                Console.WriteLine("Invalid choice! Please try again.");
            }
        }

        if (choice == 5)
        {
            Console.WriteLine("Exiting journal...");
            Driver.AskWhichJournalToLoad();
        }
    }

    public int PromptUser() {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("     1. Write");
        Console.WriteLine("     2. Display");
        Console.WriteLine("     3. Save");
        Console.WriteLine("     4. Edit Journal Name");
        Console.WriteLine("     5. Load Other Journal");
        Console.WriteLine("     6. Exit");

        int choice = int.Parse(Console.ReadLine());
        return choice;
    }


}