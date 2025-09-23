public abstract class Program3
{
    public abstract void hey();
    public Program3(int instanceNum)
    {
        Console.WriteLine("instance: " + instanceNum++ + " created");
    }
    public void w()
    {
        
    }
}