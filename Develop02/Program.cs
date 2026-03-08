using System;
using System.Data;
using System.Runtime.CompilerServices;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow;

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
        
        Console.WriteLine("What was your screentime today in hours?");
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
    static Entry Run_day(List<string> x)
    {

        Entry newday = new Entry();
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



        return newday;


    }
    static List<string> structure_data(Entry i)
    {
        // takes Entry and writes all the atributes in an array
        List<string> data = new List<string>();

        data.Add(i._date);
        data.Add(i._questionOfTheDay);
        data.Add(i._Answer);
        data.Add(i._screenTime.ToString());
        data.Add(i._sleepHours.ToString());
        data.Add(i._cal.ToString());
        data.Add(i._rating.ToString());

        return data;



    }
    static void Create_formated_file(string filepath, Journal journal) 
    {
        

        // check if file exists
        if (!File.Exists(filepath))
        {
            // if it doesnt it will ask where to create new journal
            Console.WriteLine("Journal creating at:" + filepath);
            Console.WriteLine("Would you like to change the Journal's path? (y/n)");

            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("Type desired path");
                // user defined new path to create journal
                filepath = $"{Console.ReadLine()}/{journal._name}.csv";

            }

            //write down Journal's headers
            Write_data(filepath,journal._headers);


            Console.WriteLine("Journal created at: " + filepath);
        }
        else
        {
            Console.WriteLine("Journal Already exists.");
            

        }

    }
    static void Check_and_create_file(string path, string filepath)
    {
        List<string> headers;
        // create journal instance

        headers = ["Date","Question","Answer","Screen Time","Sleep hours","Calories","Rating"];
        // define the headers for the excel sheet

        var p = new Journal() {_filepath = filepath, _name = path , _headers = headers};
        //  Define all the atributes of the journal instance


        Create_formated_file($"{p._filepath}/{p._name}.csv", p);
        

    }
    static string List_journals(string path)
    {
        
        var check = "bruh";

        Console.WriteLine("In which journal would you like to write?");
        Console.WriteLine("Journals in " + path);
        var l = 0;

        string[] journals = Directory.GetFiles(path, "*.csv", SearchOption.TopDirectoryOnly);        
        
        
        if (journals.Length > 0) //list journals found
        {
            Console.WriteLine(journals.Length + " found.");
            foreach (var file in journals)
            {
                Console.WriteLine( "(" + l + ")   " + Path.GetFileName(file));

                l +=1;
            }            Console.WriteLine("Which one would you like to read?");


            check = journals[int.Parse(Console.ReadLine())];


        }
        else // no journals found
        {
            Console.WriteLine("No journals files found in the directory.");
            Console.WriteLine("Would you like to create a journal? (y/n)" );            
            var p = Console.ReadLine();
                if (p == "y")
            {
                check = "create";        }
            else
            {
                check = "again";
        
            }        
        }        
        
        if (File.Exists(check))
        {
        
            return check;        
        
        }else if (check == "create")
        {
        
            return "1";       
        }
        else
        {
            return "0" ;
            
        }

    }
    static void Write_data(string filepath, List<string> content)
    {
        
        using (StreamWriter outputFile = new StreamWriter(filepath, true))
        {
               foreach(string k2 in content)
            {
                
                outputFile.Write($"{k2},");

            } outputFile.WriteLine();
        }

    }
    static string prompt_for_filepath(string path)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("What path would you like to look for journals?");
        Console.WriteLine("Type 1 for Default: " + path);
        var k = Console.ReadLine();
        Console.ResetColor();

        if (k != "1")
        {
            path = k;
        }

        return path;

    }

#endregion 

