using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep1 World!");
        string fName;
        string sName;


        Console.WriteLine("What is your first name?: ");
        fName = Console.ReadLine();
    
        Console.WriteLine("What is your last name?: ");
        sName = Console.ReadLine();

        Console.WriteLine("Your name is " + sName + ", " + fName + " " + sName);
    }
}