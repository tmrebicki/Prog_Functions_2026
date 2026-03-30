using System;

class Program
{
    public static void Print_intro()
    {
        

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Welcome to Tetris!");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("Please open the terminal on fullscreen before starting game!!!");
        Console.WriteLine();
        Console.WriteLine("(1) play");
        Console.WriteLine("(2) exit");


    }

    static void Main(string[] args)
    {
        var state = 0;

         while (state < 3){

            switch (state)
            {
            case 0:             
                Print_intro();
                state = int.Parse(Console.ReadLine());


            break;

            case 1:

                Console.Clear();

                Console.CursorVisible = false;

                Game game = new Game(10, 25);
                game.Run();
                state = 0;
            break;
            case 2:
                Console.WriteLine("Goodbye.");
                state = 4;
            break;
            }
         }

        



    }
}