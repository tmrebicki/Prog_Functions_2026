using System;
using System.Runtime.InteropServices.Marshalling;

class Program
{




    static void Main(string[] args)
    {
        Console.WriteLine("give me a number (sqr side)");
        var sqrs = int.Parse(Console.ReadLine());
        Square sqr = new Square(ConsoleColor.Blue, sqrs);


        Console.WriteLine("give me a number (rectangle width)");
        var recw = int.Parse(Console.ReadLine());
        Console.WriteLine("give me a number (rectangle height)");
        var rech = int.Parse(Console.ReadLine());
        Rectangle rec = new Rectangle(ConsoleColor.Red, recw, rech);

        Console.WriteLine("give me a number (circle radius)");
        var crlr = int.Parse(Console.ReadLine());
        Square crl = new Square(ConsoleColor.Yellow, crlr);


        List<Shape> list = new List<Shape>();
        list.Add(sqr);
        list.Add(rec);
        list.Add(crl);


        Console.WriteLine($"Blue: square, Red: recatangle, Yellow: circle ");
        foreach (Shape s in list)
        {
            Console.ForegroundColor = s.Get_color();
            Console.WriteLine($"{s.Get_area()}");

        }


    }
}