using System;
using System.Data;
using System.Runtime.CompilerServices;

class Program
{

#region Functions
    static List<string> Prompt_question(List<string> x)
    {
        List<string> ans_qst = new List<string>();


        Random randomGenerator = new Random();
        int magik = randomGenerator.Next(0, x.Count);
        ans_qst.Add(x[magik]);
        Console.WriteLine(x[magik]);
        ans_qst.Add(Console.ReadLine());

        return ans_qst;



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
    static Day Run_day(List<string> x)
    {

        Day newday = new Day();
        List<string> i = new List<string>();

        DateTime now = DateTime.Now;
        string date = now.ToShortDateString();


        Console.WriteLine("Today: " + date);
        newday._date = date;

        // get questions and store attributes
        i= Prompt_question(x);
        newday._questionOfTheDay = i[0];
        newday._Answer = i[1];

        newday._screenTime = Prompt_screentime();
        newday._sleepHours = Prompt_sleepTime();
        newday._cal = Prompt_Cal();
        newday._rating = Prompt_rating();

        // convert all attributes to strings and store them in the "data" array
        newday.data.Add(newday._date);
        newday.data.Add(newday._questionOfTheDay);
        newday.data.Add(newday._Answer);
        newday.data.Add(newday._screenTime.ToString());
        newday.data.Add(newday._sleepHours.ToString());
        newday.data.Add(newday._cal.ToString());
        newday.data.Add(newday._rating.ToString());


        return newday;


    }

    static void Check_and_create_file(string filepath)
    {
        
       



    }




#endregion 

#region Object

    public class Day
    {

        public string _date;
        
        public string _questionOfTheDay,_Answer;

        public int _rating,_cal,_sleepHours,_screenTime;

        public List<string> data;



    }

    

#endregion

#region State machine

    static int Menu_state()
    {
        
        Console.WriteLine("Welcome to the journal program!");
        Console.WriteLine("Would you like to:");
        Console.WriteLine("(1) Create a new journal");
        Console.WriteLine("(2) Write in an exisitng journal");
        Console.WriteLine("(3) Read records");
        return int.Parse(Console.ReadLine());


    }

    static int writting_state(List<string> x)
    {
        
        Day i =  Run_day(x);

       
        

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




        while (state < 3)
        {
        

            if (state == 0) // menu
            {
                state = Menu_state();

            }else if (state == 1) // create journal

            {
                
                
            }else if (state == 2) // write journal
            {
             
             state = writting_state(_qtns);


            }else if (state ==3) // read records 
            {
                

            }
        }










        
    }





}