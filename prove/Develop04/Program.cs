using System;
using System.Data;

class Program
{

#region prompt question functions
    static string Prompt_question(List<string> x)
    {
        Random randomGenerator = new Random();
        int magik = randomGenerator.Next(0, x.Count);

        Console.WriteLine(x[magik]);
        return Console.ReadLine();

    }
    static int Prompt_rating()
    {
        
        Console.WriteLine("Rate your day (from 1 to 10)");
        return int.Parse(Console.ReadLine());

    }
    static int Prompt_screentime()
    {
        
        Console.WriteLine("What was your screentime today?");
        return int.Parse(Console.ReadLine());

    }
    static int Prompt_Cal()
    {
        
        Console.WriteLine("How many calories did you eat today?");
        return int.Parse(Console.ReadLine());

    }
    static int Prompt_sleepTime()
    {
        
        Console.WriteLine("How many hours did you sleep yesterday?");
        return int.Parse(Console.ReadLine());

    }
#endregion 

#region state machine

    static int Menu_state()
    {
        
        Console.WriteLine("Welcome to the journal program!");
        Console.WriteLine("Would you like to (1) write today's journal or (2) read past records?");
        return int.Parse(Console.ReadLine());


    }

    static int writting_state()
    {
        
        Prompt_question(_qtns[]);
        Prompt_screentime();
        Prompt_sleepTime();
        Prompt_Cal();
        return 0;


    }










#endregion


    static void Main(string[] args)
    {

        List<string> _qtns = new List<string>();

        _qtns.Add("Q1");
        _qtns.Add("Q2");
        _qtns.Add("Q3");
        _qtns.Add("Q4");
        _qtns.Add("Q5");

        int state = 0;

        if (state == 0) // menu
        {
            

        }else if (state == 1) // write entry
        {
            


        }else if (state == 2) // records
        {
            


        }











        
    }
}