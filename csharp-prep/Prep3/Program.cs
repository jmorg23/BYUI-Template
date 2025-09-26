using System;
using System.Collections.Specialized;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");

        string[] strings = new string[]{
            "hi", "hello", "word", "car", "dog"
        };

        foreach (string s in strings)
        {
            Console.WriteLine(s);
        }
        for (int i = 0; i < strings.Length; i++)
        {
            Console.WriteLine(strings[i]);
        }
        int j = 0;
        while (j < strings.Length)
        {
            Console.WriteLine(strings[j]);
            j++;
        }
        j = 0;
        do

        {
            Console.WriteLine(strings[j]);
            j++;
        } while (j < strings.Length);

        int num = 0;
        int sum = 0;
        int count = 0;
        int bigest = int.MinValue;
        
        Console.Write("Enter numbers to sum, -1 to stop: ");
        while ((num = int.Parse(Console.ReadLine())) != -1)
        {
            Console.WriteLine("You entered: " + num);
            sum += num;
            count++;
            if (num > bigest)
            {
                bigest = num;
            }

        }

        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Count: " + count);
        Console.WriteLine("Average: " + (sum / count));
        Console.WriteLine("Biggest: " + bigest);


    }
}