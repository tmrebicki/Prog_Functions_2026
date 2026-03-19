using System;
using System.Runtime.InteropServices;


class ActReflection : Activity
{
   
    private string _nameMessage = "Reflection activity";
    
    private List<string> _questions = ["Think of a time when you stood up for someone else.",
    "Think of a time when you did something really difficult.",
    "Think of a time when you helped someone in need.",
    "Think of a time when you did something truly selfless."];

    private List<string> _followUps = ["Why was this experience meaningful to you?",
                                    "Have you ever done anything like this before?",
                                    "How did you get started?",
                                    "How did you feel when it was complete?",
                                    "What made this time different than other times when you were not as successful?",
                                    "What is your favorite thing about this experience?",
                                    "What could you learn from this experience that applies to other situations?",
                                    "What did you learn about yourself through this experience?",
                                    "How can you keep this experience in mind in the future?"];
    
    private string _name;

    public ActReflection(string name) : base(name , "Reflection activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life")
    {

        _name = name;


    }

    private void Ask_Question()
    {
        

        Random randomGenerator = new Random();
        int magik = randomGenerator.Next(0, _questions.Count);
        Console.Clear();
        Console.WriteLine($"Reflect on the following right now!");
        Console.WriteLine($"{_questions[magik]}");

        spiner_Animation(3);
        Random randomGen = new Random();
        int maa = randomGenerator.Next(0, _followUps.Count);
        Console.WriteLine($"{_followUps[maa]}");

        Console.ReadLine();

    }





    public void run_Reflection()
    {
        display_Start();

        display_Description();
        Get_Streak();
        Thread.Sleep(1000);
        Ask_Question();
 
        Write_Stats("1");


        display_End();


    }









}