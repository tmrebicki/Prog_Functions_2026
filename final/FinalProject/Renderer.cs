using System.Diagnostics;

class Renderer
{
    private GameBoard _board;
    private Game _game;





    public Renderer(GameBoard board, Game game)
    {
        _board = board;
        _game = game;


    }


    public void Draw_next()
    {
        string[ ][ ] _blockMap = null;
        var block =_board.Get_sequence().First();
        var shape = block._shape;
          switch (shape)
        {
            case "O":
                _blockMap = [["[ ]","[ ]","   ","   "],
                             ["[ ]","[ ]","   ","   "],
                             ["   ","   ","   ","   "],
                             ["   ","   ","   ","   "]];
                break;

            case "T":
                _blockMap = [["[ ]","[ ]","[ ]","   "],
                             ["   ","[ ]","   ","   "],
                             ["   ","   ","   ","   "],
                             ["   ","   ","   ","   "]];
                break;

            case "Z":
                _blockMap = [["[ ]","[ ]","   ","   "],
                             ["   ","[ ]","[ ]","   "],
                             ["   ","   ","   ","   "],
                             ["   ","   ","   ","   "]];
                break;

            case "I":
                _blockMap = [["[ ]","   ","   ","   "],
                             ["[ ]","   ","   ","   "],
                             ["[ ]","   ","   ","   "],
                             ["[ ]","   ","   ","   "]];
                break;

            case "S":
                _blockMap = [["   ","[ ]","[ ]","   "],
                             ["[ ]","[ ]","   ","   "],
                             ["   ","   ","   ","   "],
                             ["   ","   ","   ","   "]];
                break;

            case "L":
                _blockMap = [["[ ]","[ ]","[ ]","   "],
                             ["   ","   ","[ ]","   "],
                             ["   ","   ","   ","   "],
                             ["   ","   ","   ","   "]];
                break;

            case "J":
                _blockMap = [["[ ]","[ ]","[ ]","   "],
                             ["[ ]","   ","   ","   "],
                             ["   ","   ","   ","   "],
                             ["   ","   ","   ","   "]];
                break;
        }


        Console.WriteLine();
        Console.ForegroundColor = block.Get_color();
        foreach (Array q in _blockMap)
        {
            foreach (string l in q)
            {
                Console.Write(l);

            }
            Console.WriteLine();


        }
        Console.ResetColor();



    }



    public void Draw_All()
    {
        Console.SetCursorPosition(0, 0);



        
        Draw_next();
        _board.Draw_Board();

    }








}
