using System;
using System.Formats.Asn1;
using System.Runtime.InteropServices;

class Program
{


    public static void Breathing_State(string name)
    {
        ActBreathing a1 = new ActBreathing(name);
        a1.run_Breathing();
    }
    public static void Reflection_State(string name)
    {
        ActReflection a1 = new ActReflection(name);
        a1.run_Reflection();
    }

    public static void Listing_State(string name)
    {
        
        //ActivityListing a1 = new ActivityListing(name);
        //a1.run_Listing();


    }




        public static void Print_intro()
    {
        

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Welcome to program!");
        Console.ResetColor();

        Console.WriteLine("(1) Start breathing exercise.");
        Console.WriteLine("(2) Start reflection exercise.");
        Console.WriteLine("(3) Start Listing exercise");
        Console.WriteLine("(4) Exit");

    }

   
    static void Main(string[] args)
    {
        string name = "name";
        Console.WriteLine("What is your name?");
        name = Console.ReadLine();

        var state = 0;

        while (state != 3){

            switch (state)
            {
            case 0:             
                Print_intro();
                state = int.Parse(Console.ReadLine());


            break;

            case 1:

                Breathing_State(name);
                state = 0;
            break;

            case 2:

                Reflection_State(name);
                state = 0;

            break;

            case 3:
                Listing_State(name);
                state =0;
            break;

            case 4:
            Console.Clear();
            Console.WriteLine("Hello world");
            Thread.Sleep(600);
            Console.Clear();
            Console.WriteLine("I mean");
            Thread.Sleep(400);
            Console.Clear();
            Console.WriteLine("Goodbye world");
            state = 256789;
            break;









            }
        }
    }
}