#region State machine

    static int Menu_state()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Welcome to the journal program!");
        Console.WriteLine("Would you like to:");
        Console.WriteLine("(1) Create a new journal");
        Console.WriteLine("(2) Write in an existing journal");
        Console.WriteLine("(3) Read records");
        Console.ResetColor();
        return int.Parse(Console.ReadLine());
        // take user to states

    }

    static int reading_state(string path)
    {
        
        using (StreamReader reader = new StreamReader(path))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        return 0;
    }

    static int writing_state(List<string> x, string path)
    {
        
        Entry i = new Entry(); // create instance of entry
        string write_on;
        path = prompt_for_filepath(path); //find repository to look for journals
        write_on = List_journals(path); //find which journal to write on


        // in case there is no file in repository it will direct user to create journal state
        if (write_on == "0" || write_on == "1"){ 
            

            return int.Parse(write_on);

        } 
        

        i =  Run_day(x); //run through all the prompts and store answers in a entry
        Write_data(write_on,structure_data(i)); // write in file (write_on) and structure data of an entry into an array

        Console.Out.Flush(); //ensures that everything is written, closes write so it can be read.

        return 0;


    }

    static int Create_Journal(string path)
    {
        Console.WriteLine("Name your new Journal:");

        var i = Console.ReadLine();

        Check_and_create_file(i,path);

        return 0;


    }

#endregion

    static void Main(string[] args)
    {

        List<string> _qtns = new List<string>();

        _qtns.Add("Q1: Where have you seen God today?");
        _qtns.Add("Q2: What was your favorite part of today?");
        _qtns.Add("Q3: Where did you see your favorite color today?");
        _qtns.Add("Q4: What's something you don't want to forget about today?");
        _qtns.Add("Q5: What made you smile today?");

        int state = 0;

        var path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);



        while (state <= 3)
        {
        

            if (state == 0) // menu
            {
                state = Menu_state();

            }else if (state == 1) // create journal
            {
                
                state = Create_Journal(path);
                
            }else if (state == 2) // write journal
            {
             
                state = writing_state(_qtns,path);


            }else if (state ==3) // read records 
            {
                string JournalManager = List_journals(path);
                if (JournalManager != "0" && JournalManager != "1")
                {
                    state = reading_state(JournalManager);
                }
                else
                {
                    Console.WriteLine("No selected journal");
                }

            }

        }

    }

}

// using System;
// using System.Data;
// using System.Runtime.CompilerServices;

// //nouns: jounal, entry, date, file, menu, prompts, response (journal/entry- classes) prompts- attribute on entry, date- atribute on journal
// //journal: file path, menu
// //entry: prompts, response, date
// class Program2
// {

//     public void WriteToFile(string journal_file)
//     //journal.writetofile
//     {
//         using (StreamWriter outputFile = new StreamWriter(journal_file))
//         {
//             foreach(JournalEntry entry in entries)
//             {
//                 outputFile.WriteLine(entry.CreateFileSystemString());
//             }
//         }
//     }
    
//     public void ReadFromFile(string journal_file)
//     {
//         string[] lines = System.IO.File.ReadAllLines(journal_file);

//         foreach (string line in lines)
//         {
//             string [] parts = line.Split("#");

//             string date = parts[0];
//             string question = parts[1];
//             string entryText = parts[2];

//             JournalEntry entry = new JournalEntry();
//             entry.CreateEntryWithData(date)
//         }
//     }
//     public string CreateFileSystemString()
//     {
//         string outputString = "";
//         outputString = $"{_date}#{_entryQuestion}#{_journalEntry}";
//         return outputString;
//     }
//     //how started
//     public static void Main(string[] args)
//     {
//         Menu menu = new Menu();
//         bool done = false;
//         int userResponse;
//         do
//         {
//             userResponse = menu.ProcessMenu();
//             switch(userResponse)
//             {
//                 case 1:
//                 //creates and adds entry to list of journal entries
//                 break;
//                 case 2:
//                 //displays jounral entries
//                 break;
//                 case 3:
//                 //save journal to file
//                 break;
//                 case 4:
//                 //load journal from file
//                 break;
//                 case 5:
//                     done = true;
//                     break;

//             }
//             if (userResponse == 5)
//             {
//                 done = true;
//             }
//         } while(!done);
       
//     }
// }
