using System;

class Program
{   


    static void Displaywelcome()
    {
        
        Console.WriteLine("Welcome to the Program!");

    }
    static string Promptusername()
    {
        
        Console.WriteLine("What is your name?: ");
        string i = Console.ReadLine();
        return i;
    
    }
    static int Promptnumber()
    {
        Console.WriteLine("What is your favorite number");
        string i = Console.ReadLine();
        int x = int.Parse(i);
        return x;
    }
    static int Sqrnumber(int l, string name)
    {
        int f = + l^2;
        return f;

    }
    static int PromptBirthYear(string name)
    {
        Console.WriteLine(name + ", what is your year of birth?");

        string i = Console.ReadLine();
        int x = int.Parse(i);
        x -= 2026;
        return x*-1;

    }

    static void displayresults(string name, int num, int year )
    {

        Console.WriteLine(name + ",your number squared is: " + num);
        Console.WriteLine(name + ",you will turn: " + year);
    }

    static void Main(string[] args)
    {
        Displaywelcome();
        string name = Program.Promptusername();
        int num = Program.Promptnumber();
        int ye = Program.PromptBirthYear(name);
        int sqr = Program.Sqrnumber(num, name);
        displayresults(name, sqr, ye);

    }
}