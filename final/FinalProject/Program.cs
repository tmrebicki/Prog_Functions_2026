using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();


        Console.CursorVisible = false;

        Game game = new Game(10, 25);
        game.Run();


    }
}