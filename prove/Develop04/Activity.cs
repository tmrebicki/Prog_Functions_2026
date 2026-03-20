using System;
using System.Runtime.InteropServices;
using System.Linq;
using System.Globalization;

class Activity
{
    private string _name, _date;
    private int _duration;
    private DateTime _endTime; 
    private string _nameMessage, _description;


    public Activity(string name, string nameMessage, string description)
    {
        
        _name = name;
        _nameMessage = nameMessage;
        _description = description;
        _duration = 0;

        DateTime now = DateTime.Now;
        string date = now.ToShortDateString();

        _date = date;


        if (!File.Exists(_name + ".csv"))
        {
            Console.WriteLine("Creating file for:" + _name);

            using (StreamWriter outputFile = new StreamWriter(_name +".csv", true))
                {
            
                    outputFile.Write($"{_date}, Breathing activity, Reflection activity, Listing activity, Streak");

                    
                    outputFile.WriteLine();
                }
          
        }








    }

    protected void display_Start()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Welcome to {_nameMessage}");
        Console.ResetColor();

    }
    protected void display_End()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{_nameMessage} finished.");
        Console.ResetColor();

    }

    protected void display_Description()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(_description);
        Console.ResetColor();

    }

    protected void Write_Stats(string data)
    {





        using (StreamWriter outputFile = new StreamWriter(_name + ".csv", true))
        {
            


        if (_nameMessage == "Breathing activity")
        {   
            outputFile.Write($"{_date},{data},0,0,");

        }else if (_nameMessage == "Reflection activity")
        {
            
            outputFile.Write($"{_date},0,{data},0,");

        }else if (_nameMessage == "Listing activity")
        {
            
            outputFile.Write($"{_date},0,0,{data},");

        }
            outputFile.WriteLine();


        }




    }

    protected void Get_Streak()
    {
        List<int> streak = [0,0,0];
        var select =0;
        int currentStreak = 0;
        int maxStreak = 0;

        if (_nameMessage == "Breathing activity")
        {   
            select = 1;

        }else if (_nameMessage == "Reflection activity")
        {
            
            select =2;

        }else if (_nameMessage == "Listing activity")
        {
            
            select=3;

        }



        using (var reader = new StreamReader(_name + ".csv"))
        {
                        
            var lines = File.ReadAllLines(_name + ".csv");


            DateTime? previousDate = null;
            foreach (var line in lines.Skip(1)) 
        {
            var parts = line.Split(',');
            
            DateTime date = DateTime.Parse(parts[0], new CultureInfo("en-US"));

            bool isActive = parts.Skip(1).Any(x => x == "1");

            if (isActive)
            {
                // Check if consecutive day
                if (previousDate != null && date == previousDate.Value.AddDays(1))
                {
                    currentStreak++;
                }
                else
                {
                    currentStreak = 1;
                }

                if (currentStreak > maxStreak)
                    maxStreak = currentStreak;
                }
                else
                {
                    currentStreak = 0;
                }

            previousDate = date;
        }

            
        }


        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Current daily streak: {maxStreak}");
        Console.ResetColor();
    }




    protected void spiner_Animation(int loop)
    {
        Console.CursorVisible = false;
        for (int i = loop; i > 0; i--){
        int time = 400;

            for (int k = 0; k < 5; k++)
            {

                Console.Write("|");
                Thread.Sleep(time/4);
                Console.Write("\b \b"); 

                Console.Write("/"); 
                Thread.Sleep(time/4);
                Console.Write("\b \b"); 

                Console.Write("-"); 
                Thread.Sleep(time/4);
                Console.Write("\b \b"); 

                Console.Write("\\"); 
                Thread.Sleep(time/4);
                Console.Write("\b \b"); 
            }
        }
        
        Console.Clear();
        Console.CursorVisible = true;
    }

    public void Timer(int time_in_seconds)
    {
        var secs = time_in_seconds * 1000;
        Console.WriteLine();
        for (int i = secs; i > -1; i--){

        Thread.Sleep(1000);

                Console.Write("\\"); 
                Thread.Sleep(i);
                Console.Write("\b \b");
        }




    }


    public void Greeting()
    {
        Console.WriteLine($"Welcome to the {_name} activity.");
        Console.Write("How long do you want your session to go for?");
        _duration = int.Parse(Console.ReadLine());
    }

    public void Description()
    {
        Console.WriteLine(_description);
    }

    public void StartTimer()
    {
        _endTime = DateTime.Now.AddSeconds(_duration);
    }

    public bool HasTimerExpired()
    {
        return DateTime.Now > _endTime;
    }
    
    public void DisplaySpinner(string message, int seconds)
    {
        DateTime currentTime = DateTime.Now;
        DateTime endTime = currentTime.AddSeconds(seconds);
        int sleepTime = 100;
        string animationString = "-\\|/-";
        int index = 0;

        Console.CursorVisible = false;
        //Console.Clear();      

        Console.Write($"{message} ");

        while(DateTime.Now < endTime)
        {
            Console.Write(animationString[index++ % animationString.Length]);
            Thread.Sleep(sleepTime);
            Console.Write("\b");
        }

        Console.CursorVisible = true;
    }
}