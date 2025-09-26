using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int num = 0;
        int sum = 0;
        int bigest = int.MinValue;
        
        Console.Write("Enter numbers to sum, -1 to stop: ");
        while ((num = int.Parse(Console.ReadLine())) != -1)
        {
            numbers.Add(num);
            Console.WriteLine("You entered: " + num);
            sum += num;
            if (num > bigest)
            {
                bigest = num;
            }

        }
        numbers.Sort();
        Console.WriteLine("Numbers in sorted order:");
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }

        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Count: " + numbers.Count);
        Console.WriteLine("Average: " + (sum / numbers.Count));
        Console.WriteLine("Biggest: " + bigest);
    }
}