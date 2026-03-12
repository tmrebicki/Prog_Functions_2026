using System;
using System.Runtime.InteropServices;

class Program
{

    public static void Print_intro()
    {
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Welcome to Scripture Memo program!");
        Console.ResetColor();

        Console.WriteLine("(1) Play memo game");
        Console.WriteLine("(2) Hide words");
        Console.WriteLine("(3) Exit");

    }

    public static void Guess_words()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
    

        var total_lines = 6586;

        Random randomGenerator = new Random();
        int num = randomGenerator.Next(1, total_lines);
        Scripture k = new Scripture(num, 2);

        for (int f = 0; f < 500; f++)
        {
            Scripture.Hide_Refs(k);
        }


        var loop = true;
        while (loop) {
            Console.WriteLine("Guess the words words");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Type a word. Press 1 to exit");
            Console.ResetColor();
            Scripture.Print_all(k);

            string q = Console.ReadLine();
            if (q == "1")
            {
                
                loop = false;

            }
            Scripture.unhide(q,k);
  
            Console.Clear();




        }






    }
    public static void hide_words_loop()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Hide words");
        


        var total_lines = 6586;

        Random randomGenerator = new Random();
        int num = randomGenerator.Next(1, total_lines);
        Scripture k = new Scripture(num, 8);


        var loop = true;
        while (loop) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press enter to hide 1 random word in each verse. Press any to exit");
            Console.ResetColor();
            Scripture.Print_all(k);
       
            var ans = Console.ReadKey();
            Console.Clear();

            if (ans.Key == ConsoleKey.Enter)
            {
                
                Scripture.Hide_Refs(k);

            }
            else
            {
                loop = false;

            }


        }
        

    }


   
    static void Main(string[] args)
    {
  



        var state = 0;

        while (state != 3){

            switch (state)
            {
            case 0:

                
                Print_intro();
                state = int.Parse(Console.ReadLine());
               


            break;

            case 1:

                Guess_words();
                state = 0;

            break;

            case 2:

                hide_words_loop();
                state = 0;

            break;










            }
        }
    }
}