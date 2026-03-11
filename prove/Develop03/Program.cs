using System;

class Program
{



   
    static void Main(string[] args)
    {
        
        var total_lines = 6586;

        Random randomGenerator = new Random();
        int num = randomGenerator.Next(1, total_lines);

        int i = randomGenerator.Next(-5, 200);


        Scripture k = new Scripture(num, i);

        Console.WriteLine($"{k._verses[0]._data[0]} {k._verses[0]._data[1]} : {k._verses[0]._data[2]}: {k._verses[0]._data[3]}");
        
      




    }
}