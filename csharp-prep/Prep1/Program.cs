using System;
using System.ComponentModel;

public class Program : Program3, Program2 
{

    public static void Main(string[] args)
    {

        Console.Write("enter first name: ");
        string fn = Console.ReadLine();

        Console.Write("enter last name: ");
        string ln = Console.ReadLine();

        Console.WriteLine("your name is "+ln+", "+fn+" "+ln);


        try
        {

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

    }
    public void hello()
    {
        Console.Write("hello");

        
    }
   


    public override void hey()
    {

    }

    public static int h = 0;

    public Program(int instanceNum) : base(instanceNum)
    {
        base.w();
    }
}
