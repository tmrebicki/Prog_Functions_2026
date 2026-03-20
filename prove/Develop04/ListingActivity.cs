
using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(string name) : base(name,"Listing Activity" ,"This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    public void RunActivity()
    {
        Console.WriteLine();
        Greeting();
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);

        Console.WriteLine("\nStart listing");
        StartTimer();
        while (!HasTimerExpired())
        {
            Console.Write("> ");
            Console.ReadLine();
        }
        Write_Stats("1");
        display_End();


    }

}
