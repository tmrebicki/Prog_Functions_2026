using System;

class Program
{
    static void Main(string[] args)
    {
        
        Assigment a1 = new Assigment("Samuel Bennett", "Multiplication");
        Console.WriteLine(a1.GetSummary());


        MathAssigment a2 = new MathAssigment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.Get_Homework());

        WrittingAssigment a3 = new WrittingAssigment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.Get_Writting_Info());
    }
}