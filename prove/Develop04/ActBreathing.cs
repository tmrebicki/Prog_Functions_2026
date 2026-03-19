using System;
using System.Runtime.InteropServices;

class ActBreathing : Activity
{
   
    private string _nameMessage = "Breathing activity";
    private string _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";

    private string _name;

    public ActBreathing(string name) : base(name , "Breathing activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing")
    {
        
        _name = name;





    }

    private void Breathe_Stats(string p)
    {
        Write_Stats(p);

    }




    private void Breathe_loop(int sec, int repeat)
    {
        var re = repeat;
        var loop = true;
        while (loop) 
        {         
                        
            var secs = sec;

            for (int i = secs; i > -1; i--)
            {

            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine($"Breathe in ...{i}");

            }

            for (int i = sec; i > -1; i--)
            {

            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine($"Breathe out ...{i}");

            }

            if (repeat == 0)
            {
                loop = false;

            }
            re -=1;
            secs = sec;

            }

        

    }


    public void run_Breathing()
    {
        Console.Clear();
    
        display_Start();

        display_Description();

        Console.WriteLine("How many times would you like to repeat?");

        var p = int.Parse(Console.ReadLine());

        Breathe_loop(5,p);

        display_End();

        Breathe_Stats("1");

        Get_Streak();


    }
















}