using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment as1 = new Assignment("John DOe", "Reading");
        Console.WriteLine(as1.GetSummary());

        MathAssignment as2 = new MathAssignment("Homer Simpson", "Counting", "7.3", "8-19");
        Console.WriteLine(as2.GetSummary());
        Console.WriteLine(as2.GetHomeworkList());

        WritingAssignment as3 = new WritingAssignment("Einstien", "American revolution", "Signing the declearion of independence");
        Console.WriteLine(as3.GetSummary());
        Console.WriteLine(as3.GetWritingInformation());
    }
}
