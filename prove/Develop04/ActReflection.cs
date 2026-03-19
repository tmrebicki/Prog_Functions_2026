using System;
using System.Runtime.InteropServices;


class ActReflection : Activity
{
   
    private string _nameMessage = "Reflection activity";
    
    private List<string> _questions = ["question1","question2"];
    
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
        Console.WriteLine($"Reflect the following question right now!");
        Console.WriteLine($"{_questions[magik]}");

        spiner_Animation(3);

        Console.WriteLine("Write down some reflections");

        Console.ReadLine();

    }





    public void run_Reflection()
    {
        display_Start();

        display_Description();

        Ask_Question();
 
        Write_Stats("1");

        Get_Streak();

        display_End();


    }









}