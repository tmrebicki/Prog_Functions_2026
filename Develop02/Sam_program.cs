// using System;
// using System.Data;
// using System.Runtime.CompilerServices;
// using System.IO;
// using System.Diagnostics;
// using System.Threading.Tasks.Dataflow;

// class Program2
// {

// #region Functions
//     static List<string> Prompt_question(List<string> x)
//     {
//         List<string> ans_qst = new List<string>();


//         Random randomGenerator = new Random();
//         int magik = randomGenerator.Next(0, x.Count);
//         ans_qst.Add(x[magik]);
//         Console.WriteLine(x[magik]);
//         ans_qst.Add(Console.ReadLine());

//         return ans_qst;



//     }
//     static int Prompt_rating()
//     {
        
//         Console.WriteLine("Rate your day (from 1 to 10)");
//         return int.Parse(Console.ReadLine());

//     }
//     static int Prompt_screentime()
//     {
        
//         Console.WriteLine("What was your screentime today?");
//         return int.Parse(Console.ReadLine());

//     }
//     static int Prompt_Cal()
//     {
        
//         Console.WriteLine("How many calories did you eat today?");
//         return int.Parse(Console.ReadLine());

//     }
//     static int Prompt_sleepTime()
//     {
        
//         Console.WriteLine("How many hours did you sleep yesterday?");
//         return int.Parse(Console.ReadLine());

//     }
//     static Entry Run_day(List<string> x)
//     {

//         Entry newday = new Entry();
//         List<string> i = new List<string>();

//         DateTime now = DateTime.Now;
//         string date = now.ToShortDateString();


//         Console.WriteLine("Today: " + date);
//         newday._date = date;

//         // get questions and store attributes
//         i= Prompt_question(x);
//         newday._questionOfTheDay = i[0];
//         newday._Answer = i[1];

//         newday._screenTime = Prompt_screentime();
//         newday._sleepHours = Prompt_sleepTime();
//         newday._cal = Prompt_Cal();
//         newday._rating = Prompt_rating();

//         // convert all attributes to strings and store them in the "data" array



//         return newday;


//     }
//     static void Check_and_create_file(string path, string filepath)
//     {
//         List<string> headers;
//         headers = ["Date","Question","Answer","Screen Time","Sleep hours","Calories","Rating"];


//         var p = new Journal() {_filepath = filepath, _name = path , _headers = headers};


//         if (!File.Exists(p._filepath + p._name + ".csv"))
//         {
            
//             Console.WriteLine("Journal creating at:" + p._filepath);
//             Console.WriteLine("Would you like to change the Journal's path? (y/n)");

//             if (Console.ReadLine() == "y")
//             {
//                 Console.WriteLine("Type desired path");

//                 p._filepath = Console.ReadLine();

//             }

//                 using (StreamWriter outputFile = new StreamWriter(p._filepath + "/" + p._name + ".csv"))
//             {
//                foreach(string k2 in p._headers)
//             {
                
//                 outputFile.Write($"{k2},");

//             }
//                 outputFile.WriteLine();
//             }


//             Console.WriteLine("Journal created at: " + p._filepath + "/" + p._name + ".csv");
//         }
//         else
//         {
//             Console.WriteLine("Journal Already exists.");
            

//         }

//     }
//     static string List_journals(string path)
//     {
        
//         var check = "bruh";

//         Console.WriteLine("In which journal would you like to write?");
//         Console.WriteLine("Journals in " + path);
//         var l = 0;

//         string[] journals = Directory.GetFiles(path, "*.csv", SearchOption.TopDirectoryOnly);        
        
        
//         if (journals.Length > 0) //list journals found
//         {
//             Console.WriteLine(journals.Length + " found.");
//             foreach (var file in journals)
//             {
//                 Console.WriteLine( "(" + l + ")   " + Path.GetFileName(file));

//                 l +=1;
//             }            Console.WriteLine("Which one would you like to write on?");


//             check = journals[int.Parse(Console.ReadLine())];


//         }
//         else // no journals found
//         {
//             Console.WriteLine("No journals files found in the directory.");
//             Console.WriteLine("Would you like to create a journal? (y/n)" );            
//             var p = Console.ReadLine();
//                 if (p == "y")
//             {
//                 check = "create";        }
//             else
//             {
//                 check = "again";
        
//             }        
//         }        
        
        
        
        
        
//         if (File.Exists(check))
//         {
        
//             return check;        
        
//         }else if (check == "create")
//         {
        
//             return "1";       
//         }
//         else
//         {
//             return "0" ;
            
//         }

//     }


// #endregion 

// #region Object

//     public class Entry
//     {

//         public string _date;
        
//         public string _questionOfTheDay,_Answer;

//         public int _rating,_cal,_sleepHours,_screenTime;



//     }

//     public class Journal
//     {
//         public string _filepath;

//         public string _name;
        
//         public List<string> _headers;





//     }

    

// #endregion

// #region State machine

//     static int Menu_state()
//     {
//         Console.ForegroundColor = ConsoleColor.Green;
//         Console.WriteLine("Welcome to the journal program!");
//         Console.WriteLine("Would you like to:");
//         Console.WriteLine("(1) Create a new journal");
//         Console.WriteLine("(2) Write in an exisitng journal");
//         Console.WriteLine("(3) Read records");
//         Console.ResetColor();
//         return int.Parse(Console.ReadLine());


//     }

//     static int writting_state(List<string> x, string path)
//     {

//         string write_on;
//         Console.ForegroundColor = ConsoleColor.Yellow;
//         Console.WriteLine("What path would you like to look for journals?");
//         Console.WriteLine("Type 1 for Default: " + path);
//         var k = Console.ReadLine();


//         if (k != "1")
//         {
//             path = k;
//         }


//         write_on = List_journals(path); //retuns path of journal

//         if (write_on == "0" || write_on == "1"){
            

//             return int.Parse(write_on);

//         }


//         Entry i = new Entry();

//         i =  Run_day(x);
//         List<string> data = new List<string>();

//         data.Add(i._date);
//         data.Add(i._questionOfTheDay);
//         data.Add(i._Answer);
//         data.Add(i._screenTime.ToString());
//         data.Add(i._sleepHours.ToString());
//         data.Add(i._cal.ToString());
//         data.Add(i._rating.ToString());



//         using (StreamWriter outputFile = new StreamWriter(write_on, true))
//             {
                
//                foreach(string k2 in data)
//             {
                
//                 outputFile.Write($"{k2},");

//             } outputFile.WriteLine();
//             }



        


//         Console.ResetColor();
//         return 0;


//     }

//     static int Create_Journal(string path)
//     {
//         Console.WriteLine("Name your new Journal:");
//         var i = Console.ReadLine();

//         Check_and_create_file(i,path);

//         return 0;


//     }








// #endregion

//     static void Main(string[] args)
//     {

//         List<string> _qtns = new List<string>();

//         _qtns.Add("Q1");
//         _qtns.Add("Q2");
//         _qtns.Add("Q3");
//         _qtns.Add("Q4");
//         _qtns.Add("Q5");

//         int state = 0;

//         var path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);



//         while (state < 3)
//         {
        


//             if (state == 0) // menu
//             {
//                 state = Menu_state();

//             }else if (state == 1) // create journal
//             {
                
//                 state = Create_Journal(path);
                
//             }else if (state == 2) // write journal
//             {
             
//                 state = writting_state(_qtns,path);


//             }else if (state ==3) // read records 
//             {
                

//             }
//         }










        
//     }





// }