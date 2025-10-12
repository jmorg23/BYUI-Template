

using System.Dynamic;
using System.IO;

class Driver
{

    static List<Journal> journals = new List<Journal>();


    static void Main(String[] args)
    {

        GetJournalsFromFile();
        AskWhichJournalToLoad();


    }
    public static void AskWhichJournalToLoad()
    {

        Console.WriteLine("Which journal would you like to load?\nSelect an action:\n       0.New Journal");
        int i = 1;
        foreach (Journal journal in journals)
        {
            Console.WriteLine("       " + i++ + ".Load Journal : " + journal._name + " from " + journal._date);
            
        }


        int choice = int.Parse(Console.ReadLine());
        if (choice > 0 && choice > journals.Count)
        {
            Console.WriteLine("Invalid choice. try again.");
            AskWhichJournalToLoad();
            return;
        }
        else if (choice == 0)
        {
            Console.WriteLine("Enter journal name:");
            Journal newJournal = new Journal(Console.ReadLine());
            newJournal._date = DateTime.Now.ToString("MM/dd/yyyy");

            journals.Add(newJournal);
            newJournal.Open();
            return;
        }
        else
        {

            Journal selectedJournal = journals[choice - 1];
            Console.WriteLine($"You selected the journal from {selectedJournal._date}");

            selectedJournal.Open();
        }



    }

    static void GetJournalsFromFile()
    {

        if (!File.Exists("journals.txt"))
        {
            File.Create("journals.txt");
            return;
        }




        string[] lines = File.ReadAllLines("journals.txt");

        foreach (string line in lines)
        {
            Journal journal = new Journal(line);
            string[] journalParts = File.ReadAllLines(line);
            journal._date = journalParts[0];

            Entry[] entries = ExtractEntryParts(journalParts);
            
            foreach (Entry entry in entries)
            {
                journal.AddEntry(entry);
                Console.WriteLine(entry);
                Console.WriteLine("-----yes there was a new entry-----");
            }

            journals.Add(journal);

        }





    }
    static Entry[] ExtractEntryParts(string[] journalParts)
    {
        List<Entry> entryParts = new List<Entry>();
        int i = 1;
        int entries = 0;
        Entry entryCon = new Entry(entries);
        while (i < journalParts.Length)
        {
            Console.WriteLine(journalParts[i]);
            Console.WriteLine("-----checking for new entry-----");
            if (journalParts[i].Contains("<NEW ENTRY>"))
            {
                if (entryCon._contents != "")
                {
                    Console.WriteLine("-----new entry added-----");
                    entryParts.Add(entryCon);
                }


                entryCon = new Entry(++entries);
                i++;
                entryCon._date = journalParts[i];
                i++;


                continue;

            }


            entryCon._contents += journalParts[i];
            i++;
        }
        entryParts.Add(entryCon);
        return entryParts.ToArray();
    }
    public static void SaveJournalToFile(Journal journal)
    {
        string fileName = journal._name;
        using (StreamWriter writer = new StreamWriter(fileName, true))
        {
            writer.WriteLine(journal._date);
            foreach (Entry entry in journal._entrys)
            {
                writer.WriteLine("<NEW ENTRY>");
                writer.WriteLine(entry._date);
                writer.WriteLine(entry._contents);
            }

        }
    
        if (!DoesJournalExist(fileName))
            using (StreamWriter writer = new StreamWriter("journals.txt", true))
            {
                writer.WriteLine(fileName);
            }
    }
    public static bool DoesJournalExist(string file)
    {
        string[] files = File.ReadAllLines("journals.txt");
        foreach (string s in files)
        {
            if (s == file)
            {
                return true;
            }
        }
        return false;
    }
}