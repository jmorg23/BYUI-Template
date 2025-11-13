using System;

class Program
{
    static void Main(string[] args)
    {

        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("Red", 3);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Blue", 4, 5);
        shapes.Add(s2);

        Circle s3 = new Circle("Green", 6);
        shapes.Add(s3);

        string color;
        double area;
        foreach (Shape s in shapes)
        {
            color = s.GetColor();
            area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}