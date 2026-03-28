using System.Diagnostics;

class Game
{
    private GameBoard _board;
    private DateTime _lockStart;
    private bool _isLocking = false;
    private int _lockDelay = 100;
    private Renderer _render;

    private double _points = 0;



    private bool running = true;
    private int _h,_w;
    private Block _currentBlock;
    private DateTime _lastFall;

    private double speed = 1000;

    public Game(int width, int height)
    {
        _board = new GameBoard(width, height);
        _render = new Renderer(_board,this);
        _currentBlock = _board.create_block(0 , 0);
        _lastFall = DateTime.Now;
        _h = height;
        _w = width;
    }

    public void Run()
    {
        while (running)
        {
            Handle_speed();
            HandleInput();
            HandleGravity();
            UpdateGameState();
            _render.Draw_All();
            Console.WriteLine("Score:" + Math.Ceiling(_points) );
        }

        Console.Clear();
        Console.WriteLine("Game Over");
        Console.WriteLine("Score:" + Math.Ceiling(_points) );

    }

    private void HandleInput()
{
    if (!Console.KeyAvailable) return;

    var keyInfo = Console.ReadKey(true);

    switch (keyInfo.Key)
    {
        case ConsoleKey.DownArrow:
            _board.Move_Block(0, 1, _currentBlock);
            break;

        case ConsoleKey.LeftArrow:
            _board.Move_Block(-1, 0, _currentBlock);
            break;

        case ConsoleKey.RightArrow:
            _board.Move_Block(1, 0, _currentBlock);
            break;

        case ConsoleKey.UpArrow:
            _currentBlock.Rotate((block, dx, dy) => _board.CanMove(block, dx, dy));
            break;

        case ConsoleKey.Spacebar:
            var p = _currentBlock;
            for (int y = 0; y < _h ; y++){ 
              
            _board.Move_Block(0, y, _currentBlock);
            }
            _board.Move_Block(0, 1, _currentBlock);
            _board.Move_Block(0, 1, _currentBlock);
            _board.Move_Block(0, 1, _currentBlock);
            _board.Move_Block(0, 1, _currentBlock);
            break;
    }
}

    private void HandleGravity()
    {
        HandleInput();
        if ((DateTime.Now - _lastFall).TotalMilliseconds >= speed)
        {   
            _board.Move_Block(0, 1, _currentBlock);
            _lastFall = DateTime.Now;

        }
    }
    
    private void Handle_speed()
    {
        int p = _board.Speed_Incerase;

        speed = 1000 * Math.Pow(0.9,p);

        if (speed <= 300)
        {
            speed = 300;

        }





    }





    
    private void UpdateGameState()
{
    

    if (_board.Landed(_currentBlock))
    {



        if (_currentBlock.Get_Y() == 0)
            {
                
                running = false;

            }
        if (!_isLocking)
        {
            _isLocking = true;
            _lockStart = DateTime.Now;
        }


        if ((DateTime.Now - _lockStart).TotalMilliseconds >= _lockDelay)
        {
            _board.Update_Board();
            _board.CheckLines();

            _currentBlock = _board.create_block(_w/2 - 2, 0);

            _isLocking = false; 
        }
    }
    else
    {

        _isLocking = false;
    }
    if (_board.Give_points())
    {
        _points += 100000/speed;
        _board._points = false;
    }
    



    }
    
    
    
}